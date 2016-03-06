using System;
using System.Runtime.InteropServices;
using ReactiveUI;

namespace RUISample.Routing
{
	public class RoutingViewModel : ReactiveObject, IScreen
	{
		public RoutingViewModel()
		{
			Router = new RoutingState();
			NavigateRedCommand = ReactiveCommand.Create();
			NavigateRedCommand.Subscribe(_ => Router.Navigate.Execute(new RedViewModel(this)));

			NavigateBlueCommand = ReactiveCommand.Create();
			NavigateBlueCommand.Subscribe(_ => Router.Navigate.Execute(new BlueViewModel(this)));
		}

		public ReactiveCommand<object> NavigateRedCommand { get; private set; }

		public ReactiveCommand<object> NavigateBlueCommand { get; private set; }

		public RoutingState Router { get; private set; }
	}
}