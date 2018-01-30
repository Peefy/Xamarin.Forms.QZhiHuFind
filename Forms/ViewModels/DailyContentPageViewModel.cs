using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using QZhihuFind.ViewModels.Base;
using QZhihuFind.Services.Interfaces;
using QZhihuFind.Services;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Utils;
using NuGetTest;
using DuGu.XFLib.Services;
using QZhiHuFind.Pages;

namespace QZhihuFind.ViewModels
{
	public class DailyContentPageViewModel : ContentPageViewModel
	{

		IDailyPresenter dailyPresenter;
		DailyModel model;
		DailyExtraModel modelEx;

		async Task<bool> RenewDailyUI(DailyModel model, DailyExtraModel modelEx)
		{
			if (model == null || modelEx == null || model.title == null)
				return await Task.FromResult(false);
			return await Task.Run(() =>
			{
				Title = model.title;
				CssFileName = "daily.css";
				HtmlBody = model.body.Replace("img-place-holder", "img-place-holder1");
				ProgressBarFinish();
				return true;
			});

		}

		public DailyContentPageViewModel(int id) : base(id)
		{
			dailyPresenter = DependencyService.Get<DailyPresenter>();
			InitializeAsync(null);
		}

		public override async Task InitializeAsync(object navigationData)
		{
			if (IsInitialize == true)
				return;
			model = await dailyPresenter.GetClientDaily(Id);//从本地数据库获取
			modelEx = await dailyPresenter.GetClientDailyExtra(Id);//从本地数据库获取
			IsProgressing |= await RenewDailyUI(model, modelEx) == false;
			ProgressBarRunning();
			if (model.title == "" || model.updatetime.AddMinutes(15) < DateTime.Now)
			{
				model = await dailyPresenter.GetServiceDaily(Id);
				modelEx = await dailyPresenter.GetServiceDailyExtra(Id);
				await RenewDailyUI(model, modelEx);
				IsProgressing = false;
			}
			IsInitialize = true;
		}

		public async override void OnComments(object obj)
		{
			if (IsInitialize == false)
				return;
			var viewModel = new DailyCommentsPageViewModel("", Id);
            var page = new DailyCommentsPage(viewModel);
			await NavigationService.PushAsync(page);
		}

        public async override void OnCollection(object obj)
		{
			if (IsInitialize == false)
				return;
			if (model == null)
				return;
			if (IsCollected == false)
			{
				if (SQLiteUtils.Instance.UpdateCollection(
					new Models.SQLiteModels.CollectionModel()
					{
						IdOrSlug = Id,
						Title = model.title,
						Image = model.image != "" ? model.image : "ic_placeholder.png",
						DailyOrArticleImage = "daily_24dp.png",
					}) == true)
				{
					await Application.Current.MainPage.DisplayAlert("消息", "收藏成功", "知道了");
				}
				IsCollected = true;
			}
			else
			{
				SQLiteUtils.Instance.DeleteCollection(Id);
				IsCollected = false;
			}
			CollectionToolBarText = IsCollected == false ? "收藏" : "取消";
			var app = Application.Current as App;
			//if (app.RootPage.CollectionView.
			//	BindingContext is CollectionViewViewModel viewModel)
			//{
			//	viewModel.OnRefresh(null);
			//}
		}

	}
}
