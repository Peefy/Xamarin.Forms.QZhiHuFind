using System;

using Android.Widget;

using Xamarin.Forms;

using DuGu.XFLib.Services;
using DuGu.XFLib.Droid.Services;

[assembly: Dependency(typeof(ToastPlatform))]
namespace DuGu.XFLib.Droid.Services
{
    public class ToastPlatform : IToast
    {
        public void Show(string msg, bool longShow = false)
        {
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var toast = Toast.MakeText(Forms.Context, 
                        msg, longShow ? ToastLength.Long : ToastLength.Short);
                    toast.Show();
                    toast.Dispose();
                });
            }
            catch (Exception)
            {

            }
        }
    }
}