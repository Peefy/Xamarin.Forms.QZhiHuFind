
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using DuGu.XFLib.Controls;
using DuGu.XFLib.iOS.Renderers;

[assembly: ExportRenderer(typeof(ScrollViewEx), typeof(ScrollViewRenderer))]
namespace DuGu.XFLib.iOS.Renderers
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
            UpdateScrollBarsVisible();

            e.NewElement.PropertyChanged += (sender, ea) => 
            {
                if(ea.PropertyName == ScrollViewEx.ScrollBarsVisibleProperty.PropertyName)
                {
                    UpdateScrollBarsVisible();
                }
            };

		}

		void UpdateScrollBarsVisible()
		{
            var view = Element as ScrollViewEx;
			var visible = view.ScrollBarsVisible;
			this.ShowsHorizontalScrollIndicator = visible;
			this.ShowsVerticalScrollIndicator = visible;
		}

    }
}
