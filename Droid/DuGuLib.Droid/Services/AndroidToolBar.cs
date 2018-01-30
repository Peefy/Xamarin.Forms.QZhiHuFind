using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

using Android.Widget;
using Android.Views;
using Android.App;

using Android.Support.V7.App;

using DuGu.XFLib.Services;

[assembly: Dependency(typeof(DuGu.XFLib.Droid.Services.AndroidToolBar))]
namespace DuGu.XFLib.Droid.Services
{
    public class AndroidToolBar : IAndroidToolBar
    {

        static int resoureIdToolBar = -1;

        public static void Init(int toolBarResourceId)
        {
            resoureIdToolBar = toolBarResourceId;
        }

        TextView initTextView;
        Android.Support.V7.Widget.Toolbar FatherToolbar;

        public void ClearMiddleText()
        {
            if (FatherToolbar != null && initTextView != null && resoureIdToolBar != -1)
            {
                FatherToolbar.RemoveView(initTextView);
            }
        }

        public void SetToolBarMiddleText(string text, Color color)
        {
            if (resoureIdToolBar == -1)
                return;
            var page = Xamarin.Forms.Application.Current.MainPage;
            if(page is NavigationPage)
            {
                if (((NavigationPage)page).CurrentPage == null)
                    return;
                var activity = Forms.Context as Activity;

                var toolBar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(resoureIdToolBar);

                if(toolBar != null)
                {
                    FatherToolbar = toolBar;
                }
                InitToolBarMiddleText(text,color);
            }
        }

        Page GetCurrentPage()
        {
            var page = Xamarin.Forms.Application.Current.MainPage;
            if (page is NavigationPage)
            {
                return ((NavigationPage)page).CurrentPage;
            }
            return null;
        }

        void InitToolBarMiddleText(string text,Color color)
		{
			var toolbar = FatherToolbar;
			if (toolbar != null)
			{
				string toolbarTitle = text;
				var layoutPara = new Android.Support.V7.Widget.Toolbar.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent, 
                    ViewGroup.LayoutParams.WrapContent, 1);
                if(initTextView != null)
                {
                    toolbar.RemoveView(initTextView);
                }
				initTextView = new TextView(Forms.Context)
                {
                    LayoutParameters = layoutPara,
                    Gravity = GravityFlags.Center,
                    Text = toolbarTitle,
                    TextSize = 18,
				};
				initTextView.SetSingleLine();
                initTextView.SetTextColor(color.ToAndroid());
				toolbar.AddView(initTextView);
				toolbar.Title = "";
                GetCurrentPage().Title = "";
			}
		}

        public void Dispose()
        {
			if (FatherToolbar != null)
			{
                if(initTextView != null)
                {
                    FatherToolbar.RemoveView(initTextView);
                    FatherToolbar = null;
					initTextView.Dispose();
					initTextView = null;
                }
				
			}
        }

        ~AndroidToolBar()
        {
            Dispose();
        }

    }
}
