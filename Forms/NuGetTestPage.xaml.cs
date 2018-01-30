using Xamarin.Forms;

using Newtonsoft.Json;
using System.Net.Http;
using ModernHttpClient;

namespace NuGetTest
{
    public partial class NuGetTestPage : ContentPage
    {

        HttpClient httpClient;
		public const string ZhuanlanHost = "https://zhuanlan.zhihu.com/api";
		public const string DailyHost = "https://news-at.zhihu.com/api/4";

        public NuGetTestPage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.MainViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new NuGetTestPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            httpClient = new HttpClient(new NativeMessageHandler());
            var str = await httpClient.GetStringAsync(DailyHost + "/news/latest");
            QZhihuFind.Utils.SQLiteUtils.Instance.JudgeExistCollection(123);
            label.Text = str;

        }

    }
}
