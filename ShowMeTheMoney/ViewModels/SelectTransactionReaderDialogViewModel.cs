using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
		}

		public ReadOnlyCollection<ITransferReaderFactory> Readers { get; protected set; }

		public ITransferReaderFactory SelectedReader { get; set;}
	}
}