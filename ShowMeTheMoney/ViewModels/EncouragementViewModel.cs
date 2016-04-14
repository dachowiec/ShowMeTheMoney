using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class EncouragementViewModel : ReactiveObject, IRoutableViewModel
	{
		public EncouragementViewModel(IScreen screen)
		{
			HostScreen = screen;

			OpenFile = ReactiveCommand.Create();
			OpenFile
				.SubscribeOn(RxApp.MainThreadScheduler)
				.Subscribe(_ => HostScreen.Router.Navigate.Execute(new SelectTransactionReaderDialogViewModel()
				{
					HostScreen = screen
				}));
		}

		public string UrlPathSegment { get; set; }

		public IScreen HostScreen { get; set; }

		public ReactiveCommand<object> OpenFile { get; private set; }

	}
}