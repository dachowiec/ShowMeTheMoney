using ReactiveUI;
using ShowMeTheMoney.Transfers;

namespace ShowMeTheMoney.ViewModels
{
	public interface IFinancialPeriodViewModel
	{
		IReadOnlyReactiveList<Transfer> Transfers { get; }

		decimal Incomes { get; }

		decimal Expanses { get; }

		decimal Balance { get; }

		string DisplayName { get; }
	}
}