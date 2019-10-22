using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using combit.ListLabel25.Dom;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace combit.ListLabel25.Converters
{
    internal static class StaticHelper
    {
        internal static void SetCommonFieldProperties(TableFieldBase llObj, ReportObject obj)
        {
            llObj.Width = ConvertUnit(obj.Width).ToUnit();
            llObj.Filling.Style = "0";
            llObj.Name = obj.Name;
            llObj.Frame.Default = "False";
            ConvertBorder(llObj.Frame, obj.Border);
        }

        internal static void ConvertObjectFormat(TableFieldText llObj, ObjectFormat format)
        {
            if (format.EnableCanGrow)
            {
                // wrap
                llObj.Wrapping.Line = "1";
            }
            else
            {
                // cut off
                llObj.Wrapping.Line = "0";
            }

            switch (format.HorizontalAlignment)
            {
                case Alignment.LeftAlign:
                    llObj.AlignmentHorizontal.Alignment = "0";
                    break;
                case Alignment.RightAlign:
                    llObj.AlignmentHorizontal.Alignment = "2";
                    break;
                case Alignment.HorizontalCenterAlign:
                    llObj.AlignmentHorizontal.Alignment = "1";
                    break;
                case Alignment.Justified:
                    llObj.Adjusted = "True";
                    break;
                case Alignment.Decimal:
                    llObj.AlignmentHorizontal.Alignment = "3";
                    break;
            }
        }

        internal static int ConvertUnit(double value)
        {
            // TWIPS to SCM
            double conversionFactor = 1.0 / 1440 * 2540 * 10;
            return Convert.ToInt32(value * conversionFactor);
        }

        internal static void ConvertBorder(PropertyFrame propertyFrame, Border border)
        {
            ConvertBorderLine(propertyFrame.Top, border, border.TopLineStyle);
            ConvertBorderLine(propertyFrame.Bottom, border, border.BottomLineStyle);
            ConvertBorderLine(propertyFrame.Left, border, border.LeftLineStyle);
            ConvertBorderLine(propertyFrame.Right, border, border.RightLineStyle);
        }

        internal static void ConvertBorderLine(PropertyFrameLine frameLine, Border border, LineStyle lineStyle)
        {
            frameLine.Line.Visible = "True";

            switch (lineStyle)
            {
                case LineStyle.DashLine:
                    frameLine.Line.LineType = "2";
                    break;

                case LineStyle.DotLine:
                    frameLine.Line.LineType = "1";
                    break;

                case LineStyle.DoubleLine:
                    frameLine.Line.LineType = "5";
                    frameLine.Line.Width = "UnitFromSCM(400)";
                    break;

                case LineStyle.SingleLine:
                    frameLine.Line.LineType = "0";
                    break;

                default:
                    frameLine.Line.Visible = "False";
                    break;
            }
            frameLine.Line.Color = border.BorderColor.ToFormula();
        }

        private static ReportObjectKind[] _convertibleObjectKinds = { ReportObjectKind.FieldObject, ReportObjectKind.FieldHeadingObject, ReportObjectKind.PictureObject, ReportObjectKind.TextObject };

        internal static ReadOnlyCollection<int> DistinctTopCoordinates(Section section)
        {
            var s = (from ReportObject obj in section.ReportObjects where (_convertibleObjectKinds.ToList().Contains(obj.Kind)) orderby obj.Top select obj.Top).Distinct();
            return s.ToList().AsReadOnly();
        }

        internal static void SetCommonObjectProperties(ObjectBase llObj, ReportObject obj, System.Drawing.Point offset)
        {
            llObj.Name = obj.Name;
            System.Drawing.Rectangle rect = ConvertPosition(obj, offset);
            llObj.Position.Set(rect.Left.ToUnit(), rect.Top.ToUnit(), rect.Width.ToUnit(), rect.Height.ToUnit());
        }

        private static System.Drawing.Rectangle ConvertPosition(ReportObject obj, System.Drawing.Point offset)
        {
            System.Drawing.Rectangle result = new System.Drawing.Rectangle();
            result.X = StaticHelper.ConvertUnit(obj.Left) + offset.X;
            result.Y = StaticHelper.ConvertUnit(obj.Top) + offset.Y;
            result.Width = StaticHelper.ConvertUnit(obj.Width);
            result.Height = StaticHelper.ConvertUnit(obj.Height);
            return result;
        }

        internal static string ConvertGroupFieldDefinition(FieldDefinition groupField)
        {
            switch (groupField.ValueType)
            {
                case FieldValueType.StringField:
                    return ConvertFormula(groupField.FormulaName);
                case FieldValueType.NumberField:
                    return String.Format(CultureInfo.InvariantCulture, "Str$({0}", groupField.FormulaName.ToFormula());
                default:
                    return ConvertFormula(groupField.FormulaName);
            }
        }


        internal static string ConvertFunctionName(string functionName)
        {
            switch (functionName)
            {
                case "Average":
                    return "Avg";
                case "Sum":
                case "Maximum":
                case "Minimum":
                case "Count":
                case "Median":
                case "Mode":
                    return functionName;
            }
            throw new ArgumentException("Unknown function name.", "functionName");
        }

        internal static string ConvertFormula(string formula)
        {

            // first, a few trivial conversions
            switch (formula)
            {
                case "PrintDate":
                    return "Now()";
                case "PageNumber":
                    return "Page$()";
                case "Now":
                    return "Now()";
                case "Today":
                    return "Today()";
                case "PageNofM":
                    return "Page$()+\"/\"+TotalPages$()";
            }

            // simple fields
            Match m = Regex.Match(formula, @"^{([a-zA-Z0-9\.]+)}");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }

            // simple aggregates
            m = Regex.Match(formula, @"^(Sum|Average|Maximum|Minimum|Count|Median|Mode) \({([a-zA-Z0-9\.]+)}\)");
            if (m.Success)
            {
                return String.Format(CultureInfo.InvariantCulture, "{0}({1})", ConvertFunctionName(m.Groups[1].Value), m.Groups[2].Value);
            }

            // group aggregates
            m = Regex.Match(formula, @"^(Sum|Average|Maximum|Minimum|Count|Median|Mode) \({([a-zA-Z0-9\.]+)},.+\)");
            if (m.Success)
            {
                return String.Format(CultureInfo.InvariantCulture, "{0}({1})", ConvertFunctionName(m.Groups[1].Value), m.Groups[2].Value);
            }

            // group names
            m = Regex.Match(formula, @"^GroupName \({([a-zA-Z0-9\.]+)}\)");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            return formula.ToFormula();
        }

        internal static TableFieldText AddEmptyField(TableLineBase tableLine, string width)
        {
            TableFieldText textField = tableLine.Fields.AddNewText();
            textField.Contents = "".ToFormula();
            textField.Frame.Default = "False";
            textField.Frame.Bottom.Line.Visible = "False";
            textField.Frame.Left.Line.Visible = "False";
            textField.Frame.Top.Line.Visible = "False";
            textField.Frame.Right.Line.Visible = "False";
            textField.Width = width;
            textField.Filling.Style = "0";
            return textField;
        }
    }
}
