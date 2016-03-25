﻿using System.Collections.Generic;
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

			MonthName = transfers.First().Raw.Date.ToString("MMMM");

			this.WhenAnyObservable(x => x.Transfers.Changed)
				.Select(_ => Transfers.Where(x => x.Raw.Amount > 0).Sum(x => x.Raw.Amount))
				.StartWith(Transfers.Where(x => x.Raw.Amount > 0).Sum(x => x.Raw.Amount))
				.ToProperty(this, vm => vm.Incomes, out _income);

			this.WhenAnyObservable(x => x.Transfers.Changed)
				.Select(_ => Transfers.Where(x => x.Raw.Amount < 0).Sum(x => x.Raw.Amount))
				.StartWith(Transfers.Where(x => x.Raw.Amount < 0).Sum(x => x.Raw.Amount))
				.ToProperty(this, vm => vm.Expanses, out _expenditure);

			this.WhenAnyValue(x => x.Incomes, x => x.Expanses)
				.Select(t => t.Item1 + t.Item2)
				.ToProperty(this, vm => vm.Balance, out _balance);

		}

		public ReactiveList<Transfer> Transfers { get; private set; }

		public string MonthName { get; private set; }

		public decimal Incomes { get { return _income.Value; } }

		public decimal Expanses { get { return _expenditure.Value; } }

		public decimal Balance { get { return _balance.Value; } }

		readonly ObservableAsPropertyHelper<decimal> _expenditure;
		readonly ObservableAsPropertyHelper<decimal> _income;
		readonly ObservableAsPropertyHelper<decimal> _balance;
	}


}