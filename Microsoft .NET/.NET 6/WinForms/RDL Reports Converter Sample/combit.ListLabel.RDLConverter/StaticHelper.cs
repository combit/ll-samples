using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using combit.Reporting.Dom;
using System.Xml;
using System.Drawing;

namespace combit.Reporting.Converters
{
    internal static class StaticHelper
    {
        internal static string _reportUnitType;
        internal static string _tableName;

        internal static void SetCommonFieldProperties(TableFieldBase llObj, XmlElement obj, int fieldWidth)
        {
            llObj.Width = fieldWidth.ToUnit();
            llObj.Filling.Style = "0";
            llObj.Name = obj.LocalName;
            llObj.Frame.Default = "False";
            ConvertBorder(llObj.Frame, obj["Style"]);
            ConvertPadding(llObj.Frame, obj["Style"]);
        }

        internal static void ConvertObjectFormat(TableFieldText llObj, XmlElement obj)
        {
            if (bool.Parse(obj["CanGrow"].InnerText))
            {
                // wrap
                llObj.Wrapping.Line = "1";
            }
            else
            {
                // cut off
                llObj.Wrapping.Line = "0";
            }

            if (obj["Paragraphs"]["Paragraph"]["Style"]["TextAlign"] != null)
                switch (obj["Paragraphs"]["Paragraph"]["Style"]["TextAlign"].InnerText)
                {
                    case "Left":
                        llObj.AlignmentHorizontal.Alignment = "0";
                        break;
                    case "Right":
                        llObj.AlignmentHorizontal.Alignment = "2";
                        break;
                    case "Center":
                        llObj.AlignmentHorizontal.Alignment = "1";
                        break;
                }
        }

        internal static int ConvertUnit(string value, string UnitType)
        {
            double conversionFactor = 0;
            switch (UnitType)
            {
                case "HundredthInch":
                    conversionFactor = 2.54 * 10 * 10;
                    break;
                case "Inch":
                    conversionFactor = 2.54 * 1000 * 10;
                    value = value.Replace("in", "");
                    break;
                case "Point":
                    conversionFactor = 0.3527 * 1000;
                    value = value.Replace("pt", "");
                    break;
                default:
                    break;
            }
            return Convert.ToInt32(double.Parse(value, CultureInfo.InvariantCulture) * conversionFactor);
        }

        internal static void ConvertBorder(PropertyFrame propertyFrame, XmlElement style)
        {
            if (style["Border"]["Style"] != null)
            {
                ConvertBorderLine(propertyFrame.Top, style["Border"], style["Border"]["Style"].InnerText);
                ConvertBorderLine(propertyFrame.Bottom, style["Border"], style["Border"]["Style"].InnerText);
                ConvertBorderLine(propertyFrame.Left, style["Border"], style["Border"]["Style"].InnerText);
                ConvertBorderLine(propertyFrame.Right, style["Border"], style["Border"]["Style"].InnerText);
            }
            if (style["TopBorder"] != null)
                ConvertBorderLine(propertyFrame.Top, style["TopBorder"], style["TopBorder"]["Style"] != null ? style["TopBorder"]["Style"].InnerText : string.Empty);
            if (style["LeftBorder"] != null)
                ConvertBorderLine(propertyFrame.Left, style["LeftBorder"], style["LeftBorder"]["Style"] != null ? style["LeftBorder"]["Style"].InnerText : string.Empty);
            if (style["RightBorder"] != null)
                ConvertBorderLine(propertyFrame.Right, style["RightBorder"], style["RightBorder"]["Style"] != null ? style["RightBorder"]["Style"].InnerText : string.Empty);
            if (style["BottomBorder"] != null)
                ConvertBorderLine(propertyFrame.Bottom, style["BottomBorder"], style["BottomBorder"]["Style"] != null ? style["BottomBorder"]["Style"].InnerText : string.Empty);
        }

        internal static void ConvertBorderLine(PropertyFrameLine frameLine, XmlElement border, string lineStyle)
        {
            frameLine.Line.Visible = "True";

            switch (lineStyle)
            {
                case "Dashed":
                    frameLine.Line.LineType = "2";
                    break;

                case "Dotted":
                    frameLine.Line.LineType = "1";
                    break;

                case "Double":
                    frameLine.Line.LineType = "5";
                    frameLine.Line.Width = "UnitFromSCM(400)";
                    break;

                case "":
                case "Solid":
                    frameLine.Line.LineType = "0";
                    break;                                    

                default:
                    frameLine.Line.Visible = "False";
                    break;
            }
            frameLine.Line.Color = Color.FromName((border["Color"] != null ? border["Color"].InnerText : "Black").FixSqlColorName()).ToFormula()  ;
        }

        internal static void ConvertPadding(PropertyFrame propertyFrame, XmlElement style)
        {
            if (style["PaddingLeft"] != null)
                propertyFrame.Left.Space = ConvertUnit(style["PaddingLeft"].InnerText, "Point").ToUnit();
            if (style["PaddingRight"] != null)
                propertyFrame.Right.Space = ConvertUnit(style["PaddingRight"].InnerText, "Point").ToUnit();
            if (style["PaddingTop"] != null)
                propertyFrame.Top.Space = ConvertUnit(style["PaddingTop"].InnerText, "Point").ToUnit();
            if (style["PaddingBottom"] != null)
                propertyFrame.Bottom.Space = ConvertUnit(style["PaddingBottom"].InnerText, "Point").ToUnit();
        }

        internal static void SetCommonObjectProperties(ObjectBase llObj, XmlElement obj, System.Drawing.Point offset)
        {
            llObj.Name = obj.Name;
            System.Drawing.Rectangle rect = ConvertPosition(obj, offset);
            llObj.Position.Set(rect.Left.ToUnit(), rect.Top.ToUnit(), rect.Width.ToUnit(), rect.Height.ToUnit());
        }

