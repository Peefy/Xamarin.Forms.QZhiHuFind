using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZhihuFind.Services.Interfaces
{
	public interface IDialogService
	{
		Task ShowAlertAsync(string message, string title, string buttonLabel);
		Task ShowAlertAsync(string message);
		Task<bool> ShowAlertAsync(string title, string quest);
		void Toast(string message);
	}
}
