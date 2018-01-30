using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public class CarouselLayout : ScrollView
    {
        public enum IndicatorStyleEnum
        {
            None,
            Dots,
            Tabs
        }

        readonly StackLayout stack;
        int selectedIndex;

        public CarouselLayout()
        {
            Orientation = ScrollOrientation.Horizontal;

            stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0
            };

            Content = stack;

        }

        public IndicatorStyleEnum IndicatorStyle { get; set; }

        public IList<View> Children
        {
            get
            {
                return stack.Children;
            }
        }

        bool layingOutChildren;
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            if (layingOutChildren) return;

            layingOutChildren = true;
            foreach (var child in Children) child.WidthRequest = width;
            layingOutChildren = false;
        }

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(
            nameof(SelectedIndex),
            typeof(int),
            typeof(CarouselLayout),
            0,
            BindingMode.TwoWay,
            propertyChanged: async (bindable, oldValue, newValue) =>
            {
                await ((CarouselLayout)bindable).UpdateSelectedItem();
            }
        );

        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                SetValue(SelectedIndexProperty, value);
            }
        }

        async Task UpdateSelectedItem()
        {
            await Task.Delay(300);
            SelectedItem = SelectedIndex > -1 ? Children[SelectedIndex].BindingContext : null;
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IList),
            typeof(CarouselLayout),
            null,
            propertyChanging: (bindableObject, oldValue, newValue) =>
            {
                ((CarouselLayout)bindableObject).ItemsSourceChanging();
            },
            propertyChanged: (bindableObject, oldValue, newValue) =>
            {
                ((CarouselLayout)bindableObject).ItemsSourceChanged();
            }
        );

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        void ItemsSourceChanging()
        {
            if (ItemsSource == null) return;
            selectedIndex = ItemsSource.IndexOf(SelectedItem);
        }

        void ItemsSourceChanged()
        {
            stack.Children.Clear();
            foreach (var item in ItemsSource)
            {
                var view = (View)item;
                stack.Children.Add(view);
            }

            if (selectedIndex >= 0) SelectedIndex = selectedIndex;
        }

        public DataTemplate ItemTemplate
        {
            get;
            set;
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(
                nameof(SelectedItem),
                typeof(object),
                typeof(CarouselLayout),
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((CarouselLayout)bindable).UpdateSelectedIndex();
                }
            );

        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        void UpdateSelectedIndex()
        {
            if (SelectedItem == BindingContext) return;

            SelectedIndex = Children
                .Select(c => c.BindingContext)
                .ToList()
                .IndexOf(SelectedItem);
        }

    }
}
