using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DuGu.XFLib.Binders
{
    public class ListViewBinder
    {
        #region ItemTap
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.CreateAttached(
                "ItemTappedCommand",
                typeof(ICommand),
                typeof(ListViewBinder),
                default(ICommand),
                BindingMode.OneWay,
                null,
                PropertyChanged);

        private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var listView = bindable as ListView;
            if (listView != null)
            {
                listView.ItemTapped -= ListViewOnItemTapped;
                listView.ItemTapped += ListViewOnItemTapped;
            }
        }

        async static void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = sender as ListView;
            if (list != null && list.IsEnabled && !list.IsRefreshing)
            {
                await Task.Delay(30);
                list.SelectedItem = null;
                var command = GetItemTappedCommand(list);
                if (command != null && command.CanExecute(e.Item))
                {
                    command.Execute(e.Item);
                }
            }
        }

        public static ICommand GetItemTappedCommand(BindableObject bindableObject)
        {
            return (ICommand)bindableObject.GetValue(ItemTappedCommandProperty);
        }

        public static void SetItemTappedCommand(BindableObject bindableObject, object value)
        {
            bindableObject.SetValue(ItemTappedCommandProperty, value);
        }
        #endregion

        #region LoadMore
        public static readonly BindableProperty LoadMoreCmdProperty =
            BindableProperty.CreateAttached("LoadMoreCmd",
                typeof(ICommand),
                typeof(ListViewBinder),
                null,
                propertyChanged: Changed);

        public static void SetLoadMoreCmd(BindableObject view, ICommand cmd)
        {
            view.SetValue(LoadMoreCmdProperty, cmd);
        }

        public static ICommand GetLoadCmd(BindableObject view)
        {
            return (ICommand)view.GetValue(LoadMoreCmdProperty);
        }

        private static void Changed(BindableObject bindable, object oldValue, object newValue)
        {
            var lv = (ListView)bindable;
            if (lv == null)
                return;
            lv.ItemAppearing -= Lv_ItemAppearing;
            lv.ItemAppearing += Lv_ItemAppearing;
        }

        private static void Lv_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var lv = (ListView)sender;
            var cmd = GetLoadCmd(lv);
            if (cmd != null && cmd.CanExecute(null))
            {
                var last = lv.ItemsSource?.Cast<object>().LastOrDefault();
                if (last != null && last.Equals(e.Item))
                {
                    cmd.Execute(null);
                }
            }
        }

        #endregion

    }
}
