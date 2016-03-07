using ReactiveUI;

namespace RUISamples.Bindings
{
	public class MyViewModel : ReactiveObject
	{
		public string MyText
		{
			get { return myText; }
			set { this.RaiseAndSetIfChanged(ref myText, value); }
		}

		private string myText;
	}
}
