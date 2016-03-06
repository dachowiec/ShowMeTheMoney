using ReactiveUI;

namespace RUISample.Interact
{
	public class InteractionsViewModel : ReactiveObject
	{
		private readonly Interactions<string, bool> abc;

		public string Text
		{
			get { return text; }
			set { this.RaiseAndSetIfChanged(ref text, value); }
		}

		private string text;
	}
}