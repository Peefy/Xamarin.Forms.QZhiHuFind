using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using DuGu.XFLib.Services;
using Android.App;

[assembly: Dependency(typeof(DuGu.XFLib.Droid.Services.Screen))]
namespace DuGu.XFLib.Droid.Services
{
    public class Screen : IScreen
    {
        public Size GetFullSize()
        {
            var activity = Forms.Context as Activity;
            var displayMetrics = Forms.Context.Resources.DisplayMetrics;
            var width = ConvertPixelsToDp(displayMetrics.WidthPixels);
            var height = ConvertPixelsToDp(displayMetrics.HeightPixels);
            return new Size(width, height);
        }

        int ConvertPixelsToDp (float pixelValue)
        {
            return (int)(pixelValue / Forms.Context.Resources.DisplayMetrics.Density);
        }


    }
}
