using ReactiveUI;

namespace RUISample.Interact
{
	/// <summary>
	/// Interaction logic for InteractionsView.xaml
	/// </summary>
	public partial class InteractionsView : IViewFor<InteractionsViewModel>
	{
		public InteractionsView()
		{
			ViewModel = new InteractionsViewModel();
			InitializeComponent();
			
		}

		

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (InteractionsViewModel) value; }
		}

		public InteractionsViewModel ViewModel { get; set; }

		private string text;
	}
}
