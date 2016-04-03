using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ShowMeTheMoney.Views.Converters
{
	public class AddConverter : MarkupExtension, IValueConverter
	{
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var val = System.Convert.ToDouble(value);
			return val + Value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public double Value { get; set; }
	}
}