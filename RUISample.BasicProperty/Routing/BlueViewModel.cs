using ReactiveUI;

namespace RUISample.Routing
{
	public class BlueViewModel : ReactiveObject, IRoutableViewModel
	{
		public BlueViewModel(IScreen screen)
		{
			HostScreen = screen;
		}

		public string UrlPathSegment { get { return "blue"; } }
		public IScreen HostScreen { get; private set; }
	}
}