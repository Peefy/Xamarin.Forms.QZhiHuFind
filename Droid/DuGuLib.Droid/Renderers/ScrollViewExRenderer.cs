using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using DuGu.XFLib.Controls;
using DuGu.XFLib.Droid.Renderers;

[assembly: ExportRenderer(typeof(ScrollViewEx), typeof(ScrollViewExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class ScrollViewExRenderer : ScrollViewRenderer
    {
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
			{
				return;
			}

			if (e.OldElement != null)
			{
				e.OldElement.PropertyChanged -= OnElementPropertyChanged;
			}

			e.NewElement.PropertyChanged += OnElementPropertyChanged;
		}

		private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
            var scrollView = Element as ScrollViewEx;
			if (e.PropertyName == "ContentSize" && ChildCount > 0)
			{
				Android.Views.View child = GetChildAt(0);
                child.VerticalScrollBarEnabled = scrollView.ScrollBarsVisible;
                child.HorizontalScrollBarEnabled = scrollView.ScrollBarsVisible;
			}
            else if(e.PropertyName == ScrollViewEx.ScrollBarsVisibleProperty.PropertyName)
            {
				Android.Views.View child = GetChildAt(0);
				child.VerticalScrollBarEnabled = scrollView.ScrollBarsVisible;
				child.HorizontalScrollBarEnabled = scrollView.ScrollBarsVisible;
            }
		}
    }
}
