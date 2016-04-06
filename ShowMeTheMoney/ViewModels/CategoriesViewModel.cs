using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class CategoriesViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment { get; private set; }

		public IScreen HostScreen { get; private set; }
	}
}