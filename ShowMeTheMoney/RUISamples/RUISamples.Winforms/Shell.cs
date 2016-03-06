using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ReactiveUI;

namespace RUISamples.Winforms
{
	public partial class Shell : Form, IViewFor<ShellViewModel>
	{
		private ShellViewModel viewModel;

		public Shell()
		{
			InitializeComponent();

			ViewModel = new ShellViewModel();
			this.BindCommand(ViewModel, vm => vm.ChangeCommand, v => v.button1);
			this.Bind(ViewModel, vm => vm.Text, v => v.label1.Text);
		}


		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as ShellViewModel; }
		}

		public ShellViewModel ViewModel
		{
			get { return viewModel; }
			set { viewModel = value; }
		}
	}
}
