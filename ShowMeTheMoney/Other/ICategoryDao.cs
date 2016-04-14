using System.Collections.Generic;
using ShowMeTheMoney.Model;

namespace ShowMeTheMoney.Other
{
	public interface ICategoryDao
	{
		IList<Category> GetAll();

		void SetAll(IList<Category> newCategories);
	}
}