using System;

using Xamarin.Forms;

namespace DuGu.XFLib.Controls.TabViewControls
{
	public class TabViewChangedEventArgs : EventArgs
	{
		public int Index { get; set; }
		public ContentView View { get; }
		public TabViewChangedEventArgs(int index, ContentView view)
		{
			Index = index;
			View = view;
		}
	}
}
