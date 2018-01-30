using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using QZhihuFind.ViewModels.Base;
using QZhihuFind.Services.Interfaces;
using QZhihuFind.Services;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Utils;
using DuGu.XFLib.Controls;
using DuGu.XFLib.Services;
using NuGetTest;
using QZhiHuFind.Pages;

namespace QZhihuFind.ViewModels
{
	public class ArticleContentPageViewModel : ContentPageViewModel
	{

		IArticlePresenter articlePresenter;
		ArticleModel model;

		async Task<bool> RenewDailyUI(ArticleModel model)
		{
			if (model == null || model.Title == null)
				return await Task.FromResult(false);
			var realHtmlBody = "";
			realHtmlBody += "<h1>" + model.Title + "</h1>";
			if (model.TitleImage != "")
				realHtmlBody += $"<img src=\"{model.TitleImage}\" alt=\"标题图片\"/>";
			realHtmlBody += model.Content +
				"<h4>" + "创建于:" + Convert.ToDateTime(model.PublishedTime).ToString("yyyy-MM-dd") + "</h4>";
			return await Task.Run(() =>
			{
				Title = model.Title;
				CssFileName = "article.css";
				HtmlBody = realHtmlBody;
				ProgressBarFinish();
				return true;
			});
		}

		public ArticleContentPageViewModel(int id) : base(id)
		{
			articlePresenter = DependencyService.
				Get<IArticlePresenter>(DependencyFetchTarget.NewInstance);
			InitializeAsync(null);
		}

		public override async Task InitializeAsync(object navigationData)
		{
			if (IsInitialize == true)
				return;
			model = await articlePresenter.GetClientArticle(Id);//从本地数据库获取
			IsProgressing |= await RenewDailyUI(model) == false;
			ProgressBarRunning();
			await Task.Run(async () =>
			{
				if (model.Title == "" ||
					(model.UpdateTime != DateTime.MinValue &&
					model.UpdateTime.AddMinutes(15) < DateTime.Now))
				{
					model = await articlePresenter.GetServiceArticle(Id);
					await RenewDailyUI(model);
					IsProgressing = false;
				}
			});
			IsInitialize = true;
		}

		public async override void OnComments(object obj)
		{
			if (IsInitialize == false)
				return;
			var viewModel = new ArticleCommentsPageViewModel("", Id);
            var page = new ArticleCommentsPage(viewModel);
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
						Title = model.Title,
						Image = model.TitleImage != "" ? model.TitleImage : "ic_placeholder.png",
						DailyOrArticleImage = "form_24dp.png",
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
