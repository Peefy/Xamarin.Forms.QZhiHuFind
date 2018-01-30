using Android.Graphics;
using Android.Views;
using Xamarin.Forms;

namespace DuGu.XFLib.Droid.Extensions
{
    public static class FontFamilyExtension
    {
		public static Typeface ToTypeface(this string fontfamilary)
		{
			try
			{
				return Typeface.CreateFromAsset(Forms.Context.Assets, fontfamilary);
			}
			catch
			{
				return Typeface.Default;
			}
		}
    }
}
