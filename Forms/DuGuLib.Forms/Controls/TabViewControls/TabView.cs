using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using DuGu.XFLib.Behaviors;

namespace DuGu.XFLib.Controls.TabViewControls
{
    public class TabView : Grid , IDisposable
    {
        #region UI

        Grid viewGroup;
        Grid tabbarGrid;
        BoxView boxView;
        Grid grid;

		#endregion

		List<ContentView> Views;
		List<RadioBehavior> RadioBehaviors;

        public TabView()
        {
            InitUI();
			Views = new List<ContentView>();
			RadioBehaviors = new List<RadioBehavior>();
        }

		public TabView(IList<TabViewChildren> Children)
		{
            InitUI();

			Views = new List<ContentView>();
			RadioBehaviors = new List<RadioBehavior>();

			for (int i = 0; i < Children.Count; ++i)
			{
				grid.ColumnDefinitions.Add(new ColumnDefinition());
				RadioBehavior radioBehavior = new RadioBehavior() { IsChecked = i == 0 };
				TabViewChildren children = Children[i];
				Views.Add(children.View);
				RadioBehaviors.Add(radioBehavior);

				var tabbedView = new TabbedImageLabelView(children, radioBehavior)
				{
					Margin = new Thickness(0, 3, 0, 0),
				};

				tabbedView.IndexSelectedChanged += (sendor, e) =>
				{
					var view = sendor as TabbedImageLabelView;
					int index = RadioBehaviors.IndexOf(view.RadioBehavior);
					SelectedChanged?.Invoke(this,
						new TabViewChangedEventArgs(index, Children[index].View));
				};

				grid.Children.Add(tabbedView);
				viewGroup.Children.Add(children.View);
				SetColumn(tabbedView, i);
			}
		}

		public void AddChildrenViews(IList<TabViewChildren> Children)
		{
			grid.Children.Clear();
			grid.ColumnDefinitions.Clear();
			Views.Clear();
			RadioBehaviors.Clear();

			for (int i = 0; i < Children.Count; ++i)
			{
				grid.ColumnDefinitions.Add(new ColumnDefinition());
				RadioBehavior radioBehavior = new RadioBehavior() { IsChecked = i == 0 };
				TabViewChildren children = Children[i];
				Views.Add(children.View);
				RadioBehaviors.Add(radioBehavior);
				var tabbedView = new TabbedImageLabelView(children, radioBehavior)
				{
					Margin = new Thickness(0, 3, 0, 0),
				};
				tabbedView.IndexSelectedChanged += (sendor, e) =>
				{
					var view = sendor as TabbedImageLabelView;
					int index = RadioBehaviors.IndexOf(view.RadioBehavior);
					SelectedChanged?.Invoke(this,
						new TabViewChangedEventArgs(index, ChildrenViews[index]));
				};

				grid.Children.Add(tabbedView);
				viewGroup.Children.Add(children.View);
				SetColumn(tabbedView, i);
			}
		}

        public void SetSelectedIndex(int index)
        {
            if (index < 0 || index > RadioBehaviors.Count - 1)
                throw new IndexOutOfRangeException();
            RadioBehaviors[index].IsChecked = true;
        }

        private void InitUI()
        {

            boxView = new BoxView()
            {
                HeightRequest = 1,
                HorizontalOptions = LayoutOptions.Fill,
                Color = Color.FromHex("#eff0dc"),
            };

            grid = new Grid()
            {
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.Fill,
            };

            tabbarGrid = new Grid()
            {
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.Fill,
                RowSpacing = 0,
                VerticalOptions = LayoutOptions.End,
                RowDefinitions =
                {
                    new RowDefinition(){Height = 1},
                    new RowDefinition(){Height = 59},
                },
                Children = 
                {
                    boxView,
                    grid,
                },
            };
            Grid.SetRow(boxView,0);
            Grid.SetRow(grid,1);

            viewGroup = new Grid();

            RowSpacing = 0;
			RowDefinitions.Add(new RowDefinition());
			RowDefinitions.Add(new RowDefinition() { Height = 60 });
            Children.Add(viewGroup);
            Children.Add(tabbarGrid);
            Grid.SetRow(viewGroup,0);
            Grid.SetRow(tabbarGrid,1);

		}

		#region 事件
		public event EventHandler<TabViewChangedEventArgs> SelectedChanged;
		#endregion

		#region 属性

		#region TabLineColor

		public static readonly BindableProperty TabLineColorProperty =
			BindableProperty.Create("TabLineColor",
				typeof(Color),
				typeof(TabView),
				Color.FromHex("#eff0dc"),
				propertyChanged: TabLineColorPropertyChanged);

		private static void TabLineColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tab = (TabView)bindable;
            tab.boxView.Color = (Color)newValue;
		}
		public Color TabLineColor
		{
			get { return (Color)GetValue(TabLineColorProperty); }
			set
			{
				SetValue(TabLineColorProperty, value);
			}
		}

		#endregion

		#region TabBarColor

		public static readonly BindableProperty TabBarColorProperty =
			BindableProperty.Create("TabBarColor",
				typeof(Color),
				typeof(TabView),
				Color.White,
				propertyChanged: TabBarColorPropertyChanged);

		private static void TabBarColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tab = (TabView)bindable;
			tab.grid.BackgroundColor = (Color)newValue;

		}
		public Color TabBarColor
		{
			get { return (Color)GetValue(TabBarColorProperty); }
			set
			{
				SetValue(TabBarColorProperty, value);
			}
		}

		#endregion

		#region TabBarHeight

		public static readonly BindableProperty TabBarHeightProperty =
			BindableProperty.Create("TabBarHeight",
				typeof(int),
				typeof(TabView),
				60,
				propertyChanged: TabBarHeightPropertyChanged);

		private static void TabBarHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tab = (TabView)bindable;
			tab.RowDefinitions[1].Height = (int)newValue;
			tab.tabbarGrid.RowDefinitions[1].Height = (int)newValue - 1;

		}
		public int TabBarHeight
		{
			get { return (int)GetValue(TabBarHeightProperty); }
			set
			{
				SetValue(TabBarHeightProperty, value);
			}
		}

		#endregion

		#region TabBarVisible

		public static readonly BindableProperty TabBarVisibleProperty =
			BindableProperty.Create("TabBarVisible",
				typeof(bool),
				typeof(TabView),
				true,
				propertyChanged: TabBarVisiblePropertyChanged);

		private static void TabBarVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tab = (TabView)bindable;
			tab.tabbarGrid.IsVisible = (bool)newValue;

		}
		public bool TabBarVisible
		{
			get { return (bool)GetValue(TabBarVisibleProperty); }
			set
			{
				SetValue(TabBarVisibleProperty, value);
			}
		}

		public Grid TabBar => grid;

		#endregion

		#region ChildrenView

		public List<ContentView> ChildrenViews => Views;

		#endregion

		#endregion

		#region Dispose

		public virtual void Dispose(bool isDisposing)
        {
            this.Dispose();
        }

        public void Dispose()
        {
            
        }

        #endregion

    }
}
