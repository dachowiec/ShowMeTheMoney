using System;
using System.Linq;
using System.Reactive.Linq;
using Caliburn.Micro;
using ReactiveUI;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Storage;
using ShowMeTheMoney.ViewModels.Events;
using ShowMeTheMoney.ViewModels.Factories;
using ShowMeTheMoney.Views;
using Splat;

namespace ShowMeTheMoney.ViewModels
{
	public class ShellViewModel : ReactiveObject, IScreen, IHandle<NewTransfers>
	{
		public ShellViewModel()
		{
			Router = new RoutingState();

			Router.Navigate.Execute(new EncouragementViewModel(this));

			var eventAggregator = Locator.Current.GetService<IEventAggregator>();
			eventAggregator.Subscribe(this);

			OpenFile = ReactiveCommand.Create();
			OpenFile
				.SubscribeOn(RxApp.TaskpoolScheduler)
				.Subscribe(_ => Router.Navigate.Execute(new SelectTransactionReaderDialogViewModel()));

			transferDao = Locator.Current.GetService<ITransferDao>();
		}

		public ReactiveCommand<object> OpenFile { get; private set; }

		public RoutingState Router { get; private set; }

		public void Handle(NewTransfers message)
		{
			var analyzeViewModel = Router.NavigationStack.Last() as AnalyzeViewModel;
			
			if(analyzeViewModel == null)
			{
				analyzeViewModel = new AnalyzeViewModel(this);
				Router.Navigate.Execute(analyzeViewModel);
			}

			transferDao.Save(message.Transfers.Select(t => new Transfer { Raw = t }).ToArray());

			var fact = new FinancialperiodViewModelFactory(transferDao);

			analyzeViewModel.FinancialPeriods =
				new ReactiveList<IFinancialPeriodViewModel>(fact.CreatForYears(DateTime.Now.Year, DateTime.Now.Year - 1));
		}

		private readonly ITransferDao transferDao;
	}
}