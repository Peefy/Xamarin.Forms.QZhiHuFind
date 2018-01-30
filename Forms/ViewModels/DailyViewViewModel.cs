using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using Plugin.Connectivity;

using DuGu.XFLib.Models;
using DuGu.XFLib.ViewModels;
using DuGu.XFLib.Services;

using QZhihuFind.Models;
using QZhihuFind.Services.Interfaces;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Services;
using QZhiHuFind.Pages;

namespace QZhihuFind.ViewModels
{
	public class DailyViewViewModel : ListViewModelBase<DailyItem>
	{
		IDailysPresenter dailysPresenter;
		string loadMoreDate;
		int position;
		int positionTemp;
		public int Position
		{
			get => position;
			set => SetProperty(ref position, value);
		}

		public virtual int FlipInternal { get; set; } = 3;

		void RenewDailysUI(DailysModelTotal model)
		{
			if (model == null)
				return;
            var items = new ObservableCollection<FlipViewItem>();
			for (int i = 0; i < 5; ++i)
			{
                items.Add(new FlipViewItem()
                {
                    Tag = i,
                    Image = model.Top_stories[i].Image,
                    Text = model.Top_stories[i].Title,
                    StoryId = model.Top_stories[i].Id,
                    StyleId = i.ToString(),
                });
			}
			FlipSource.ReplaceRange(items);
            Items.Clear();
			LoadMoreDailysUI(model);

		}

		void LoadMoreDailysUI(DailysModelTotal model)
		{
			if (model == null)
				return;
			var lists = new List<DailyItem>();
			foreach (var story in model.Stories)
			{
				lists.Add(new DailyItem()
				{
					Title = story.Title,
					Image = story.Images.FirstOrDefault(),
					StoryId = story.Id,
					GaPrefix = story.Ga_prefix,
					CommentCountString =
						$"{story.extra.popularity} 赞  {story.extra.comments} 评论",
				});
			}
            Items.AddRange(lists);
			loadMoreDate = model.Date;
		}

		public DailyViewViewModel(string title) : base(title)
		{
			dailysPresenter = DependencyService.Get<IDailysPresenter>();
			InitializeAsync();
            Device.StartTimer(TimeSpan.FromSeconds(FlipInternal), () =>
			{
				positionTemp = Position;
				if (++positionTemp > 4)
				{
					positionTemp = 0;
				}
				Position = positionTemp;
				return true;
			});
		}

		public override async Task InitializeAsync()
		{
			if (IsInitialize == true)
				return;
			var model = await dailysPresenter.GetClientDailys();//从本地数据库获取
			RenewDailysUI(model);
			IsBusy = true;
            if (CrossConnectivity.Current.IsConnected == true)
            {
                model = await dailysPresenter.GetServiceDailys(); //从服务器获取
                RenewDailysUI(model);
            }
            else
                DependencyService.Get<IToast>().Show("网络请求失败，请检查网络链接");
			IsInitialize = true;
			IsBusy = false;
		}

        public async override void OnSelectItem(DailyItem item)
		{
			if (item == null)
				return;
			var viewModel = new DailyContentPageViewModel(item.StoryId);
            var page = new DailyContentPage(viewModel);
            await NavigationService.PushAsync(page);
		}

        public async override void OnRefresh(object obj)
		{
			IsBusy = true;

			if (CrossConnectivity.Current.IsConnected == true)
			{
				var model = await dailysPresenter.GetServiceDailys(); //从服务器获取
                if(model == null)
                    DependencyService.Get<IToast>().Show("网络请求失败，请检查网络链接");
				RenewDailysUI(model);
                DependencyService.Get<IToast>().Show("刷新成功！");
			}
			else
				DependencyService.Get<IToast>().Show("网络请求失败，请检查网络链接");

			IsBusy = false;
		}

		bool IsItemsLoadMore;//防止冗余调用
		public async Task OnItemsLoadMore(object obj)
		{
			if (IsBusy == true || IsItemsLoadMore == true || IsInitialize == false)
				return;
			IsItemsLoadMore = true;
			var model = await dailysPresenter.GetServiceDailys(loadMoreDate);//从服务器获取
			LoadMoreDailysUI(model);
			IsItemsLoadMore = false;
		}

        public async override void OnLoadMore(object obj)
        {
            await OnItemsLoadMore(obj);
        }

		#region ImageTapCommand
		public ICommand ImageTapCommand => new Command(OnImageTap);

		async void OnImageTap(object obj)
		{
			if (IsBusy == true)
				return;
			var positon = (int)obj;
			var id = FlipSource[positon].StoryId;
			var viewModel = new DailyContentPageViewModel(id);
            var page = new DailyContentPage(viewModel);
			await NavigationService.PushAsync(page);
		}

		#endregion

		#region FilpSource
		public ObservableCollection<FlipViewItem> FlipSource { get; } = new ObservableCollection<FlipViewItem>()
		{
			new FlipViewItem()
			{
				Image = "ic_placeholder.jpg",
				Text = ""
			},
			new FlipViewItem()
			{
				Image = "ic_placeholder.jpg",
				Text = ""
			},
			new FlipViewItem()
			{
				Image = "ic_placeholder.jpg",
				Text = ""
			},
			new FlipViewItem()
			{
				Image = "ic_placeholder.jpg",
				Text = ""
			},
			new FlipViewItem()
			{
				Image = "ic_placeholder.jpg",
				Text = ""
			},
		};
		#endregion

	}
}