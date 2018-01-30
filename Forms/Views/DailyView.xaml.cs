using System;
using System.Collections.Generic;
using Xamarin.Forms;

using FFImageLoading.Forms;
using FFImageLoading.Transformations;

using QZhihuFind.ViewModels;

namespace QZhiHuFind.Views
{
    public partial class DailyView : ContentView
    {
        DailyViewViewModel viewModel;
        public DailyView()
        {
            var a = new RoundedTransformation();
            InitializeComponent();
            viewModel = new DailyViewViewModel("");
            this.BindingContext = viewModel;
            CarViewReInit();
        }

        private void CarViewReInit()
        {
			var tap = new TapGestureRecognizer();
			tap.Command = new Command((obj) =>
			{
                if (viewModel.IsBusy == false && viewModel.Items.Count != 0)
				    viewModel.ImageTapCommand.Execute(carView?.Position);
			});
			carView.GestureRecognizers.Add(tap);
            if (Device.RuntimePlatform == Device.Android)
            {
                carView.ItemTemplate = new DataTemplate(() => 
                {
                    var grid = new Grid();
                    var img = new CachedImage() { Aspect = Aspect.AspectFill };
                    img.SetBinding(ClassIdProperty, new Binding("StyleId"));
                    img.SetBinding(CachedImage.SourceProperty,new Binding("Image"));
                    var label = new Label()
                    {
                        Margin = new Thickness(10, 10, 10, 15),
                        VerticalTextAlignment = TextAlignment.End,
                        HorizontalOptions = LayoutOptions.Start,
                        TextColor = Color.White
                    };
                    label.SetBinding(Label.TextProperty, new Binding("Text"));
					grid.Children.Add(img);
                    grid.Children.Add(label);
                    grid.GestureRecognizers.Add(tap);
                    return grid;
                });

            }

        }
    }
}
