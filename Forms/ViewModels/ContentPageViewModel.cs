using System.Threading.Tasks;
using Xamarin.Forms;

using QZhihuFind.Services.Interfaces;
using QZhihuFind.Services;
using QZhihuFind.Utils;
using DuGu.XFLib.ViewModels;

namespace QZhihuFind.ViewModels.Base
{
	public class ContentPageViewModel : ViewModelBase
	{
		int id = 0;
		bool isProgressing;
		double progress;
		string htmlBody = "";
		string cssFileName = "";

		string collectionToolBarText = "收藏";

		public int Id
		{
			get => id;
			set => SetProperty(ref id, value);
		}

		public bool IsProgressing
		{
			get => isProgressing;
			set => SetProperty(ref isProgressing, value);
		}

		public double Progress
		{
			get => progress;
			set => SetProperty(ref progress, value);
		}

		public string HtmlBody
		{
			get => htmlBody;
			set => SetProperty(ref htmlBody, value);
		}

		public string CssFileName
		{
			get => cssFileName;
			set => SetProperty(ref cssFileName, value);
		}

		public string CollectionToolBarText
		{
			get => collectionToolBarText;
			set => SetProperty(ref collectionToolBarText, value);
		}

		public bool IsCollected { get; set; }

		public Command CommentsCommand { get; set; }
		public Command CollectionCommand { get; set; }
		public IDialogService DialogService;

		public ContentPageViewModel(int id)
		{
			Id = id;
			CommentsCommand = new Command(OnComments);
			CollectionCommand = new Command(OnCollection);
			DialogService = DependencyService.Get<IDialogService>();
			IsCollected = SQLiteUtils.Instance.JudgeExistCollection(Id);
			CollectionToolBarText = IsCollected == false ? "收藏" : "取消";
		}


		public virtual void OnComments(object obj)
		{

		}

		public virtual void OnCollection(object obj)
		{

		}

		public void ProgressBarRunning()
		{
			Task.Run(async () =>
			{
				for (int i = 0; i < 80; ++i)
				{
					Progress = i / 100.0;
					await Task.Delay(10);
				}
			});
		}

		public void ProgressBarFinish()
		{
			Task.Run(async () =>
			{
				for (int i = 80; i < 100; ++i)
				{
					Progress = i / 100.0;
					await Task.Delay(10);
				}
			});
		}

	}
}