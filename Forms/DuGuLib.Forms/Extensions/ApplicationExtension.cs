using System;

using Xamarin.Forms;

using DuGu.XFLib.Services;

using static DuGu.XFLib.Platform.CustomFontSize;

namespace DuGu.XFLib.Extensions
{
    public static class ApplicationExtension
    {
		static Color PrimaryColor = Color.FromHex("#2196F3");
		static Color BarTextColor = Color.White;
        static Color BackColor = Color.FromHex("#E2DFED");

        public static void AppResourcesInit(this Application app)
		{
			var style = new Style(typeof(NavigationPage));
			style.Setters.Add(new Setter()
			{
				Property = NavigationPage.BarBackgroundColorProperty,
				Value = PrimaryColor,
			});
			style.Setters.Add(new Setter()
			{
				Property = NavigationPage.BarTextColorProperty,
				Value = BarTextColor,
			});

			var resource = new ResourceDictionary();
			resource.Add(style);

			resource.Add("PrimaryColor", PrimaryColor);

			resource.Add(nameof(LittleSize), LittleSize);
			resource.Add(nameof(MidMediumSize), MidMediumSize);
			resource.Add(nameof(MediumSize), MediumSize);
			resource.Add(nameof(LargeSize), LargeSize);
			resource.Add(nameof(LargerSize), LargerSize);
			resource.Add(nameof(BigSize), BigSize);
			resource.Add(nameof(ExtraBigSize), ExtraBigSize);

			app.Resources = resource;
		}

        public static void AppResourcesInit(this Application app, Color barBackColor, Color barTextColor)
		{
            
			var style = new Style(typeof(NavigationPage));
			style.Setters.Add(new Setter()
			{
				Property = NavigationPage.BarBackgroundColorProperty,
                Value = barBackColor,
			});
			style.Setters.Add(new Setter()
			{
				Property = NavigationPage.BarTextColorProperty,
                Value = barTextColor,
			});

			var resource = new ResourceDictionary();
			resource.Add(style);

			resource.Add("PrimaryColor", PrimaryColor);

			resource.Add(nameof(LittleSize), LittleSize);
			resource.Add(nameof(MidMediumSize), MidMediumSize);
			resource.Add(nameof(MediumSize), MediumSize);
			resource.Add(nameof(LargeSize), LargeSize);
			resource.Add(nameof(LargerSize), LargerSize);
			resource.Add(nameof(BigSize), BigSize);
			resource.Add(nameof(ExtraBigSize), ExtraBigSize);

			app.Resources = resource;
		}

        public static void RegisterPageViewBackColor(this Application app)
        {
            if (app.Resources == null)
                app.Resources = new ResourceDictionary();

            var style = new Style(typeof(VisualElement));
            style.Setters.Add(new Setter()
            {
                Property = VisualElement.BackgroundColorProperty,
                Value = BackColor,
            });
            app.Resources.Add(style);
        }
    }
}
