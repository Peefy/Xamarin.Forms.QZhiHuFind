using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using DuGu.XFLib.ViewModels;
using DuGu.XFLib.Models;
using DuGu.XFLib.Utils;
using DuGu.XFLib.Services;

using QZhihuFind.Models;
using QZhihuFind.Services;
using QZhihuFind.Services.Interfaces;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Utils;
using QZhiHuFind.Pages;

namespace QZhihuFind.ViewModels
{
	public class ArticleViewViewModel : ListViewModelBase<ArticleItem>
	{

		int offset;
		readonly IArticlesPresenter articlesPresenter;

		void RenewArticlesUI(List<ArticleModel> models, bool isRefresh)
		{
			if (models == null)
				return;
			if (models.Count <= 0)
				return;
			if (isRefresh == true)
				Items.Clear();
            var items = new ObservableCollection<ArticleItem>(Items);
			foreach (var model in models)
			{
				string avatar = "";
				if (model.Author.Avatar != null && model.Author.Avatar.Template != null && model.Author.Avatar.Id != null)
				{
					avatar = model.Author.Avatar.Template.Replace("{id}", model.Author.Avatar.Id);
					avatar = avatar.Replace("{size}", "s");
				}
				string badgeImage = "";
				if (model.Author.IsOrg)
				{
					badgeImage = "identity.png";
				}
				else if (model.Author.Badge != null)
				{
					if (model.Author.Badge.Identity != null)
						badgeImage = "identity.png";
					else if (model.Author.Badge.Best_answerer != null)
						badgeImage = "bestanswerer.png";
				}
                items.Add(new ArticleItem()
				{
					Title = model.Title,
					Slug = model.Slug,
					UserImage = avatar,
					UserName = model.Author.Name,
					TitleImage = model.TitleImage,
					BadgeImage = badgeImage,
					UpdateTimeString = DateTimeUtils.CommonTime(Convert.ToDateTime(model.PublishedTime)),
					Summary = HtmlUtils.ReplaceHtmlTag(model.Content, 70) + "...",
					IsHasTitleImage = model.TitleImage != "",
				});
			}
            Items.ReplaceRange(items);
			offset += Items.Count;
		}

		public ArticleViewViewModel(string title) : base(title)
		{
			articlesPresenter = DependencyService.
				Get<IArticlesPresenter>();
			InitializeAsync();
		}

		public override async Task InitializeAsync()
		{
			if (IsInitialize == true)
				return;
			var models = await articlesPresenter.GetClientArticles();//从本地数据库获取
			RenewArticlesUI(models, true);
			IsBusy = true;
		    models = await articlesPresenter.GetServiceArticles(offset); //从服务器获取
			RenewArticlesUI(models, true);
			IsInitialize = true;
			IsBusy = false;
		}

		public override async void OnSelectItem(ArticleItem item)
		{
			if (item == null)
				return;
			var viewModel = new ArticleContentPageViewModel(item.Slug);
            var page = new ArticleContentPage(viewModel);
			await NavigationService.PushAsync(page);

		}

		public async override void OnRefresh(object obj)
		{
			IsBusy = true;
			if (offset > 0)
				offset = 0;
			var models = await articlesPresenter.GetServiceArticles(offset);//从服务器获取
            if(models != null && models.Count != 0)
            {
                DependencyService.Get<IToast>().Show("刷新成功！");
            }
            else
            {
                DependencyService.Get<IToast>().Show("刷新超时！请检查网络设置");
            }
			RenewArticlesUI(models, true);
			IsBusy = false;
		}

		bool IsItemsLoadMore;//防止冗余调用
        public async Task OnItemsLoadMore(object obj)
		{
			if (IsBusy == true || IsItemsLoadMore == true || IsInitialize == false)
				return;
			IsItemsLoadMore = true;
			var models = await articlesPresenter.GetServiceArticles(offset);//从服务器获取
			RenewArticlesUI(models, false);
			IsItemsLoadMore = false;
		}

        public async override void OnLoadMore(object obj)
        {
            await OnItemsLoadMore(obj);
        }

	}
}