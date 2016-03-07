using System.Windows;

namespace RUISamples
{
	/// <summary>
	/// Interaction logic for BasicProperty.xaml
	/// </summary>
	public partial class BasicProperty : Window
	{
		public BasicProperty()
		{
			DataContext = new ShellViewModel();
			InitializeComponent();
		}
	}
}
