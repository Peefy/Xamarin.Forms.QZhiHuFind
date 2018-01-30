using System;
using Xamarin.Forms;

using DuGu.XFLib.Services;
using UIKit;

[assembly: Dependency(typeof(DuGu.XFLib.iOS.Services.Screen))]
namespace DuGu.XFLib.iOS.Services
{
    public class Screen : IScreen
    {
        public Size GetFullSize()
        {
            return new Size(UIScreen.MainScreen.Bounds.Width,
                            UIScreen.MainScreen.Bounds.Height);
        }
    }
}
