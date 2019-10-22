using System;
using System.Drawing;
using System.Globalization;

namespace combit.ListLabel25.Converters
{
    internal static class ExtensionMethods
    {
        public static string ToFormula(this string value)
        {
            return String.Concat("\"", value.Replace("\n", "\" + Chr$(13) + \""), "\"");
        }

        public static string ToFormula(this Color value)
        {
            return String.Format(CultureInfo.InvariantCulture, "RGB({0},{1},{2})", value.R, value.G, value.B);
        }

        public static string ToUnit(this int value)
        {
            return String.Format(CultureInfo.InvariantCulture, "UnitFromSCM({0})", value);
        }

        public static string FixSqlColorName(this string colorName)
        {
            return colorName.Replace("Grey", "Gray");
        }
    }
}
