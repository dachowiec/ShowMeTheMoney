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

namespace RUISamples.Bindings
{
	/// <summary>
	/// Interaction logic for MyView.xaml
	/// </summary>
	public partial class MyView : IViewFor<MyViewModel>
	{
		public MyView()
		{
			InitializeComponent();
			this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
			this.Bind(ViewModel, vm => vm.MyText, v => v.TextBox.Text);
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as MyViewModel; }
		}

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel", typeof (MyViewModel), typeof (MyView), new PropertyMetadata(default(MyViewModel)));

		public MyViewModel ViewModel
		{
			get { return (MyViewModel) GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}
	}
}
