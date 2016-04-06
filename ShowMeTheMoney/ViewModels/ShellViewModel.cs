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

			Router.Navigate.Execute(new EncouragementViewModel());

			_eventAggregator = Locator.Current.GetService<IEventAggregator>();
			_eventAggregator.Subscribe(this);

			OpenFileDialog = ReactiveCommand.Create();
			OpenFileDialog
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(_ => Locator.Current.GetService<CsvReaderTransactionDialog>().ShowDialog());

			EditCategories = ReactiveCommand.Create();
			EditCategories
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(_ => Router.Navigate.Execute(new CategoriesViewModel()));

			_transferDao = Locator.Current.GetService<ITransferDao>();
		}

		public void Handle(NewTransfers message)
		{
			AnalyzeViewModel analyzeViewModel;

			if (Router.NavigationStack.Last() is AnalyzeViewModel)
			{
				analyzeViewModel = Router.NavigationStack.Last() as AnalyzeViewModel;
			}
			else
			{
				analyzeViewModel = new AnalyzeViewModel(this);
				Router.Navigate.Execute(analyzeViewModel);
			}
				

			_transferDao.Save(message.Transfers.Select(t => new Transfer { Raw = t }).ToArray());

			var fact = new FinancialperiodViewModelFactory(_transferDao);

			analyzeViewModel.FinancialPeriods =
				new ReactiveList<IFinancialPeriodViewModel>(fact.CreatForYears(DateTime.Now.Year, DateTime.Now.Year - 1));
		}

		//public object ViewModel
		//{
		//	get { return viewModel; }
		//	set { this.RaiseAndSetIfChanged(ref viewModel, value); }
		//}

		public ReactiveCommand<object> OpenFileDialog { get; private set; }

		public ReactiveCommand<object> EditCategories { get; private set; }

		private object viewModel;
		private IEventAggregator _eventAggregator;
		private ITransferDao _transferDao;

		public RoutingState Router { get; private set; }
	}
}