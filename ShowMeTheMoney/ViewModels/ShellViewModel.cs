using System;
using System.Reactive.Linq;
using System.Windows;
using ReactiveUI;
using ShowMeTheMoney.Views;
using Splat;

namespace ShowMeTheMoney.ViewModels
{
	public class ShellViewModel : ReactiveObject
	{
		public ShellViewModel()
		{
			OpenFileDialog = ReactiveCommand.Create();
			OpenFileDialog
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(_ => Locator.Current.GetService<CsvReaderTransactionDialog>().ShowDialog(),
				exception => MessageBox.Show("" + exception));
		}

		public ReactiveCommand<object> OpenFileDialog { get; private set; }
	}
}