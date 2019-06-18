// This class has been copied from Mmosoft.Oops framework (https://github.com/ThinhVu/Mmosoft.Oops)


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Mmosoft.Oops
{   
    // There is a pre-built class named ColorTranslator which also support html color format
    // The purpose of creating this class is provide more html color format in wider range 
    // from 1 -> 8 character and also rgb format
    public static class ExColorTranslator
    {
        private static Dictionary<string, Color> _cache;

        // 
        private static Regex hexArgb = new Regex(@"^\#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2}$)");
        private static Regex hexArgbShort = new Regex(@"^\#([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})$");
        private static Regex hexRgbFull = new Regex(@"^\#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})$");
        private static Regex hexRgbShort = new Regex(@"^\#([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})$");
        private static Regex hexRgbVeryShort = new Regex(@"^\#([0-9A-Fa-f]{1})([0-9A-Fa-f]{1})$");
        private static Regex hexRgbVeryVeryShort = new Regex(@"^\#([0-9A-Fa-f]{1})$");

        //
        private static Regex decArgb = new Regex(@"^(\d{1,3}),\s+(\d{1,3}),\s+(\d{1,3}),\s+(\d{1,3})$");
        private static Regex decRgb = new Regex(@"^(\d{1,3}),\s+(\d{1,3}),\s+(\d{1,3})$");


        static ExColorTranslator()
        {
            _cache = new Dictionary<string, Color>();
        }
        //
        public static Color Get(string color)
        {
            if (color == null)
                return Color.FromArgb(0, 0, 0, 0);

            if (_cache.ContainsKey(color))
                return _cache[color];

            Color c;
            Match match = null;

            if ((match = hexArgb.Match(color)).Success)
            {
                c = Color.FromArgb(
                    HexToDec(match.Groups[1].Value),
                    HexToDec(match.Groups[2].Value),
                    HexToDec(match.Groups[3].Value),
                    HexToDec(match.Groups[4].Value));
            }
            else if ((match = hexArgbShort.Match(color)).Success)
            {
                c = Color.FromArgb(
                    HexToDec(match.Groups[1].Value + match.Groups[1].Value),
                    HexToDec(match.Groups[2].Value + match.Groups[2].Value),
                    HexToDec(match.Groups[3].Value + match.Groups[3].Value),
                    HexToDec(match.Groups[4].Value + match.Groups[4].Value));
            }
            else if ((match = hexRgbFull.Match(color)).Success)
            {
                c = Color.FromArgb(
                    byte.MaxValue,
                    HexToDec(match.Groups[1].Value),
                    HexToDec(match.Groups[2].Value),
                    HexToDec(match.Groups[3].Value));
            }
            else if ((match = hexRgbShort.Match(color)).Success)
            {
                c = Color.FromArgb(
                    byte.MaxValue,
                    HexToDec(match.Groups[1].Value + match.Groups[1].Value),
                    HexToDec(match.Groups[2].Value + match.Groups[2].Value),
                    HexToDec(match.Groups[3].Value + match.Groups[3].Value)
                    );
            }
            else if ((match = hexRgbVeryShort.Match(color)).Success)
            {
                int opacity = HexToDec(match.Groups[1].Value + match.Groups[1].Value);
                int rgb = HexToDec(match.Groups[2].Value + match.Groups[2].Value);
                c = Color.FromArgb(opacity, rgb, rgb, rgb);
            }
            else if ((match = hexRgbVeryVeryShort.Match(color)).Success)
            {
                int rgb = HexToDec(match.Groups[1].Value + match.Groups[1].Value);
                c = Color.FromArgb(byte.MaxValue, rgb, rgb, rgb);
            }
            else if ((match = decArgb.Match(color)).Success)
            {
                int a = int.Parse(match.Groups[1].Value);
                int r = int.Parse(match.Groups[2].Value);
                int g = int.Parse(match.Groups[3].Value);
                int b = int.Parse(match.Groups[4].Value);

                if (a > byte.MaxValue || r > byte.MaxValue || g > byte.MaxValue || b > byte.MaxValue)
                    throw new ArgumentException("invalid color format");

                c = Color.FromArgb(a, r, g, b);
            }
            else if ((match = decRgb.Match(color)).Success)
            {
                int r = int.Parse(match.Groups[1].Value);
                int g = int.Parse(match.Groups[2].Value);
                int b = int.Parse(match.Groups[3].Value);

                if (r > byte.MaxValue || g > byte.MaxValue || b > byte.MaxValue)
                    throw new ArgumentException("invalid color format");

                c = Color.FromArgb(byte.MaxValue, r,g,b);
            }
            else
            {
                throw new ArgumentException("invalid color format");
            }

            _cache[color] = c;

            return c;
        }

        private static int HexToDec(string hex)
        {
            return int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
