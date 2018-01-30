using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using DuGu.XFLib.Services;
using DuGu.XFLib.iOS.Services;
using DuGu.XFLib.iOS.Controls;

[assembly: Dependency(typeof(ToastPlatform))]
namespace DuGu.XFLib.iOS.Services
{
    public class ToastPlatform : IToast
    {
        public void Show(string msg, bool longShow = false)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var font = UIFont.SystemFontOfSize(12F);

                var lbl = new UILabel()
                {
                    Text = msg,
                    Font = font,
                    TextColor = UIColor.White,
                };

                Toast.Instance.SetContent(lbl);
                Toast.Instance.Show(duration: longShow ? 
                    Toast.Durations.Long : iOS.Controls.Toast.Durations.Short);
            });
        }
    }
}
