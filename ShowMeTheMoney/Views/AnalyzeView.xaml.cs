using System.Windows;
using ReactiveUI;
using ShowMeTheMoney.ViewModels;

namespace ShowMeTheMoney.Views
{
	/// <summary>
	/// Interaction logic for AnalyzeView.xaml
	/// </summary>
	public partial class AnalyzeView : IViewFor<AnalyzeViewModel>
	{
		public AnalyzeView()
		{
			InitializeComponent();
			this.OneWayBind(ViewModel, vm => vm.YearModels, v => v.years.ItemsSource);
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as AnalyzeViewModel; }
		}

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel", typeof (AnalyzeViewModel), typeof (AnalyzeView), new PropertyMetadata(default(AnalyzeViewModel)));

		public AnalyzeViewModel ViewModel
		{
			get { return (AnalyzeViewModel) GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}

		private AnalyzeViewModel _viewModel;
	}
}
