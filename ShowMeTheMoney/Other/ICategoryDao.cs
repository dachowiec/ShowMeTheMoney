using System.Collections.Generic;

namespace ShowMeTheMoney.Other
{
	public interface ICategoryDao
	{
		IList<Cateogry> GetAll();

		void SetAll(IList<Cateogry> newCategories);
	}
}