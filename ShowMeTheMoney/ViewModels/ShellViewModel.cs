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
	public class ShellViewModel : ReactiveObject, IHandle<NewTransfers>
	{
		public ShellViewModel()
		{
			ViewModel = new EncouragementViewModel();

			_eventAggregator = Locator.Current.GetService<IEventAggregator>();
			_eventAggregator.Subscribe(this);

			OpenFileDialog = ReactiveCommand.Create();
			OpenFileDialog
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(_ => Locator.Current.GetService<CsvReaderTransactionDialog>().ShowDialog());

			_transferDao = Locator.Current.GetService<ITransferDao>();
		}

		public void Handle(NewTransfers message)
		{
			if (!(ViewModel is AnalyzeViewModel))
				ViewModel = new AnalyzeViewModel();

			_transferDao.Save(message.Transfers.Select(t => new Transfer { Raw = t }).ToArray());

			var fact = new YearViewModelFactory(_transferDao);

			var analyzeViewModel = ViewModel as AnalyzeViewModel;
			analyzeViewModel.YearModels = fact.CreatForYears(DateTime.Now.Year,DateTime.Now.Year - 1);

		}

		public object ViewModel
		{
			get { return viewModel; }
			set { this.RaiseAndSetIfChanged(ref viewModel, value); }
		}

		private object viewModel;

		public ReactiveCommand<object> OpenFileDialog { get; private set; }

		private IEventAggregator _eventAggregator;
		private ITransferDao _transferDao;
	}
}