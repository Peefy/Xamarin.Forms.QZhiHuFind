using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;

using Xamarin.Forms;

using QZhihuFind.ViewModels.Base;
using QZhihuFind.Models;
using QZhihuFind.Services;
using QZhihuFind.Services.Interfaces;
using QZhihuFind.Models.SQLiteModels;
using QZhihuFind.Models.JsonModels;
using QZhihuFind.Utils;

using DuGu.XFLib.Models;
using DuGu.XFLib.ViewModels;
using DuGu.XFLib.Utils;

namespace QZhihuFind.ViewModels
{
	public class ArticleCommentsPageViewModel : ListViewModelBase<CommentsItem>
	{

		int offset = 0;
		IArticleCommentPresenter articleCommentPresenter;

		public int Slug { get; set; } = 0;

		async Task<bool> RenewArticleCommentUI(List<ArticleCommentModel> comments, bool isClear)
		{
			if (comments == null || comments.Count == 0)
				return await Task.FromResult(false);
			if (isClear == true)
				Items.Clear();
            var items = new ObservableCollection<CommentsItem>(Items);
			await Task.Run(()=>
			{
				foreach (var comment in comments)
				{
					var likesCountString = comment.likesCount > 0 ? comment.likesCount.ToString() : "";
					var avatar = comment.author.Avatar.Template.
						Replace("{id}", comment.author.Avatar.Id);
					avatar = avatar.Replace("{size}", "s");
                    items.Add(new CommentsItem()
					{
						UserImage = avatar,
						UserName = comment.author.Name,
						LikesCountString = likesCountString,
						Comment = HtmlUtils.ReplaceHtmlTag(comment.content, -1),
						PublishTime = DateTimeUtils.
							CommonTime(System.Convert.ToDateTime(comment.createdTime)),
					});
				}
				offset += comments.Count;
			});
            Items.ReplaceRange(items);
            return await Task.FromResult(true);
		}

		public ArticleCommentsPageViewModel(string title, int slug) : base(title)
		{
			Title = "评论";
			Slug = slug;
			articleCommentPresenter = DependencyService.
				Get<IArticleCommentPresenter>(DependencyFetchTarget.NewInstance);
			InitializeAsync();
		}

		public override async Task InitializeAsync()
		{
			if (IsInitialize == true)
				return;
			await Task.Delay(100);
			await Task.Run(async () =>
			{
				var comments = await articleCommentPresenter.GetComment(Slug, offset);
				if (comments.Count > 0)
					await RenewArticleCommentUI(comments, false);
				else
				{
					IsShowLoadCompleteView = true;
					IsShowLoadingView = false;
				}

			});
			IsInitialize = true;
		}

		public override async void OnRefresh(object obj)
		{
			IsBusy = true;
			if (offset > 0)
				offset = 0;
			await Task.Run(async () =>
			{
				var comments = await articleCommentPresenter.GetComment(Slug, offset);
				if (comments.Count > 0)
					await RenewArticleCommentUI(comments, false);
				else
				{
					IsShowLoadCompleteView = true;
					IsShowLoadingView = false;
				}
			});
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
				var comments = await articleCommentPresenter.GetComment(Slug, offset);
				if (comments.Count > 0)
					await RenewArticleCommentUI(comments, false);
				else
				{
					IsShowLoadCompleteView = true;
					IsShowLoadingView = false;
				}
			});
			IsItemsLoadMore = false;
		}

        public async override void OnLoadMore(object obj)
        {
            await OnItemsLoadMore(obj);
        }

		bool isShowLoadingView = true;
		bool isShowLoadCompleteView = false;

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

	}
}