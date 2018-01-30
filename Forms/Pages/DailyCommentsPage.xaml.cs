using System;
using System.Collections.Generic;
using QZhihuFind.ViewModels;
using Xamarin.Forms;

namespace QZhiHuFind.Pages
{
    public partial class DailyCommentsPage : ContentPage
    {
        private DailyCommentsPageViewModel viewModel;

        public DailyCommentsPage(DailyCommentsPageViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			this.BindingContext = viewModel;
		}
    }
}
