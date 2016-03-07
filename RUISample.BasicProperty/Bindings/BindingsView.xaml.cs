using System.Windows;
using ReactiveUI;
using RUISamples.Bindings;

namespace RUISample.BasicProperty.Bindings
{
	/// <summary>
	/// Interaction logic for BindingsView.xaml
	/// </summary>
	public partial class BindingsView : IViewFor<BindingsViewModel>
	{
		public BindingsView()
		{
			InitializeComponent();
			this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
			ViewModel = new BindingsViewModel();
			this.Bind(ViewModel, vm => vm.MyText, v => v.TextBox.Text);
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as BindingsViewModel; }
		}

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel", typeof (BindingsViewModel), typeof (BindingsView), new PropertyMetadata(default(BindingsViewModel)));

		public BindingsViewModel ViewModel
		{
			get { return (BindingsViewModel) GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}
	}
}
