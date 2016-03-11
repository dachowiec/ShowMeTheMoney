using System;
using System.Windows;
using ReactiveUI;
using ShowMeTheMoney.ViewModels;

namespace ShowMeTheMoney
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class Shell : IViewFor<ShellViewModel>, IScreen
	{
		public Shell()
		{
			InitializeComponent();
			ViewModel = new ShellViewModel();

			this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);

			Router = new RoutingState();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.BindCommand(ViewModel, vm => vm.OpenFileDialog, v => v.openFile);
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as ShellViewModel; }
		}

		public ShellViewModel ViewModel { get; set; }

		public RoutingState Router { get; private set; }
	}
}
