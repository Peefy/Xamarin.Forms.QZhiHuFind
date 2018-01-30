
using System;
using System.ComponentModel;

using CoreGraphics;
using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using DuGu.XFLib.Controls;
using DuGu.XFLib.iOS.Renderers;

[assembly: ExportRenderer(typeof(ImageButton), typeof(ImageButtonRenderer))]
namespace DuGu.XFLib.iOS.Renderers
{
    public class ImageButtonRenderer : ButtonRenderer
    {
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
