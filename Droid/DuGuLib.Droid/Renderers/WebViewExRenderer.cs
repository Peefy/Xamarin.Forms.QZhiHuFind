using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using DuGu.XFLib.Droid.Renderers;
using DuGu.XFLib.Controls;
using System.ComponentModel;
using System.IO;
using Android.Webkit;

[assembly: ExportRenderer(typeof(WebViewEx), typeof(WebViewExRenderer))]
namespace DuGu.XFLib.Droid.Renderers
{
    public class WebViewExRenderer : WebViewRenderer
    {

        private const string LocalAssetPath = "file:///android_asset/";
        private const string HtmlBegin = "" +
            "<!DOCTYPE html>\n" +
            "<html>\n";
        private const string HeadBegin = "" +
            "<head>\n" +
            "<meta charset=\"UTF-8\">\n" +
            "<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,maximum-scale=1\">\n";
        private const string HeadEnd = "" +
                "</head>\n" +
                "<body>\n";
        private const string HtmlEnd = "" +
                "</body>\n" +
                "</html>";

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            ControlExtraInit();
            LoadRenderedContent();
        }

        public void ControlExtraInit()
        {
            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.DomStorageEnabled = true;
            Control.Settings.CacheMode = CacheModes.CacheElseNetwork;
            Control.HorizontalScrollBarEnabled = false;
            Control.VerticalScrollBarEnabled = false;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == WebViewEx.LocalCssFileNameProperty.PropertyName ||
                e.PropertyName == WebViewEx.HtmlBodyProperty.PropertyName)
            {
                LoadRenderedContent();
            }
        }

        private void LoadRenderedContent()
        {
            var webViewEx = Element as WebViewEx;
            var body = webViewEx.HtmlBody;
            var cssFileName = webViewEx.LocalCssFileName;

            if (body == "" || cssFileName == "")
                return;

            var data = HtmlBegin + HeadBegin;
            data += "<link type=\"text/css\" rel=\"stylesheet\" href=\"" + Path.Combine(LocalAssetPath, cssFileName) + "\">\n";
            data += HeadEnd + "<div class=\"post-content\">" + body + "</div>\n" + HtmlEnd;
            Control.LoadDataWithBaseURL(null, data, "text/html", "utf-8", null);
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