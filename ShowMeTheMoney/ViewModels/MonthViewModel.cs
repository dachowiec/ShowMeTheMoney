using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using ShowMeTheMoney.Transfers;

namespace ShowMeTheMoney.ViewModels
{
	public class MonthViewModel : ReactiveObject
	{
		public MonthViewModel(IEnumerable<Transfer> transfers)
		{
			Transfers = new ReactiveList<Transfer>(transfers);

			MonthName = Transfers.First().Raw.Date.ToString("MMMM");

			this.WhenAnyObservable(x => x.Transfers.Changed)
				.Select(_ => Transfers.Where(x => x.Raw.Amount > 0).Sum(x => x.Raw.Amount))
				.StartWith(Transfers.Where(x => x.Raw.Amount > 0).Sum(x => x.Raw.Amount))
				.ToProperty(this, vm => vm.Incomes, out income);

			this.WhenAnyObservable(x => x.Transfers.Changed)
				.Select(_ => Transfers.Where(x => x.Raw.Amount < 0).Sum(x => x.Raw.Amount))
				.StartWith(Transfers.Where(x => x.Raw.Amount < 0).Sum(x => x.Raw.Amount))
				.ToProperty(this, vm => vm.Expanses, out expenditure);

			this.WhenAnyValue(x => x.Incomes, x => x.Expanses)
				.Select(t => t.Item1 + t.Item2)
				.ToProperty(this, vm => vm.Balance, out balance);

		}

		public ReactiveList<Transfer> Transfers { get; private set; }

		public string MonthName { get; private set; }

		public decimal Incomes { get { return income.Value; } }

		public decimal Expanses { get { return expenditure.Value; } }

		public decimal Balance { get { return balance.Value; } }

		readonly ObservableAsPropertyHelper<decimal> expenditure;
		readonly ObservableAsPropertyHelper<decimal> income;
		readonly ObservableAsPropertyHelper<decimal> balance;
	}


}