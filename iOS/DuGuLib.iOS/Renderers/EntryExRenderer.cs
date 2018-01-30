using System;
using System.ComponentModel;

using CoreGraphics;
using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using DuGu.XFLib.Controls;
using DuGu.XFLib.iOS.Renderers;
using CoreAnimation;
using System.Linq;

[assembly: ExportRenderer(typeof(EntryEx), typeof(EntryExRenderer))]
namespace DuGu.XFLib.iOS.Renderers
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
            if (e.PropertyName == EntryEx.BottomLineColorProperty.PropertyName
                || e.PropertyName == "Height")
                UpdateLineColor();
        }

		private void UpdateLineColor()
        {
            var entryEx = Element as EntryEx;
            if (entryEx == null)
                return;
            Control.Bounds = new CGRect(0, 0, entryEx.Width, entryEx.Height);
            if (entryEx.BottomLineColor != Color.Default)
            {
                BorderLineLayer lineLayer = Control.Layer.Sublayers.OfType<BorderLineLayer>()
                                                             .FirstOrDefault();
                if (lineLayer == null)
                {
                    lineLayer = new BorderLineLayer();
                    lineLayer.MasksToBounds = true;
                    lineLayer.BorderWidth = 1.0f;
                    Control.Layer.AddSublayer(lineLayer);
                    Control.BorderStyle = UITextBorderStyle.None;
                }

                lineLayer.Frame = new CGRect(0f, Control.Frame.Height - 1f, Control.Bounds.Width, 1f);
                lineLayer.BorderColor = entryEx.BottomLineColor.ToCGColor();
                Control.TintColor = Control.TextColor;
            }
        }

        private class BorderLineLayer : CALayer
        {
            
        }

    }
}
