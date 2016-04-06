using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
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
					(file, reader) => !string.IsNullOrWhiteSpace(file) && reader != null)
					.DistinctUntilChanged()
					.ToCommand();
					

			ReadTransactions.Subscribe(_ =>
			{
				EventAggregator.Publish(new NewTransfers
				{
					Transfers = SelectedReader.Create(File.OpenRead(SelectedFile)).Read()
				}, action => action());
				RaiseRequestClose();
			});
		}

		public IEventAggregator EventAggregator { get; private set; }

		public ReadOnlyCollection<ITransferReaderFactory> Readers { get; protected set; }

		private void RaiseRequestClose()
		{
			if(RequestClose != null)
				RequestClose(this,new EventArgs());
		}

		public event EventHandler RequestClose;

		public ITransferReaderFactory SelectedReader
		{
			get { return selectedReader; }
			set { this.RaiseAndSetIfChanged(ref selectedReader, value); }
		}

		public string SelectedFile
		{
			get { return selectedFile; }
			set { this.RaiseAndSetIfChanged(ref selectedFile, value); }
		}

		public ReactiveCommand<object> ReadTransactions { get; protected set; } 

		private ITransferReaderFactory selectedReader;
		private string selectedFile;
	}
}