using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using ShowMeTheMoney.Transfers;

namespace ShowMeTheMoney.ViewModels
{
	public class FinancialPeriodViewModel : IFinancialPeriodViewModel
	{
		public FinancialPeriodViewModel(IEnumerable<Transfer> transfers,string displayName)
		{
			Incomes = transfers.Where(x => x.Raw.Amount >= 0).Sum(x => x.Raw.Amount);
			Expanses = transfers.Where(x => x.Raw.Amount < 0).Sum(x => x.Raw.Amount);
			Balance = transfers.Sum(x => x.Raw.Amount);

			Transfers = new ReactiveList<Transfer>(transfers);
			DisplayName = displayName;
		}

		public string DisplayName { get; private set; }

		public IReadOnlyReactiveList<Transfer> Transfers { get; private set; }

		public decimal Incomes { get; private set; }

		public decimal Expanses { get; private set; }

		public decimal Balance { get; private set; }
	}
}