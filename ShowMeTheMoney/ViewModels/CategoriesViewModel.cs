using ReactiveUI;
using ShowMeTheMoney.Model;
using Splat;

namespace ShowMeTheMoney.ViewModels
{
	public class CategoriesViewModel : ReactiveObject, IRoutableViewModel
	{
		public CategoriesViewModel(IScreen screen)
		{
			HostScreen = screen;
			Categories = new ReactiveList<Category>(Locator.Current.GetService<Context>().Categories);
		}

		public ReactiveList<Category> Categories { get; set; }

		public string UrlPathSegment { get; set; }

		public IScreen HostScreen { get; set; }
	}
}