
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuGu.XFLib.Services
{
	public static class NavigationService
	{
		public async static Task PushAsync(Page page)
		{
			await Application.Current.MainPage.Navigation.PushAsync(page);
		}

		public async static Task PopAsync(Page page)
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}

		public async static Task PopToRootAsync(Page page)
		{
			await Application.Current.MainPage.Navigation.PopToRootAsync();
		}

	}
}
