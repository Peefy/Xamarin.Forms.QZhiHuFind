using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using QZhihuFind.Services.Interfaces;
using NuGetTest;
using DuGu.XFLib.Controls;

namespace QZhihuFind.Services
{
	public class DialogService : IDialogService
	{
		public Task ShowAlertAsync(string message, string title, string buttonLabel)
		{
			return Task.Run(() =>
			{

			});
		}

		public async Task ShowAlertAsync(string message)
		{
			var app = Application.Current as App;
			var page = app.MainPage as NavigationPage;
			await page.CurrentPage.DisplayAlert("消息", message, "知道了");
		}

		public Task<bool> ShowAlertAsync(string title, string quest)
		{
			return Task.Run(() =>
			{
				return false;
			});
		}

		public void Toast(string message)
		{
			Task.Run(() =>
			{

			});
		}
	}
}
