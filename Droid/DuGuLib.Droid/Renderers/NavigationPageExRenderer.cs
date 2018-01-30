using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using System.ComponentModel;
using System.Reflection;
using DuGu.XFLib.Controls;
using DuGu.XFLib.Droid.Renderers;

[assembly: ExportRenderer(typeof(NavigationPageEx), typeof(NavigationPageExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class NavigationPageExRenderer : NavigationPageRenderer
    {
        Android.Support.V7.Widget.Toolbar FatherToolbar;
        TextView initTextView;

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            FatherToolbar = (Android.Support.V7.Widget.Toolbar)typeof(NavigationPageRenderer)
                    .GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(this);
            InitToolBarMiddleText();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var navi = (NavigationPageEx)Element;
            if (e.PropertyName == NavigationPageEx.MiddleTitleColorProperty.PropertyName)
                UpdateToolBarMiddleText(navi.MiddleTitleColor);
            if (e.PropertyName == NavigationPageEx.MiddleTitleTextProperty.PropertyName)
                UpdateToolBarMiddleText(navi.MiddleTitleText);
        }

        void InitToolBarMiddleText()
        {
            var toolbar = FatherToolbar;
            if (toolbar != null)
            {
                string toolbarTitle = "日报";
                var layoutPara = new Android.Support.V7.Widget.Toolbar.LayoutParams(
                    LayoutParams.WrapContent, LayoutParams.WrapContent, 1);
                initTextView = new TextView(Forms.Context)
                {
                    LayoutParameters = layoutPara,
                    Gravity = GravityFlags.Center,
                    Text = toolbarTitle,
                    TextSize = 20,
                };
                initTextView.SetSingleLine();
                initTextView.SetTextColor(Android.Graphics.Color.White);
                toolbar.AddView(initTextView);
                toolbar.Title = "";
            }
        }

        void UpdateToolBarMiddleText(Color color)
        {
            var toolbar = FatherToolbar;
            if (toolbar != null && initTextView != null)
            {
                initTextView.SetTextColor(color.ToAndroid());
                toolbar.Title = ""; //这样就看不到左边的Title了
            }
            else
            {
                var layoutPara = new Android.Support.V7.Widget.Toolbar.LayoutParams(
                    LayoutParams.WrapContent, LayoutParams.WrapContent, 1);
                initTextView = new TextView(Forms.Context)
                {
                    LayoutParameters = layoutPara,
                    Gravity = GravityFlags.Center,
                    Text = "",
                    TextSize = 20,
                };
                initTextView.SetSingleLine();
                initTextView.SetTextColor(color.ToAndroid());
                toolbar.AddView(initTextView);
                toolbar.Title = "";
            }
        }

        void UpdateToolBarMiddleText(string text)
        {
            var toolbar = FatherToolbar;
            if (toolbar != null && initTextView != null)
            {
                initTextView.Text = text;
                toolbar.Title = "";//这样就看不到左边的Title了
            }
            else
            {
                var layoutPara = new Android.Support.V7.Widget.Toolbar.LayoutParams(
                    LayoutParams.WrapContent, LayoutParams.WrapContent, 1);
                initTextView = new TextView(Forms.Context)
                {
                    LayoutParameters = layoutPara,
                    Gravity = GravityFlags.Center,
                    Text = text,
                    TextSize = 20,
                };
                initTextView.SetSingleLine();
                initTextView.SetTextColor(Android.Graphics.Color.White);
                toolbar.AddView(initTextView);
                toolbar.Title = "";
            }
        }

        private bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (FatherToolbar != null)
                    {
                        FatherToolbar = null;
                    }
                    if (initTextView != null)
                    {
                        initTextView.Dispose();
                        initTextView = null;
                    }
                }
                disposed = true;
            }
            base.Dispose(disposing);
        }

    }
}