using Xamarin.Forms;
using DuGu.XFLib.Controls;
using DuGu.XFLib.Droid.Renderers;
using Xamarin.Forms.Platform.Android.AppCompat;
using System.ComponentModel;
using Android.Widget;
using Android.Graphics;

[assembly: ExportRenderer(typeof(ButtonEx), typeof(ButtonExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class ButtonExRenderer : ButtonRenderer
    {
        
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