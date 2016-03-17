using System;
using System.Reactive.Linq;
using Caliburn.Micro;
using ReactiveUI;
using ShowMeTheMoney.ViewModels.Events;
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
		}

		public void Handle(NewTransfers message)
		{
			if (!(ViewModel is AnalyzeViewModel))
				ViewModel = new AnalyzeViewModel();

			var analyzeViewModel = ViewModel as AnalyzeViewModel;
			analyzeViewModel.Accept(message);

		}

		public object ViewModel
		{
			get { return viewModel; }
			set { this.RaiseAndSetIfChanged(ref viewModel, value); }
		}

		private object viewModel;

		public ReactiveCommand<object> OpenFileDialog { get; private set; }

		private IEventAggregator _eventAggregator;
	}
}