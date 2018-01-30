using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using DuGu.XFLib.Models;
using DuGu.XFLib.Services;
using DuGu.XFLib.ViewModels;

using QZhihuFind.Models;
using QZhihuFind.Services.Interfaces;
using QZhihuFind.Models.SQLiteModels;
using QZhihuFind.Utils;
using QZhiHuFind.Pages;

namespace QZhihuFind.ViewModels
{
	public class CollectionViewViewModel : ListViewModelBase<CollectionItem>
	{

		ICollectionService collectionService;

		async Task RenewCollectionUI(List<CollectionModel> models)
		{
			ObservableCollection<CollectionItem> items =
				new ObservableCollection<CollectionItem>();
			await Task.Run(() =>
			{
				foreach (var model in models)
				{
					items.Add(new CollectionItem()
					{
						Image = model.Image,
						Title = model.Title,
						IdOrSlug = model.IdOrSlug,
						DailyOrArticleImage = model.DailyOrArticleImage,
						DailyOrArticleText = model.DailyOrArticleImage == "daily_24dp.png" ?
							"日报" : "文章",
					});
				}
                Items.ReplaceRange(items);
			});

		}

		public CollectionViewViewModel(string title) : base(title)
		{
			collectionService = DependencyService.Get<ICollectionService>();
			InitializeAsync();
		}

		public override async Task InitializeAsync()
		{
			if (IsInitialize == true)
				return;
			await Task.Run(async () =>
			{
				var models = SQLiteUtils.Instance.QueryAllCollections();
				await RenewCollectionUI(models);
			});
			IsInitialize = true;
		}

		public override async void OnSelectItem(CollectionItem item)
		{
			if (item == null)
				return;
			if (IsBusy == true || IsInitialize == false)
				return;
			if (item.DailyOrArticleImage == "daily_24dp.png")
			{
				var viewModel = new DailyContentPageViewModel(item.IdOrSlug);
                var page = new DailyContentPage(viewModel);
				await NavigationService.PushAsync(page);
			}
			else
			{
				var viewModel = new ArticleContentPageViewModel(item.IdOrSlug);
                var page = new ArticleContentPage(viewModel);
				await NavigationService.PushAsync(page);
			}

		}

		public override async void OnRefresh(object obj)
		{
			IsBusy = true;
			await Task.Delay(100);
			await Task.Run(async () =>
			{
				var models = SQLiteUtils.Instance.QueryAllCollections();
				await RenewCollectionUI(models);
			});
			IsBusy = false;
		}

        public async Task Refresh()
        {
			await Task.Run(async () =>
			{
				var models = SQLiteUtils.Instance.QueryAllCollections();
				await RenewCollectionUI(models);
			});
        }

        public async Task ClearAllCollections()
		{
            await Task.Run(() =>
			{
				SQLiteUtils.Instance.DeleteAllCollections();
			});
			Items.Clear();
		}

	}
}