        private static System.Drawing.Rectangle ConvertPosition(XmlElement obj, System.Drawing.Point offset)
        {
            System.Drawing.Rectangle result = new System.Drawing.Rectangle();
            result.X = StaticHelper.ConvertUnit(obj["Left"].InnerText, _reportUnitType) + offset.X;
            result.Y = StaticHelper.ConvertUnit(obj["Top"].InnerText, _reportUnitType) + offset.Y;
            result.Width = StaticHelper.ConvertUnit(obj["Width"].InnerText, _reportUnitType);
            result.Height = StaticHelper.ConvertUnit(obj["Height"].InnerText, _reportUnitType);
            return result;
        }
        
        internal static string ConvertOperator(string operatorName)
        {
            switch (operatorName)
            {
                case "MOD":
                    return "%";
                case "IS":
                    return "=";
                case "ANDALSO":
                    return "AND";
                case "ORELSE":
                    return "OR";                
            }
            throw new ArgumentException("Unknown operator.", "operatorName");
        }

        internal static string ConvertFunctionName(string functionName)
        {
            switch (functionName)
            {
                case "Asc":
                case "AscW":
                    return "Asc";
                case "Chr":
                case "ChrW":
                    return "Chr";
                case "InStr":
                    return "StrPos";
                case "InStrRev":
                    return "StrRPos";
                case "Avg":
                case "Sum":
                case "Count":
                case "Max":
                case "Min":
                case "LCase":
                case "Left":
                case "Len":
                case "LTrim":
                case "Mid":
                case "Replace":
                case "Right":
                case "RTrim":
                case "Trim":
                case "UCase":
                case "CDate":
                case "DateAdd":
                case "Day":
                case "Hour":
                case "Minute":
                case "Month":
                case "MonthName":
                case "Now":
                case "Second":
                case "Today":
                case "Weekday":
                case "WeekdayName":
                case "Year":
                case "Abs":
                case "Acos":
                case "Asin":
                case "Atan":
                case "Ceiling":
                case "Cos":
                case "Exp":
                case "Fix":
                case "Floor":
                case "Int":
                case "Log":
                case "Log10":
                case "Pow":
                case "Round":
                case "Sign":
                case "Sin":
                case "Sqrt":
                case "Tan":
                case "IsNothing":
                case "IIF":
                case "StDev":
                case "Var":
                case "Str":
                case "Val":
                    return functionName;
            }
            throw new ArgumentException("Unknown function name.", "functionName");
        }

        internal static string ConvertFormula(string formula, string keepWithGroup, string groupExpression)
        {
            formula = formula.TrimStart('=');
            // first, a few trivial conversions

            formula = formula.Replace("Globals!ExecutionTime", "Now()");
            formula = formula.Replace("Globals.ExecutionTime", "Now()");
            formula = formula.Replace("Globals!PageNumber", "Page$()");
            formula = formula.Replace("Globals.PageNumber", "Page$()");
            formula = formula.Replace("Globals.OverallPageNumber", "Page$()");
            formula = formula.Replace("Globals.OverallPageNumber", "Page$()");
            formula = formula.Replace("Globals!TotalPages", "TotalPages$()");
            formula = formula.Replace("Globals.TotalPages", "TotalPages$()");
            formula = formula.Replace("Globals!OverallTotalPages", "TotalPages$()");
            formula = formula.Replace("Globals.OverallTotalPages", "TotalPages$()");

            formula = formula.Replace("&", "+");

            Match m = Regex.Match(formula, @"(\s+|\)|\*|/|\+|-|<|>|=|&)(Mod|Is|AndAlso|OrElse)(\s+|\()");
            if (m.Success)
            {
                formula = String.Format(CultureInfo.InvariantCulture, "{0}{1}{2}", m.Groups[0].Value, ConvertFunctionName(m.Groups[1].Value), m.Groups[2].Value);
            }
            m = Regex.Match(formula, "(Asc|AscW|Chr|ChrW|InStr|InStrRev|LCase|Left|Len|LTrim|Mid|Replace|Right|RTrim|Trim|UCase" +
                "|CDate|DateAdd|Day|Hour|Minute|Month|MonthName|Now|Second|Today|Weekday|WeekdayName|Year" +
                "|Abs|Acos|Asin|Atan|Ceiling|Cos|Exp|Fix|Floor|Int|Log|Log10|Max|Min|Pow|Round|Sign|Sin|Sqrt|Tan" +
                "|IsNothing|IIF" +
                "|Avg|Count|StDev|Sum|Var|Str|Val" + @")\(([a-zA-Z0-9\.!]+)\)");
            if (m.Success)
            {
                if (keepWithGroup == "After" && (m.Groups[1].Value == "Avg" || m.Groups[1].Value == "Sum" || m.Groups[1].Value == "Count" || m.Groups[1].Value == "Max" || m.Groups[1].Value =="Min"))
                    formula = String.Format(CultureInfo.InvariantCulture, "Precalc({0}({1}), {2})", ConvertFunctionName(m.Groups[1].Value), m.Groups[2].Value, groupExpression);
                else
                    formula = String.Format(CultureInfo.InvariantCulture, "{0}({1})", ConvertFunctionName(m.Groups[1].Value), m.Groups[2].Value);
            }
            if (formula.Contains("Fields!") || formula.Contains("("))
                return formula.Replace("Fields!", string.Format("{0}.", _tableName)).Replace(".Value", "");
            if (string.IsNullOrEmpty(formula))
                return formula;
            else
                return formula.ToFormula();
        }

        internal static string ConvertFormula(string formula)
        {
            return ConvertFormula(formula, string.Empty, string.Empty);
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
