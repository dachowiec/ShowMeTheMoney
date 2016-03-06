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

namespace RUISample.Routing
{
	/// <summary>
	/// Interaction logic for RedView.xaml
	/// </summary>
	public partial class RedView : IViewFor<RedViewModel>
	{
		public RedView()
		{
			InitializeComponent();
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (RedViewModel) value; }
		}

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel", typeof (RedViewModel), typeof (RedView), new PropertyMetadata(default(RedViewModel)));

		public RedViewModel ViewModel
		{
			get { return (RedViewModel) GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}
	}
}
