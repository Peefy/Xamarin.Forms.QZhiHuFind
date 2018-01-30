
using System;
using System.ComponentModel;

using CoreGraphics;
using UIKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using DuGu.XFLib.Controls;
using DuGu.XFLib.iOS.Renderers;
using DuGu.XFLib.iOS.Extensions;

[assembly: ExportRenderer(typeof(ImageEx), typeof(ImageExRenderer))]
namespace DuGu.XFLib.iOS.Renderers
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
                UpdateImageViewColorFilter(imageEx.ColorFilter.ToUIColor());
            }
            else
            {
                if(imageEx.Source != null)
                    Control.SetFormsImageSourceButNotUrl(imageEx.Source);
            }
        }

        private void UpdateImageViewColorFilter(UIColor color)
        {
            var image = Control.Image;
            if(image == null)
                return;
            UIGraphics.BeginImageContextWithOptions(image.Size, false, image.CurrentScale);
            var context = UIGraphics.GetCurrentContext(); //获得Context的引用
            context.TranslateCTM(0, image.Size.Height);
            context.ScaleCTM(1.0f, -1.0f);
            context.SetBlendMode(CGBlendMode.Normal);
            var rect = new CGRect(0, 0, image.Size.Width, image.Size.Height);
            context.ClipToMask(rect, image.CGImage);
            context.SetFillColor(color.CGColor);
            context.FillRect(rect);
            var newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            Control.Image = newImage;

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
