using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class EncouragementViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment { get; set; }

		public IScreen HostScreen { get; set; }
	}
}