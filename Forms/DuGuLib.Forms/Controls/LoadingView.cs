using System;

using Xamarin.Forms;

using DuGu.XFLib.Platform;

namespace DuGu.XFLib.Controls
{
    public class LoadingView : ContentView
    {
        Grid totalGrid;
        StackLayout isLoadingStackLayout;
        StackLayout isNotLoadStackLayout;
        ActivityIndicator indicator;
        Label isLoadingLabel;
        Label isNotLoadLabel;

        readonly string LoadingText = "加载中...";
        readonly string IsNotLoadText = "没有更多内容";

        public LoadingView()
        {
            InitUI();
        }

        private void InitUI()
        {
            indicator = new ActivityIndicator()
            {
				HeightRequest = 20,
                WidthRequest = 20,
                IsRunning = true,
                VerticalOptions = LayoutOptions.Center,		
            };
            isLoadingLabel = new Label()
            {
                FontSize = CustomFontSize.MediumSize,
                Text = LoadingText,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
            };
            isLoadingStackLayout = new StackLayout()
            {
                Margin = new Thickness(0,6,0,6),
                HorizontalOptions = LayoutOptions.Center,
                IsVisible = IsLoading,
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Children = 
                {
                    indicator,isLoadingLabel,
                },
            };

            isNotLoadLabel = new Label()
            {
                FontSize = CustomFontSize.MediumSize,
                Text = IsNotLoadText,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
			};
            isNotLoadStackLayout = new StackLayout()
            {
				Margin = new Thickness(0, 6, 0, 6),
				HorizontalOptions = LayoutOptions.Center,
				IsVisible = !IsLoading,
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
                    isNotLoadLabel
				},
            };

            totalGrid = new Grid()
            {
                Children = {isLoadingStackLayout,isNotLoadStackLayout},
            };

            Content = totalGrid;

        }

        #region IsLoading

        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create("IsLoading",
                typeof(bool),typeof(LoadingView),
                true,
                propertyChanged: IsLoadingPropertyChanged);

        private static void IsLoadingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoadingView)bindable;
            var isLoading = (bool)newValue;
            control.isLoadingStackLayout.IsVisible = isLoading;
            control.isNotLoadStackLayout.IsVisible = !isLoading;

        }
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set
            {
                SetValue(IsLoadingProperty, value);
            }
        }

        #endregion
    }
}
