using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Storage;

namespace ShowMeTheMoney.ViewModels.Factories
{
	public class YearViewModelFactory : IYearViewModelFactory
	{
		public YearViewModelFactory(ITransferDao dao)
		{
			_dao = dao;
		}

		public List<YearViewModel> CreatForYears(params int[] years)
		{
			return years.Select(CreateYear).ToList();
		}

		private YearViewModel CreateYear(int year)
		{
			return new YearViewModel(year)
			{
				Months = _dao.GetTransfers(year, null, null)
					.GroupBy(t => t.Raw.Date.Month)
					.Select(CreateMonth)
					.ToList()
			};
		}

		private MonthViewModel CreateMonth(IEnumerable<Transfer> monthTransfers)
		{
			return new MonthViewModel(monthTransfers);
		}

		private ITransferDao _dao;
	}
}