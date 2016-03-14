using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using ReactiveUI;
using ShowMeTheMoney.Transfers;
using Splat;

namespace ShowMeTheMoney.ViewModels
{
	public class SelectTransactionReaderDialogViewModel : ReactiveObject
	{
		public SelectTransactionReaderDialogViewModel(IList<ITransferReaderFactory> readers = null)
		{
			Readers = new ReadOnlyCollection<ITransferReaderFactory>(
				readers ?? Locator.Current.GetServices<ITransferReaderFactory>().ToList());

			ReadTransactions =
				this.WhenAnyValue(x => x.SelectedFile, x => x.SelectedReader,
					(file,reader) => file !=null && reader != null)
					.DistinctUntilChanged()
					.ToCommand();
					

			ReadTransactions.Subscribe(_ => MessageBox.Show("Haaa cydenniaaa!"));


		}

		public ReadOnlyCollection<ITransferReaderFactory> Readers { get; protected set; }

		public ITransferReaderFactory SelectedReader
		{
			get { return _selectedReader; }
			set { this.RaiseAndSetIfChanged(ref _selectedReader, value); }
		}

		public string SelectedFile
		{
			get { return _selectedFile; }
			set { this.RaiseAndSetIfChanged(ref _selectedFile, value); }
		}

		public ReactiveCommand<object> ReadTransactions { get; protected set; } 

		private ITransferReaderFactory _selectedReader;
		private string _selectedFile;
	}
}