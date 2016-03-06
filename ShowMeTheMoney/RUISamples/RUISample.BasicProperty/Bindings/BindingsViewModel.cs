using ReactiveUI;

namespace RUISamples.Bindings
{
	public class BindingsViewModel : ReactiveObject
	{
		public BindingsViewModel()
		{
			myText = "Kasia";
		}

		public string MyText
		{
			get { return myText; }
			set { this.RaiseAndSetIfChanged(ref myText, value); }
		}

		private string myText;
	}
}
