﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace DuGu.XFLib.Controls.TabViewControls
{
	public class TabViewChildren : INotifyPropertyChanged
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

		ContentView view = new ContentView();
		string text = "tab1";
		string selectedImageSource = "";
		string unSelectImageSource = "";
		Color selectedTextColor = Color.Red;
		Color unSelectTextColor = Color.Default;
		Color selectedImageColorFilter = Color.Red;
        Color unSelectImageColorFilter = Color.Default;
		Size imageSize = new Size(25, 25);
		double textFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

		public ContentView View
		{
			get { return view; }
			set { SetProperty(ref view, value); }
		}

		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		public string SelectedImageSource
		{
			get { return selectedImageSource; }
			set { SetProperty(ref selectedImageSource, value); }
		}

		public string UnSelectImageSource
		{
			get { return unSelectImageSource; }
			set { SetProperty(ref unSelectImageSource, value); }
		}

		public Color SelectedTextColor
		{
			get { return selectedTextColor; }
			set { SetProperty(ref selectedTextColor, value); }
		}

		public Color UnSelectTextColor
		{
			get { return unSelectTextColor; }
			set { SetProperty(ref unSelectTextColor, value); }
		}

		public Color SelectedImageColorFilter
		{
			get { return selectedImageColorFilter; }
			set { SetProperty(ref selectedImageColorFilter, value); }
		}

		public Color UnSelectImageColorFilter
		{
			get { return unSelectImageColorFilter; }
			set { SetProperty(ref unSelectImageColorFilter, value); }
		}

		public Size ImageSize
		{
			get { return imageSize; }
			set { SetProperty(ref imageSize, value); }
		}

		public double TextFontSize
		{
			get { return textFontSize; }
			set { SetProperty(ref textFontSize, value); }
		}

	}
}
