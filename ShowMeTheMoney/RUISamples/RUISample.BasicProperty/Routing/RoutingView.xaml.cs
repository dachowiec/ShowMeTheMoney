using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI;
using Splat;

namespace RUISample.Routing
{
	/// <summary>
	/// Interaction logic for RoutingView.xaml
	/// </summary>
	public partial class RoutingView : IViewFor<RoutingViewModel>
	{
		public RoutingView()
		{
			ViewModel = new RoutingViewModel();
			InitializeComponent();
			this.Bind(ViewModel, vm => vm.Router, v => v.RoutedViewHost.Router);
			this.BindCommand(ViewModel, vm => vm.NavigateRedCommand, v => v.navigateRed);
			this.BindCommand(ViewModel, vm => vm.NavigateBlueCommand, v => v.navigateBlue);
			Locator.CurrentMutable.Register(() => new RedView(), typeof(IViewFor<RedViewModel>));
			Locator.CurrentMutable.Register(() => new BlueView(), typeof(IViewFor<BlueViewModel>));
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (RoutingViewModel) value; }
		}

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel", typeof (RoutingViewModel), typeof (RoutingView), new PropertyMetadata(default(RoutingViewModel)));

		public RoutingViewModel ViewModel
		{
			get { return (RoutingViewModel) GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}
	}
}
