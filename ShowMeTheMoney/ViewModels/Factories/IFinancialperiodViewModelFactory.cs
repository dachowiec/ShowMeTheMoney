using System.Collections.Generic;

namespace ShowMeTheMoney.ViewModels.Factories
{
	public interface IFinancialperiodViewModelFactory
	{
		List<IFinancialPeriodViewModel> CreatForYears(params int[] years);
	}
}