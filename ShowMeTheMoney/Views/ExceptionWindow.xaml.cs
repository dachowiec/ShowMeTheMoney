
using System;

namespace ShowMeTheMoney.Views
{
	/// <summary>
	/// Interaction logic for ExceptionWindow.xaml
	/// </summary>
	public partial class ExceptionWindow
	{
		public ExceptionWindow(Exception exception)
		{
			InitializeComponent();
			TextBox.Text = GetText(exception);
		}

		private string GetText(Exception exception)
		{
			if (exception == null)
				return string.Empty;

			return exception.ToString() + "\n\n" + GetText(exception.InnerException);
		}
	}
}
