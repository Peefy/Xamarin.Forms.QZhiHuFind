
using Xamarin.Forms;

using FFImageLoading.Transformations;

using QZhiHuFind.Pages;

namespace NuGetTest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new RootPage());
          
        }

    }
}
