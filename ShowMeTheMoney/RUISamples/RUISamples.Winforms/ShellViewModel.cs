using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;
using ReactiveUI;

namespace RUISamples.Winforms
{
	public class ShellViewModel : ReactiveObject
	{
		private string text;

		public ShellViewModel()
		{
			ChangeCommand = ReactiveCommand.Create();
			ChangeCommand.Subscribe(_ => Text = Guid.NewGuid().ToString());
		}

		public string Text
		{
			get { return text; }
			set { this.RaiseAndSetIfChanged(ref text, value); }
		}

		public ReactiveCommand<object> ChangeCommand { get; private set; }

	}
}