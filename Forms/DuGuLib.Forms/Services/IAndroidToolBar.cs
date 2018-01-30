using System;

using Xamarin.Forms;

namespace DuGu.XFLib.Services
{
    public interface IAndroidToolBar
    {
        void SetToolBarMiddleText(string text, Color color);
        void ClearMiddleText();
    }

}
