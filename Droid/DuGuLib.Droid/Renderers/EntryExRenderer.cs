using DuGu.XFLib.Controls;
using DuGu.XFLib.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Widget;

[assembly: ExportRenderer(typeof(EntryEx), typeof(EntryExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class EntryExRenderer : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            UpdateLineColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == EntryEx.BottomLineColorProperty.PropertyName)
                UpdateLineColor();
        }

        void UpdateLineColor()
        {
            var entryEx = Element as EntryEx;
            if(entryEx.BottomLineColor != Color.Default)
            {
                Control.Background.SetColorFilter(
                    entryEx.BottomLineColor.ToAndroid(), 
                    Android.Graphics.PorterDuff.Mode.SrcAtop);
            }
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