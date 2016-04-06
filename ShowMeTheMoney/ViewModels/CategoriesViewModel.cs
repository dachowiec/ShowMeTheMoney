using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class CategoriesViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment { get; set; }

		public IScreen HostScreen { get; set; }
	}
}