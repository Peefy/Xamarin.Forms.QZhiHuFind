using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using DuGu.XFLib.Droid.Renderers;

//[assembly: ExportRenderer(typeof(Page), typeof(PageExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class PageExRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            this.SetBackgroundColor(Color.Pink.ToAndroid());
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            this.SetBackgroundColor(Color.Pink.ToAndroid());
        }

    }
}
