

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using QZhihuFind.ViewModels.Base;
using QZhihuFind.Models;
using QZhihuFind.Services;
using QZhihuFind.Services.Interfaces;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Utils;

using DuGu.XFLib.Models;
using DuGu.XFLib.ViewModels;
using DuGu.XFLib.Utils;

namespace QZhihuFind.ViewModels
{
	public class DailyCommentsPageViewModel : ListViewModelBase<CommentsItem>, IDisposable
	{
		int offset;
		List<DailyCommentModel> items;
		IDailyCommentPresenter commentPresenter;
		public string IdString { get; set; } = "";

		async Task<bool> RenewDailyCommentUI(List<DailyCommentModel> comments, bool isClear)
		{
			if (comments == null || comments.Count == 0)
				return await Task.FromResult(false);
			if (isClear == true)
				Items.Clear();
            var items_new = new ObservableCollection<CommentsItem>(Items);
			for (int i = offset; i < offset + 10; ++i)
			{
				if (i >= comments.Count)
				{
					offset += 10;
					return false;
				}
				var comment = comments[i];
				var likesCountString = comment.likes > 0 ? comment.likes.ToString() : "";
                items_new.Add(new CommentsItem()
				{
					UserImage = comment.avatar,
					UserName = comment.author,
					LikesCountString = likesCountString,
					Comment = HtmlUtils.ReplaceHtmlTag(comment.content, -1),
					PublishTime = DateTimeUtils.CommonTime(GetTime(comment.time.ToString())),
				});
			}
            Items.ReplaceRange(items_new);
			offset += 10;
			return true;
	
		}

		private DateTime GetTime(string timeStamp)
		{
			DateTime dtStart = new DateTime(1970, 1, 1) + TimeSpan.FromHours(8);
			long lTime = long.Parse(timeStamp + "0000000");
			TimeSpan toNow = new TimeSpan(lTime);
			return dtStart.Add(toNow);
		}

		public DailyCommentsPageViewModel(string title, int id) : base(title)
		{
			Title = "评论";
			IdString = id.ToString();
			items = new List<DailyCommentModel>();
			commentPresenter = DependencyService.Get<IDailyCommentPresenter>();
			InitializeAsync();
		}

		public override async Task InitializeAsync()
		{
			if (IsInitialize == true)
				return;
			await Task.Delay(100);
			var comments = await commentPresenter.GetComment(IdString);
			items = comments;
			if (comments.Count > 0)
				await RenewDailyCommentUI(comments, true);
			else
			{
				IsShowLoadCompleteView = true;
				IsShowLoadingView = false;
			}
			IsInitialize = true;
		}

		public override async void OnRefresh(object obj)
		{
			IsBusy = true;
			if (offset > 0)
				offset = 0;
			var comments = await commentPresenter.GetComment(IdString);
			if (comments.Count > 0)
				await RenewDailyCommentUI(comments, true);
			else
			{
				IsShowLoadCompleteView = true;
                IsShowLoadingView = false;
			}
			IsBusy = false;
		}

		bool IsItemsLoadMore;//防止冗余调用
        public async Task OnItemsLoadMore(object obj)
		{
			if (IsBusy == true || IsItemsLoadMore == true || IsInitialize == false)
				return;
			IsItemsLoadMore = true;
			await Task.Run(async () =>
			{
				if (IsShowLoadCompleteView == true)
					return;
				await Task.Delay(500);
				var result = await RenewDailyCommentUI(items, false);
				IsShowLoadCompleteView = !result;
				IsShowLoadingView = result;
			});
			IsItemsLoadMore = false;
		}

        public async override void OnLoadMore(object obj)
        {
            await OnItemsLoadMore(obj);
        }

		bool isShowLoadingView = true;
		bool isShowLoadCompleteView;

		public bool IsShowLoadingView
		{
			get => isShowLoadingView;
			set => SetProperty(ref isShowLoadingView, value);
		}

		public bool IsShowLoadCompleteView
		{
			get => isShowLoadCompleteView;
			set => SetProperty(ref isShowLoadCompleteView, value);
		}

		#region IDisposable 
		bool disposedValue; // 要检测冗余调用

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (items != null)
					{
						items.Clear();
						items = null;
					}
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
		#endregion

	}
}
