using System;
using UIKit;
using Xamarin.Forms;

using DuGu.XFLib.Services;

[assembly: Dependency(typeof(DuGu.XFLib.iOS.Services.KeyBoard))]
namespace DuGu.XFLib.iOS.Services
{
    public class KeyBoard : IKeyBoard
    {

        public void HideKeyboard()
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }
    }
}
