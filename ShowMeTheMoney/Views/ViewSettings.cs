using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ShowMeTheMoney.Annotations;

namespace ShowMeTheMoney.Views
{
	public class ViewSettings : FrameworkElement, INotifyPropertyChanged
	{
		public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
			"FontSize", typeof (Double), typeof (ViewSettings), new PropertyMetadata(default(Double),ChangedCallback));

		private static void ChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ViewSettings)d).OnPropertyChanged("FontSize");
		}

		public Double FontSize
		{
			get { return (Double) GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}