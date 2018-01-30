using System;
using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace DuGu.XFLib.Extensions
{
    /// <summary>
    /// 如果数据源是 INotifyCollectionChanged , 则监听变化事件，否则执行 reset 命令
    /// </summary>
    public static class INotifyCollectionChangedExtension
    {
        public static Action Begin { get; set; }
        public static Action<IList, int> Add { get; set; }
        public static Action<IList, int> Remove { get; set; }
        public static Action Reset { get; set; }
        public static Action Finished { get; set; }

        public static void Wraper(this INotifyCollectionChanged collection, Action<IList, int> add = null,
			Action<IList, int> remove = null,
			Action reset = null,
			Action finished = null,
			Action begin = null)
        {
			collection.CollectionChanged -= Collection_CollectionChanged;
			collection.CollectionChanged += Collection_CollectionChanged;

			Add = add;
			Remove = remove;
			Reset = reset;
			Finished = finished;

			if (begin != null)
				begin.Invoke();

			if (reset != null)
				reset.Invoke();

			if (finished != null)
				finished.Invoke();

        }

        private static void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (Begin != null)
				Begin.Invoke();

			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					if (Add != null)
					{
						Device.BeginInvokeOnMainThread(() =>
						{
							Add.Invoke(e.NewItems, e.NewStartingIndex);
						});
					}
					break;
				case NotifyCollectionChangedAction.Remove:
					if (Remove != null)
						Device.BeginInvokeOnMainThread(() =>
						{
							Remove.Invoke(e.OldItems, e.OldStartingIndex);
						});
					break;
				case NotifyCollectionChangedAction.Reset:
					if (Reset != null)
					{
						//IOS 下，Device.BeginInvokeOnMainThread 导至 Reset 重复触发，
						// TODO Android 下不确定，待测
						//Device.BeginInvokeOnMainThread(() => {
						Reset.Invoke();
						//});
					}
					break;
				case NotifyCollectionChangedAction.Move:
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
			}

			if (Finished != null)
				Finished.Invoke();
		}

    }

}
