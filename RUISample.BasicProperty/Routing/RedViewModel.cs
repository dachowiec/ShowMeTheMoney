using ReactiveUI;

namespace RUISample.Routing
{
	public class RedViewModel : ReactiveObject, IRoutableViewModel
	{
		public RedViewModel(IScreen screen)
		{
			HostScreen = screen;
		}

		public string UrlPathSegment { get { return "Fake"; } }

		public IScreen HostScreen { get; private set; }
	}
}