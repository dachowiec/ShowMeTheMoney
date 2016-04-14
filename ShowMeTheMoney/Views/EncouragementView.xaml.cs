using ReactiveUI;
using ShowMeTheMoney.ViewModels;

namespace ShowMeTheMoney.Views
{
	/// <summary>
	/// Interaction logic for EncouragementView.xaml
	/// </summary>
	public partial class EncouragementView : IViewFor<EncouragementViewModel>
	{
		public EncouragementView()
		{
			InitializeComponent();
			this.BindCommand(ViewModel, vm => vm.OpenFile, v => v.OpenHyperlink);
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as EncouragementViewModel; }
		}

		public EncouragementViewModel ViewModel { get; set; }
	}
}
