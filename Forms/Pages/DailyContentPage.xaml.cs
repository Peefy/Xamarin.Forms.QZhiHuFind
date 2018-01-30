using System;
using System.Collections.Generic;
using QZhihuFind.ViewModels;
using Xamarin.Forms;

namespace QZhiHuFind.Pages
{
    public partial class DailyContentPage : ContentPage
    {
        private DailyContentPageViewModel viewModel;

        public DailyContentPage()
        {
            InitializeComponent();
        }

        public DailyContentPage(DailyContentPageViewModel viewModel)
        {
            this.viewModel = viewModel;
            InitializeComponent();
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
