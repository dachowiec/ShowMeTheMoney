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

		public void SetAll(IList<Cateogry> categories)
		{
			CheckForDuplicates(categories);
			this.categories = categories;
		}

		private void CheckForDuplicates(IList<Cateogry> cateogries)
		{
			var duplicateCategories = cateogries
				.GroupBy(x => x.Name)
				.Where(x => x.Count() > 1)
				.Select(x => x.Key).ToArray();

			if (duplicateCategories.Length > 0)
				throw new DuplicateCategoryException(duplicateCategories);

		}

		private IList<Cateogry> categories = new List<Cateogry>();
	}
}