using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using NuGetTest;

using Xamarin.Android.Net;
using Xamarin.Forms.Platform.Android.FastRenderers;

namespace QZhiHuFind.Droid
{
    [Activity(Label = "Q发现知乎", 
              Icon = "@drawable/icon", 
              Theme = "@style/MainTheme", 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");

            AssemblyInit();

            LoadApplication(new App());
        }

		void AssemblyInit()
		{
            DuGu.XFLib.Droid.ControlSet.Init();
            DuGu.XFLib.Droid.Services.AndroidToolBar.Init(Resource.Id.toolbar);
            CarouselView.FormsPlugin.Android.CarouselViewRenderer.Init();
            FFImageLoading.Forms.Droid.CachedImageRenderer.Init(true);
		}

	}
}
