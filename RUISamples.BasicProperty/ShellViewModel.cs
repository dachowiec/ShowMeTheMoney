using System.Globalization;
using System.Reactive.Linq;
using ReactiveUI;

namespace RUISamples
{
	public class BasicPropertyViewModel : ReactiveObject
	{
		public BasicPropertyViewModel()
		{
			this.WhenAnyValue(x => x.Text)
				.Select(x => (x ?? string.Empty).Length.ToString(CultureInfo.InvariantCulture))
				.ToProperty(this, model => model.Count, out count);
		}

		public string Text
		{
			get { return text; }
			set { this.RaiseAndSetIfChanged(ref text, value); }
		}

		public string Count
		{
			get { return count.Value; }
		}

		private string text;
		readonly ObservableAsPropertyHelper<string> count;
	}
}