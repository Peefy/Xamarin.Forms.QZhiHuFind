
using System;
using System.ComponentModel;

using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

using DuGu.XFLib.iOS.Renderers;
using DuGu.XFLib.Controls;
using System.Reflection;
using UIKit;

[assembly: ExportRenderer(typeof(ListViewEx), typeof(ListViewExRenderer))]
namespace DuGu.XFLib.iOS.Renderers
{
    public class ListViewExRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            UpdateScrollBarsVisible();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ListViewEx.ScrollBarsVisibleProperty.PropertyName)
                UpdateScrollBarsVisible();
            else if (e.PropertyName == ListViewEx.RefreshColorProperty.PropertyName)
                UpdateRefreshColor();
            UpdateCanItemFocus();
        }

        void UpdateScrollBarsVisible()
        {
            var listViewEx = Element as ListViewEx;
            var visible = listViewEx.ScrollBarsVisible;
            Control.ShowsHorizontalScrollIndicator = visible;
            Control.ShowsVerticalScrollIndicator = visible;
        }

        void UpdateCanItemFocus()
        {
            var listViewEx = Element as ListViewEx;
            var canFocus = listViewEx.CanItemsFocus;
            if (canFocus == false)
            {
                foreach (var cell in Control.VisibleCells)
                    cell.SelectionStyle = UIKit.UITableViewCellSelectionStyle.None;
            }
        }

        void UpdateRefreshColor()
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && Control != null)
            {
                Control.Dispose();
            }
        }

    }
}
