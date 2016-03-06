using System.Windows;
using ReactiveUI;

namespace RUISamples.Commands
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class Shell : IViewFor<ShellViewModel>
	{
		public Shell()
		{
			ViewModel = new ShellViewModel();

			InitializeComponent();
			this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
			this.BindCommand(ViewModel, vm => vm.MessageCommand, v => v.messageButton);
			this.BindCommand(ViewModel, vm => vm.HelloCommand, v => v.helloButton);
			this.BindCommand(ViewModel, vm => vm.AnotherHello, v => v.adviceButton);
			this.BindCommand(ViewModel, vm => vm.YoLo, v => v.yoloButton);
			this.BindCommand(ViewModel, vm => vm.SlowCommand, v => v.longRunnningButton);
			this.Bind(ViewModel, vm => vm.Name, v => v.YourName.Text);
			this.Bind(ViewModel, vm => vm.IsBusy, v => v.busyIndicator.IsBusy);
		}

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel", typeof(ShellViewModel), typeof(Shell), new PropertyMetadata(default(ShellViewModel)));

		public ShellViewModel ViewModel
		{
			get { return (ShellViewModel)GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as ShellViewModel; }
		}
	}
}
