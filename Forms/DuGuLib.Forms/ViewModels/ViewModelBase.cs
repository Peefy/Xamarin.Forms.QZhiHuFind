
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuGu.XFLib.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public virtual void SaveState(IDictionary<string, object> dictionary)
        {

        }

        public virtual void RestoreState(IDictionary<string, object> dictionary)
        {

        }

        public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary,
            string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return (T)dictionary[key];
            return defaultValue;
        }

        #region IsBusy
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        #endregion

        #region IsInitialize
        bool isInitialize = false;
        public bool IsInitialize
        {
            get { return isInitialize; }
            set { SetProperty(ref isInitialize, value); }
        }
        #endregion

        #region Title
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
		#endregion

		#region Tag
        object tag = new object();
        public object Tag
		{
			get { return tag; }
			set { SetProperty(ref tag, value); }
		}
		#endregion

	}
}

