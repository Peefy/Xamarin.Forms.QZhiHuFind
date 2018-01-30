using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;

using DuGu.XFLib.Controls;
using DuGu.XFLib.iOS.Renderers;

[assembly: ExportRenderer(typeof(WebViewEx), typeof(WebViewExRenderer))]
namespace DuGu.XFLib.iOS.Renderers
{
    public class WebViewExRenderer : WebViewRenderer
    {
        readonly string LocalResourcePath = NSBundle.MainBundle.BundlePath;
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

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            ControlExtraInit();
            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= NewElement_PropertyChanged;
            }
            if (e.NewElement != null)
            {
                e.NewElement.PropertyChanged += NewElement_PropertyChanged;
            }

        }

        private void NewElement_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
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
            data += "<link type=\"text/css\" rel=\"stylesheet\" href=\"" + Path.Combine(LocalResourcePath, cssFileName) + "\">\n";
            data += HeadEnd + body + "\n" + HtmlEnd;
            this.LoadHtml(data, null);
        }

        public void ControlExtraInit()
        {
            this.ScrollView.ShowsVerticalScrollIndicator = false;
            this.ScrollView.ShowsHorizontalScrollIndicator = false;
        }

    }
}
