namespace RUISample.BasicProperty.BasicProperty
{
	/// <summary>
	/// Interaction logic for BasicProperty.xaml
	/// </summary>
	public partial class BasicProperty 
	{
		public BasicProperty()
		{
			DataContext = new BasicPropertyViewModel();
			InitializeComponent();
		}
	}
}
