using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace ShowMeTheMoney.Views.Converters
{
	public class BalanceForegroundConverter : MarkupExtension, IValueConverter
	{
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;
			var val = System.Convert.ToDouble(value);

			var green = (Color)ColorConverter.ConvertFromString("#4caf50");
			var red = (Color)ColorConverter.ConvertFromString("#f44336");
			return new SolidColorBrush(val > 0 ? green : red);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}