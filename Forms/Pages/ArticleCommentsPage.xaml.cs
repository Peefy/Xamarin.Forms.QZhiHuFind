using System;
using System.Collections.Generic;
using QZhihuFind.ViewModels;
using Xamarin.Forms;

namespace QZhiHuFind.Pages
{
    public partial class ArticleCommentsPage : ContentPage
    {
		private ArticleCommentsPageViewModel viewModel;

		public ArticleCommentsPage()
		{
			InitializeComponent();
		}

		public ArticleCommentsPage(ArticleCommentsPageViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			this.BindingContext = viewModel;
		}
    }
}
