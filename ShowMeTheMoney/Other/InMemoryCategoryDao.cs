using System.Collections.Generic;
using System.Linq;

namespace ShowMeTheMoney.Other
{
	public class InMemoryCategoryDao : ICategoryDao
	{
		public IList<Cateogry> GetAll()
		{
			return categories;
		}

		public void SetAll(IList<Cateogry> newCategories)
		{
			CheckForDuplicates(newCategories);
			categories = newCategories;
		}

		private void CheckForDuplicates(IList<Cateogry> newCategories)
		{
			var duplicateCategories = newCategories
				.GroupBy(x => x.Name)
				.Where(x => x.Count() > 1)
				.Select(x => x.Key).ToArray();

			if (duplicateCategories.Length > 0)
				throw new DuplicateCategoryException(duplicateCategories);

		}

		private IList<Cateogry> categories = new List<Cateogry>();
	}
}