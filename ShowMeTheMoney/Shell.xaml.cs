using System;
using System.Windows;
using Caliburn.Micro;
using ReactiveUI;
using ShowMeTheMoney.ViewModels;
using ShowMeTheMoney.ViewModels.Events;
using Splat;

namespace ShowMeTheMoney
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class Shell : IViewFor<ShellViewModel>, IScreen, IHandle<NewTransfers>
	{
		private IEventAggregator _eventAggregator;

		public Shell()
		{
			_eventAggregator = Locator.Current.GetService<IEventAggregator>();
			_eventAggregator.Subscribe(this);
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

		public void Handle(NewTransfers message)
		{
			MessageBox.Show("Tak tak !!!");
		}
	}
}
