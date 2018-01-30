using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using DuGu.XFLib.Droid.Renderers;
using DuGu.XFLib.Controls;

using Android.Support.V4.Widget;
using System.Reflection;
using System;

[assembly: ExportRenderer(typeof(ListViewEx), typeof(ListViewExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class ListViewExRenderer : ListViewRenderer
    {
        private SwipeRefreshLayout RefreshLayout;

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            RefreshLayout = (SwipeRefreshLayout)typeof(ListViewRenderer)
                    .GetField("_refresh", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(this);

            UpdateScrollBarsVisible();
            UpdateCanItemFocus();
            UpdateRefreshColor();

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ListViewEx.ScrollBarsVisibleProperty.PropertyName)
                UpdateScrollBarsVisible();
            else if (e.PropertyName == ListViewEx.CanItemsFocusProperty.PropertyName)
                UpdateCanItemFocus();
            else if(e.PropertyName == ListViewEx.RefreshColorProperty.PropertyName)
                UpdateRefreshColor();
        }

        void UpdateScrollBarsVisible()
        {
            var listViewEx = Element as ListViewEx;
            var visible = listViewEx.ScrollBarsVisible;
            Control.HorizontalScrollBarEnabled = visible;
            Control.VerticalScrollBarEnabled = visible;
        }

        void UpdateCanItemFocus()
        {
            var listViewEx = Element as ListViewEx;
            var canFocus = listViewEx.CanItemsFocus;
            if (canFocus == false)
                Control.SetSelector(Android.Resource.Color.Transparent);
        }

        void UpdateRefreshColor()
        {
            var listViewEx = Element as ListViewEx;
            var color = listViewEx.RefreshColor;
            if(color != Color.Default)
                RefreshLayout.SetColorSchemeColors(color.ToAndroid());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(RefreshLayout != null)
                {
                    RefreshLayout = null;
                }
            }
            base.Dispose(disposing);
        }

    }
}