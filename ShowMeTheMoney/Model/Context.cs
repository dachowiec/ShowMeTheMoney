using ReactiveUI;

namespace ShowMeTheMoney.Model
{
	public class Context
	{
		public Context()
		{
			Categories = new ReactiveList<Category>();
		}

		public ReactiveList<Category> Categories { get; set; }

	}
}