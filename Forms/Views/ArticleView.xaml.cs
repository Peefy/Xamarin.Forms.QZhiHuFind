using System;
using System.Collections.Generic;
using QZhihuFind.ViewModels;
using Xamarin.Forms;

namespace QZhiHuFind.Views
{
    public partial class ArticleView : ContentView
    {

        ArticleViewViewModel viewModel;

        public ArticleView()
        {
            InitializeComponent();
			viewModel = new ArticleViewViewModel("");
			this.BindingContext = viewModel;
        }

    }
}
