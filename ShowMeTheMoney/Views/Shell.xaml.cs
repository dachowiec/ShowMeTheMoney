using System;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using ReactiveUI;
using ShowMeTheMoney.ViewModels;
using Splat;

namespace ShowMeTheMoney.Views
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class Shell : IViewFor<ShellViewModel>, IScreen
	{
		private IEventAggregator _eventAggregator;

		public Shell()
		{
			InitializeComponent();
			ViewModel = new ShellViewModel();

			this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);

			Router = new RoutingState();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.BindCommand(ViewModel, vm => vm.OpenFileDialog, v => v.openFile);
			this.BindCommand(ViewModel, vm => vm.EditCategories, v => v.editCategories);
			//this.Bind(ViewModel, vm => vm.ViewModel, v => v.viewHost.ViewModel);
			this.Bind(ViewModel, vm => vm.Router, v => v.viewHost.Router);

			MouseWheel += Zoom_MouseWheel;
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as ShellViewModel; }
		}

		public ShellViewModel ViewModel { get; set; }

		public RoutingState Router { get; private set; }

		private void Zoom_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			bool handle = (Keyboard.Modifiers & ModifierKeys.Control) > 0;
			if (!handle)
				return;

			var settings = Locator.Current.GetService<ViewSettings>();
			settings.FontSize += 2 * Math.Sign(e.Delta);
		}

	}
}
