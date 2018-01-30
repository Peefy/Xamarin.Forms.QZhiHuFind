using Android.Graphics;
using Android.Views;
using Xamarin.Forms;

namespace DuGu.XFLib.Droid.Extensions
{
    public static class TextAlignmentExtension
    {
		public static GravityFlags ToHorizontalGravityFlags(this Xamarin.Forms.TextAlignment alignment)
		{
			if (alignment == Xamarin.Forms.TextAlignment.Center)
				return GravityFlags.AxisSpecified;
			return alignment == Xamarin.Forms.TextAlignment.End ? GravityFlags.Right : GravityFlags.Left;
		}

		public static GravityFlags ToVerticalGravityFlags(this Xamarin.Forms.TextAlignment alignment)
		{
			if (alignment == Xamarin.Forms.TextAlignment.Start)
				return GravityFlags.Top;
			return alignment == Xamarin.Forms.TextAlignment.End ? GravityFlags.Bottom : GravityFlags.CenterVertical;
		}
    }
}
