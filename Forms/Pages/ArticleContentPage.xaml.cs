using System;
using System.Collections.Generic;
using QZhihuFind.ViewModels;
using Xamarin.Forms;

namespace QZhiHuFind.Pages
{
    public partial class ArticleContentPage : ContentPage
    {
		private ArticleContentPageViewModel viewModel;

		public ArticleContentPage()
		{
			InitializeComponent();
		}

		public ArticleContentPage(ArticleContentPageViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			this.BindingContext = viewModel;
		}

		private void CommentsToolbarItemClicked(object sender, EventArgs e)
		{
			viewModel.CommentsCommand.Execute(null);
		}

		private void CollectionToolbarItemClicked(object sender, EventArgs e)
		{
			viewModel.CollectionCommand.Execute(null);
		}
    }
}
