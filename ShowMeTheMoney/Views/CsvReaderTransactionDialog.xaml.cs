using ReactiveUI;
using ShowMeTheMoney.ViewModels;
using Splat;

namespace ShowMeTheMoney.Views
{
	/// <summary>
	/// Interaction logic for CsvReaderTransactionDialog.xaml
	/// </summary>
	public partial class CsvReaderTransactionDialog : IViewFor<SelectTransactionReaderDialogViewModel>
	{
		public CsvReaderTransactionDialog(SelectTransactionReaderDialogViewModel shellViewModel = null)
		{
			InitializeComponent();

			ViewModel = shellViewModel ?? Locator.CurrentMutable.GetService<SelectTransactionReaderDialogViewModel>();

			this.OneWayBind(ViewModel, vm => vm.Readers, v => v.readers.ItemsSource);
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as SelectTransactionReaderDialogViewModel; }
		}

		public SelectTransactionReaderDialogViewModel ViewModel { get; set; }
	}
}
