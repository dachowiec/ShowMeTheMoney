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
	/// Interaction logic for BlueView.xaml
	/// </summary>
	public partial class BlueView : IViewFor<BlueViewModel>
	{
		public BlueView()
		{
			InitializeComponent();
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (BlueViewModel) value; }
		}

		public BlueViewModel ViewModel { get; set; }
	}
}
