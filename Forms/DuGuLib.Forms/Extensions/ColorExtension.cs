using System;

using Xamarin.Forms;

namespace DuGu.XFLib.Extensions
{
    public static class ColorExtension
    {
        public static string ToHexString(this Color c)
        {
            return $"#{ColorAsInt(c.A):x2}{ColorAsInt(c.G):x2}{ColorAsInt(c.B):x2}";
        }

        static int ColorAsInt(double color)
        {
            return (int)(255 * color);
        }

    }
}
