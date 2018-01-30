using System;
using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public class WebViewEx : WebView
    {
        #region HtmlBody

        public static readonly BindableProperty HtmlBodyProperty =
            BindableProperty.Create("HtmlBody",
                typeof(string),
                typeof(WebViewEx),
                "",
                propertyChanged: null);

        public string HtmlBody
        {
            get { return (string)GetValue(HtmlBodyProperty); }
            set
            {
                SetValue(HtmlBodyProperty, value);
            }
        }

        #endregion

        #region LocalCssFileName

        public static readonly BindableProperty LocalCssFileNameProperty =
            BindableProperty.Create("LocalCssFileName",
                typeof(string),
                typeof(WebViewEx),
                "daily.css",
                propertyChanged: null);

        public string LocalCssFileName
        {
            get { return (string)GetValue(LocalCssFileNameProperty); }
            set
            {
                SetValue(LocalCssFileNameProperty, value);
            }
        }

        #endregion

    }
}
