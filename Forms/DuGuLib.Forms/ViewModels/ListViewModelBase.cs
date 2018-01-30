using DuGu.XFLib.Models;
using DuGu.XFLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuGu.XFLib.ViewModels
{

    public class ListViewModelBase<T> : ViewModelBase, IDataStore<T> where T : BaseDataObject
    {

        public ObservableCollection<T> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command LoadMoreCommand { get; set; }
        public Command ItemSelectedCommand { get; set; }
        public Command RefreshCommand { get; set; }

        bool isRefreshEnable = true;
        public bool IsRefreshEnable
        {
            get { return isRefreshEnable; }
            set { SetProperty(ref isRefreshEnable, value); }
        }

        bool isLoadMore;
        public bool IsLoadMore
        {
            get { return isLoadMore; }
            set { SetProperty(ref isLoadMore, value); }
        }

        public ListViewModelBase(string title)
        {
            Title = title;
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadMoreCommand = new Command(OnLoadMore);
            ItemSelectedCommand = new Command<T>(OnSelectItem);
            RefreshCommand = new Command(OnRefresh);
        }

        public virtual void OnLoadMore(object obj)
        {

        }

        public virtual void OnRefresh(object obj)
        {

        }

        public virtual void OnSelectItem(T item)
        {

        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> AddItemAsync(T item)
        {
            if (Items == null)
                return await Task.FromResult(false);
            Items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(T item)
        {
            if (Items == null)
                return await Task.FromResult(false);
            var _item = Items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
            Items.Remove(_item);
            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(string id)
        {
            if (Items == null)
                return null;
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            if (Items == null)
                return await Task.FromResult(false);
            var _item = Items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
            Items.Remove(_item);
            Items.Add(item);
            return await Task.FromResult(true);
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            var pitems = await Task.Run(() =>
            {
                ObservableCollection<T> items = new ObservableCollection<T>();
                return items;
            });
            return pitems;
        }

        public virtual Task InitializeAsync()
        {
            return Task.Run(() => { });
        }

        public virtual async Task<bool> PullLatestAsync()
        {
            return await Task.FromResult(false);
        }

        public virtual async Task<bool> SyncAsync()
        {
            return await Task.FromResult(false);
        }
    }
}
