using System;

using Xamarin.Forms;

using DuGu.XFLib.Behaviors;
using DuGu.XFLib.Controls;

namespace DuGu.XFLib.Controls.TabViewControls
{
    public class TabbedImageLabelView : ContentView ,IDisposable
    {
		string labelText = "主页";
		Color labelColor = Color.Gray;		
		TabViewChildren tabViewChildren;

        public RadioBehavior RadioBehavior { get; set; }
		public event EventHandler<EventArgs> IndexSelectedChanged;

        #region UI
        Grid grid;
        ImageEx image;
        Label label;
        #endregion

        public TabbedImageLabelView(TabViewChildren tabViewChildren,RadioBehavior radioBehavior)
        {
            InitUI();
            this.tabViewChildren = tabViewChildren;
            this.RadioBehavior = radioBehavior;
            this.Behaviors.Add(radioBehavior);

			this.grid.RowDefinitions[0].Height = tabViewChildren.ImageSize.Height;
			this.image.HeightRequest = tabViewChildren.ImageSize.Height;
			this.image.WidthRequest = tabViewChildren.ImageSize.Width;
			this.label.FontSize = tabViewChildren.TextFontSize;
            this.LabelColor = tabViewChildren.UnSelectTextColor;
			this.LabelText = tabViewChildren.Text;
			this.ImageSource = tabViewChildren.UnSelectImageSource;
            this.ColorFilter = tabViewChildren.UnSelectImageColorFilter;

			var dataTrigger = new DataTrigger(typeof(TabbedImageLabelView))
			{
                Binding = new Binding("IsChecked",BindingMode.TwoWay)
				{
					Source = radioBehavior,
					Path = "IsChecked",
				},
				Value = true,
			};
			dataTrigger.Setters.Add(new Setter()
			{
				Property = LabelColorProperty,
				Value = tabViewChildren.SelectedTextColor
			});

			dataTrigger.Setters.Add(new Setter()
			{
				Property = ImageSourceProperty,
				Value = tabViewChildren.SelectedImageSource,
			});

			dataTrigger.Setters.Add(new Setter()
			{
				Property = ColorFilterProperty,
				Value = tabViewChildren.SelectedImageColorFilter,
			});

			this.Triggers.Add(dataTrigger);

			tabViewChildren.View.SetBinding(IsVisibleProperty, new Binding()
			{
				Source = radioBehavior,
				Path = "IsChecked"
			});

        }

        private void InitUI()
        {
            
            image = new ImageEx()
            {
                HeightRequest = 25,
                WidthRequest = 25,
                HorizontalOptions = LayoutOptions.Center,
            };

            label = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                Text = "Tab0",
                TextColor = Color.Gray,
            };

            grid = new Grid()
            {
                RowSpacing = 2,
                RowDefinitions = 
                {
                    new RowDefinition() { Height = 25 },
                    new RowDefinition()
                }
            };
            grid.Children.Add(image);
            grid.Children.Add(label);
            Grid.SetRow(image,0);
            Grid.SetRow(label,1);

			HorizontalOptions = LayoutOptions.Fill;
			VerticalOptions = LayoutOptions.Center;
            Content = grid;

        }

		#region LabelColor

		public static readonly BindableProperty LabelColorProperty =
			BindableProperty.Create("LabelColor",
				typeof(Color),
				typeof(TabbedImageLabelView),
				Color.Gray,
				propertyChanged: LabelColorPropertyChanged);

		private static void LabelColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tab = (TabbedImageLabelView)bindable;
			tab.label.TextColor = (Color)newValue;

		}
		public Color LabelColor
		{
			get { return (Color)GetValue(LabelColorProperty); }
			set
			{
				SetValue(LabelColorProperty, value);
			}
		}
		#endregion

		#region LabelText
		public string LabelText
		{
			get { return labelText; }
			set
			{
				labelText = value;
				label.Text = labelText;
			}
		}
		#endregion

		#region ImageSource
		public static readonly BindableProperty ImageSourceProperty =
			BindableProperty.Create("ImageSource",
		typeof(string),
		typeof(TabbedImageLabelView),
		"",
		propertyChanged: ImageSourcePropertyChanged);

		private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tab = (TabbedImageLabelView)bindable;
			tab.image.Source = (string)newValue;
		}

		public string ImageSource
		{
			get { return (string)GetValue(ImageSourceProperty); }
			set
			{
				SetValue(ImageSourceProperty, value);
			}
		}
		#endregion

		#region ColorFilter
		public static readonly BindableProperty ColorFilterProperty =
			BindableProperty.Create("ColorFilter",
		typeof(Color),
		typeof(TabbedImageLabelView),
		Color.Default,
		propertyChanged: ColorFilterPropertyChanged);

		private static void ColorFilterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var tab = (TabbedImageLabelView)bindable;
			tab.image.ColorFilter = (Color)newValue;
            if ((Color)newValue != Color.Default && tab.RadioBehavior.IsChecked == true)
			{
				tab.IndexSelectedChanged?.Invoke(tab, new EventArgs());
			}
		}

		public Color ColorFilter
		{
			get { return (Color)GetValue(ColorFilterProperty); }
			set
			{
				SetValue(ColorFilterProperty, value);
			}
		}
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
