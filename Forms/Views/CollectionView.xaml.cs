using System;
using System.Collections.Generic;
using QZhihuFind.ViewModels;
using Xamarin.Forms;

namespace QZhiHuFind.Views
{
    public partial class CollectionView : ContentView
    {
        public CollectionViewViewModel ViewModel { get; }

        public CollectionView()
        {
            InitializeComponent();
            ViewModel = new CollectionViewViewModel("");
            this.BindingContext = ViewModel;
        }


    }
}
