using System;
using System.Collections.Generic;
using Xamarin.Forms;

using DuGu.XFLib.Binders;
using DuGu.XFLib.Services;
using DuGu.XFLib.Controls.TabViewControls;

using QZhiHuFind.Views;
using QZhihuFind.ViewModels;

namespace QZhiHuFind.Pages
{
    public class RootPage : ContentPage
    {
		int index = 0;
		readonly Color TabBarColorFilter = Color.FromHex("#2196F3");

		readonly string[] TabBarText =
		{
			"日报",
			"文章",
			"收藏",
		};

		List<TabViewChildren> Children { get; set; }

		public DailyView DailyView { get; set; }
		public ArticleView ArticleView { get; set; }
		public CollectionView CollectionView { get; set; }
        public TabView MainTabView { get; set; }

        public RootPage()
        {

            MainTabView = new TabView();
			DailyView = new DailyView();
			ArticleView = new ArticleView();
			CollectionView = new CollectionView();

            AndroidToolBarBinder.SetMiddleText(this,TabBarText[index]);

			Children = new List<TabViewChildren>()
			{
				new TabViewChildren()
				{
					Text = TabBarText[0],
                    UnSelectTextColor = Color.Gray,
					UnSelectImageSource = "daily_24dp.png",
                    SelectedImageSource = "daily_24dp.png",
					SelectedTextColor = TabBarColorFilter,
                    UnSelectImageColorFilter = Color.Gray,
                    SelectedImageColorFilter = TabBarColorFilter,
					View = DailyView,
				},
				new TabViewChildren()
				{
					Text = TabBarText[1],
                    UnSelectTextColor = Color.Gray,
					UnSelectImageSource = "form_24dp.png",
                    SelectedImageSource = "form_24dp.png",
					SelectedTextColor = TabBarColorFilter,
					UnSelectImageColorFilter = Color.Gray,
					SelectedImageColorFilter = TabBarColorFilter,
					View = ArticleView,
				},
				new TabViewChildren()
				{
					Text = TabBarText[2],
                    UnSelectTextColor = Color.Gray,
					UnSelectImageSource = "collection_24dp.png",
                    SelectedImageSource = "collection_24dp.png",
					SelectedTextColor = TabBarColorFilter,
					UnSelectImageColorFilter = Color.Gray,
					SelectedImageColorFilter = TabBarColorFilter,
					View = CollectionView,
				},
			};
            MainTabView.AddChildrenViews(Children);
            MainTabView.SelectedChanged += Handle_SelectedChanged;

            Content = MainTabView;

        }

        async void Handle_SelectedChanged(object sender, TabViewChangedEventArgs e)
		{
			index = e.Index;
            AndroidToolBarBinder.SetMiddleText(this,TabBarText[index]);
			if (index == 2)
			{
				var toolBar = new ToolbarItem()
				{
					Text = "清空"
				};
				toolBar.Clicked += ToolBar_Clicked;
				this.ToolbarItems.Add(toolBar);
                await CollectionView.ViewModel.Refresh();
			}
			else
			{
				if (this.ToolbarItems.Count == 0)
					return;
				this.ToolbarItems[0].Clicked -= ToolBar_Clicked;
				this.ToolbarItems.Clear();
			}
		}

		private async void ToolBar_Clicked(object sender, System.EventArgs e)
		{
			if (CollectionView.BindingContext is CollectionViewViewModel viewModel)
			{
				if (await this.DisplayAlert("提示", "是否清空全部收藏", "确定", "取消") == true)
                {
                    await viewModel.ClearAllCollections();
                }
			}
		}

		/// <summary>
		/// back按钮按下时，iOS没有back按钮，不做特殊处理
		/// </summary>
		/// <returns></returns>
		protected override bool OnBackButtonPressed()
		{
			if (Device.RuntimePlatform == Device.Android)
				DependencyService.Get<IAndroidFinish>().SleepButNotFinish();
			return true;
		}

    }
}

