using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using Caliburn.Micro;
using ReactiveUI;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.ViewModels.Events;
using Splat;

namespace ShowMeTheMoney.ViewModels
{
	public class SelectTransactionReaderDialogViewModel : ReactiveObject
	{
		public SelectTransactionReaderDialogViewModel(IList<ITransferReaderFactory> readers = null,
			IEventAggregator eventAggregator = null)
		{
			Readers = new ReadOnlyCollection<ITransferReaderFactory>(
				readers ?? Locator.Current.GetServices<ITransferReaderFactory>().ToList());
			EventAggregator = eventAggregator ?? Locator.Current.GetService<IEventAggregator>();

			ReadTransactions =
				this.WhenAnyValue(x => x.SelectedFile, x => x.SelectedReader,
					(file,reader) => file !=null && reader != null)
					.DistinctUntilChanged()
					.ToCommand();
					

			ReadTransactions.Subscribe(_ => EventAggregator.Publish(new NewTransfers
			{
				Transfers = SelectedReader.Create(File.OpenRead(SelectedFile)).Read()
			},action => action()));
		}

		public IEventAggregator EventAggregator { get; private set; }

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