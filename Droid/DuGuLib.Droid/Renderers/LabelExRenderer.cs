using DuGu.XFLib.Controls;
using DuGu.XFLib.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Widget;
using Android.Graphics;
using Xamarin.Forms;
using System;

[assembly: ExportRenderer(typeof(LabelEx), typeof(LabelExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class LabelExRenderer : LabelRenderer
    {

        PaintFlags initPaintFlags;

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            initPaintFlags = Control.PaintFlags;
            SetMaxLines();
            UpdateHasUnderLine();
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
            Control.SetMaxLines(labelEx.MaxLines);
        }

        private void UpdateHasUnderLine()
        {
            var labelEx = Element as LabelEx;
            if (labelEx.IsHasUnderLine == true)
                Control.PaintFlags |= PaintFlags.UnderlineText;
            else
                Control.PaintFlags = initPaintFlags;
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