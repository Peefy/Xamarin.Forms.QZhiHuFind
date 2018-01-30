
using DuGu.XFLib.Controls;
using DuGu.XFLib.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Widget;
using Android.Views;
using System;

[assembly: ExportRenderer(typeof(ImageEx), typeof(ImageExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class ImageExRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            UpdateColorFilter();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ImageEx.ColorFilterProperty.PropertyName)
            {
                UpdateColorFilter();
            }
        }

        private void UpdateColorFilter()
        {
            var imageEx = Element as ImageEx;
            if (imageEx.ColorFilter != Color.Default)
            {
                Control.SetColorFilter(imageEx.ColorFilter.ToAndroid());               
            }
            else
            {
                Control.ClearColorFilter();
            }
        }

        #region Dispose
        private bool IsDisposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposing && !this.IsDisposed)
            {
                InternalDispose();
            }
            base.Dispose(disposing);
        }

        private void InternalDispose()
        {
            
        }

        #endregion
    }
}