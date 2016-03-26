using System.Collections.Generic;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.ViewModels;
using Xunit;

namespace ShowMeTheMoney.Tests.ViewModels
{
	public class FinancialPeriodViewModelTests
	{
		[Fact]
		public void ExpansesValue()
		{
			var sut = new FinancialPeriodViewModel(new List<Transfer>
			{
				new Transfer
				{
					Raw = new RawTransfer
					{
						Amount = 10
					}
				},
				new Transfer
				{
					Raw = new RawTransfer
					{
						Amount = -16
					}
				}
			}, "");

			sut.Incomes.Should().Be(10);
			sut.Expanses.Should().Be(-16);
			sut.Balance.Should().Be(-6);

		}
	}
}