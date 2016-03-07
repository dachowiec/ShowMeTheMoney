using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ReactiveUI;

namespace RUISamples.Commands
{
	public class ShellViewModel : ReactiveObject
	{
		private ReactiveCommand<object> messageCommand;
		private ReactiveCommand<object> helloCommand;
		private string name;
		private ReactiveCommand<object> anotherHello;
		private ReactiveCommand<object> yoLo;
		private ReactiveCommand<Unit> slowCommand;
		private readonly ObservableAsPropertyHelper<bool> isBusy;

		public ShellViewModel()
		{
			MessageCommand = ReactiveCommand.Create();
			MessageCommand.Subscribe(_ => MessageBox.Show("aaa"));

			HelloCommand = ReactiveCommand.Create(this.WhenAny(x => x.Name, myName => !string.IsNullOrWhiteSpace(myName.Value)));
			HelloCommand.Subscribe(_ => MessageBox.Show("Hi " + Name));

			AnotherHello = this.WhenAny(x => x.Name, myName => string.IsNullOrWhiteSpace(myName.Value)).ToCommand();
			AnotherHello.Subscribe(_ => MessageBox.Show("Wpisz imię"));
			
			yoLo = ReactiveCommand.CreateCombined(MessageCommand,HelloCommand );

			SlowCommand = ReactiveCommand.CreateAsyncTask(obj => Task.Factory.StartNew(() =>
			{
				Thread.Sleep(3000);
				MessageBox.Show("koniec");
			}));

			this.WhenAnyObservable(x => x.SlowCommand.IsExecuting)
				.ToProperty(this, vm => vm.IsBusy, out isBusy);
		}

		public bool IsBusy
		{
			get { return isBusy.Value; }
		}

		public string Name
		{
			get { return name; }
			set { this.RaiseAndSetIfChanged(ref name, value); }
		}

		public ReactiveCommand<object> MessageCommand
		{
			get { return messageCommand; }
			set { this.RaiseAndSetIfChanged(ref messageCommand, value); }
		}

		public ReactiveCommand<object> HelloCommand
		{
			get { return helloCommand; }
			set { this.RaiseAndSetIfChanged(ref helloCommand, value); }
		}

		public ReactiveCommand<object> AnotherHello
		{
			get { return anotherHello; }
			set { this.RaiseAndSetIfChanged(ref anotherHello, value); }
		}

		public ReactiveCommand<object> YoLo
		{
			get { return yoLo; }
			set { this.RaiseAndSetIfChanged(ref yoLo, value); }
		}

		public ReactiveCommand<Unit> SlowCommand
		{
			get { return slowCommand; }
			set { this.RaiseAndSetIfChanged(ref slowCommand, value); }
		}
	}
}