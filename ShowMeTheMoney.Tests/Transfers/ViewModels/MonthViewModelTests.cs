using System.Collections.Generic;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Models;

namespace ShowMeTheMoney.Tests.Transfers.ViewModels
{
	public class MonthViewModelTests
	{
		public void InitialSum()
		{
			var sut = new MonthViewModel(new List<Transfer>());

			sut.Expenditure.Should().Be(0);
		}
	}
}