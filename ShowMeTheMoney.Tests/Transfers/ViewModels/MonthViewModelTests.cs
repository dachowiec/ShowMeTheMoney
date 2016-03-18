using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using FluentAssertions;
using ReactiveUI;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Models;

namespace ShowMeTheMoney.Tests.Transfers.ViewModels
{
	public class MonthViewModelTests : ReactiveObject
	{
		private ReactiveList<int> list;

		public void InitialSum()
		{
			var sut = new MonthViewModel(new List<Transfer>());

			sut.Expenditure.Should().Be(14);

			list = new ReactiveList<int>();

			this.WhenAnyObservable(x => x.list.CountChanged)
				.Select(_ => 5)
				.ToProperty(this, vm => vm.Expenditure, out expenditure);

			list.Add(4);
			Console.WriteLine(Expenditure);
		}

		public int Expenditure { get { return expenditure.Value; } }

		ObservableAsPropertyHelper<int> expenditure;
	}
}