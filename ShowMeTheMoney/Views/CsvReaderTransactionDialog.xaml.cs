using System.Windows;
using Microsoft.Win32;
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
			//ViewModel.RequestClose += (sender, args) => Close();
			this.OneWayBind(ViewModel, vm => vm.Readers, v => v.readers.ItemsSource);
			this.Bind(ViewModel, vm => vm.SelectedReader, v => v.readers.SelectedItem);
			this.Bind(ViewModel, vm => vm.SelectedFile, v => v.selectedFile.Text);
			this.BindCommand(ViewModel, vm => vm.ReadTransactions, v => v.readTransactions);
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as SelectTransactionReaderDialogViewModel; }
		}

		public SelectTransactionReaderDialogViewModel ViewModel { get; set; }

		private void ChooseFile_OnClick(object sender, RoutedEventArgs e)
		{
			var filedialog = new OpenFileDialog();
			if (filedialog.ShowDialog().GetValueOrDefault())
			{
				ViewModel.SelectedFile = filedialog.FileName;
			}
		}

		//private void Close_OnClick(object sender, RoutedEventArgs e)
		//{
		//	Close();
		//}
	}
}
