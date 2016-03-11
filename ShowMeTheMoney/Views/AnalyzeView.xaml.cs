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
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as AnalyzeViewModel; }
		}

		public AnalyzeViewModel ViewModel { get; set; }
	}
}
