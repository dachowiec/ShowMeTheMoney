using System.Collections.Generic;
using System.Linq;
using ShowMeTheMoney.Model;

namespace ShowMeTheMoney.Other
{
	public class InMemoryCategoryDao : ICategoryDao
	{
		public IList<Category> GetAll()
		{
			return categories;
		}

		public void SetAll(IList<Category> newCategories)
		{
			CheckForDuplicates(newCategories);
			categories = newCategories;
		}

		private void CheckForDuplicates(IList<Category> newCategories)
		{
			var duplicateCategories = newCategories
				.GroupBy(x => x.Name)
				.Where(x => x.Count() > 1)
				.Select(x => x.Key).ToArray();

			if (duplicateCategories.Length > 0)
				throw new DuplicateCategoryException(duplicateCategories);

		}

		private IList<Category> categories = new List<Category>();
	}
}