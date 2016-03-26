using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ShowMeTheMoney.Transfers.Storage;

namespace ShowMeTheMoney.ViewModels.Factories
{
	public class FinancialperiodViewModelFactory : IFinancialperiodViewModelFactory
	{
		public FinancialperiodViewModelFactory(ITransferDao transferDao)
		{
			_transferDao = transferDao;
		}

		public List<IFinancialPeriodViewModel> CreatForYears(params int[] years)
		{
			var result = new List<IFinancialPeriodViewModel>();

			foreach (var year in years)
			{
				var transfers = _transferDao.GetTransfers(year, null, null);
				if (transfers.Count == 0)
					continue;
				result.Add(new FinancialPeriodViewModel(transfers, "Rok " + year));

				foreach (var month in Enumerable.Range(1, 12).Reverse())
				{
					var monthTransfers = transfers.Where(x => x.Raw.Date.Month == month).ToList();
					if (monthTransfers.Count == 0)
						continue;

					result.Add(new FinancialPeriodViewModel(monthTransfers, 
						CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)));
				}
			}

			return result;

			//var transfers = years.SelectMany(year => _transferDao.GetTransfers(year, null, null)).ToList();

			//if (transfers.Count == 0)


			//var min = transfers.Min(x => x.Raw.Date);
			//var max = transfers.Max(x => x.Raw.Date);

			//return new List<IFinancialPeriodViewModel>();
		}

		private readonly ITransferDao _transferDao;
	}
}