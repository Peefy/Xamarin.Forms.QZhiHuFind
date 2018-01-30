using System;
using UIKit;

namespace DuGu.XFLib.iOS.Extensions
{
    public static class FontFamilyExtension
    {
		public static UIFont ToUIFont(this string fontfamilary, nfloat? fontSize = null)
		{
			try
			{
				return UIFont.FromName(fontfamilary, fontSize ?? UIFont.SystemFontSize);
			}
			catch
			{
				return UIFont.PreferredBody;
			}
		}
    }
}
