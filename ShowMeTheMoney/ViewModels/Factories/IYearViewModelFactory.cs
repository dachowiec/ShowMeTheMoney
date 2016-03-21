using System.Collections.Generic;

namespace ShowMeTheMoney.ViewModels.Factories
{
	public interface IYearViewModelFactory
	{
		List<YearViewModel> CreatForYears(params int[] years);
	}
}