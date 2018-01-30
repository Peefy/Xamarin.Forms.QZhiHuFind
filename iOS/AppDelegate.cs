using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace NuGetTest.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            AssemblyInit();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        void AssemblyInit()
        {
            DuGu.XFLib.iOS.ControlSet.Init();
            CarouselView.FormsPlugin.iOS.CarouselViewRenderer.Init();
            FFImageLoading.Forms.Touch.CachedImageRenderer.Init();
            var s = new FFImageLoading.Transformations.RoundedTransformation();
            var a = new FFImageLoading.Transformations.CircleTransformation();
        }

    }
}
