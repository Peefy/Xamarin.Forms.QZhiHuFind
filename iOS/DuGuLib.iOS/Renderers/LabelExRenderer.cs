using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DuGu.XFLib.Controls;
using DuGu.XFLib.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;

[assembly: ExportRenderer(typeof(LabelEx), typeof(LabelExRenderer))]
namespace DuGu.XFLib.iOS.Renderers
{
    public class LabelExRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            SetMaxLines();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == LabelEx.MaxLinesProperty.PropertyName)
                SetMaxLines();
            else if (e.PropertyName == LabelEx.IsHasUnderLineProperty.PropertyName)
                UpdateHasUnderLine();
        }

        private void SetMaxLines()
        {
            var labelEx = Element as LabelEx;
            Control.Lines = labelEx.MaxLines;
        }

        private void UpdateHasUnderLine()
        {
            var labelEx = Element as LabelEx;
            //if (labelEx.IsHasUnderLine == true)
            //{
            var s = new NSDictionary();
                var attributes = new UIStringAttributes { UnderlineStyle = NSUnderlineStyle.Single };
                var attrString = new NSMutableAttributedString(labelEx.Text, attributes);
                Control.AttributedText = attrString;
            //}
            //else
            //{
            //    var attributes = new UIStringAttributes { UnderlineStyle = NSUnderlineStyle.None };
            //    var attrString = new NSMutableAttributedString(labelEx.Text, attributes);
            //    Control.AttributedText = attrString;
            //}
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
			//退订事件

		}

		#endregion

	}
}
