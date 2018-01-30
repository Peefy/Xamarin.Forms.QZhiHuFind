using System;

using Android.App;
using Android.Content;
using Android.Views.InputMethods;

using Xamarin.Forms;

using DuGu.XFLib.Services;

[assembly: Dependency(typeof(DuGu.XFLib.Droid.Services.KeyBoard))]
namespace DuGu.XFLib.Droid.Services
{
    public class KeyBoard : IKeyBoard
    {
        public void HideKeyboard()
        {
            var context = Forms.Context;
            var inputMedthodManager = context.GetSystemService(Context.InputService) as InputMethodManager;
            if(inputMedthodManager != null && context is Activity)
            {
                var activity = context as Activity;
                var token = activity.CurrentFocus?.WindowToken;
                inputMedthodManager.HideSoftInputFromWindow(token,HideSoftInputFlags.None);
                activity.Window.DecorView.ClearFocus();
            }
        }
    }
}
