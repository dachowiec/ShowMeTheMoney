using System.Collections.Generic;
using FluentAssertions;
using ReactiveUI;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.ViewModels;
using Xunit;

namespace ShowMeTheMoney.Tests.Transfers.ViewModels
{
	public class MonthViewModelTests : ReactiveObject
	{
		[Fact]
		public void Expanses_Value()
		{
			var sut = new MonthViewModel(new List<Transfer>
			{
				new Transfer
				{
					Raw = new RawTransfer { Amount = -14M }
				},
				new Transfer
				{
					Raw = new RawTransfer { Amount = -10 }
				}
				
			});

			sut.Expanses.Should().Be(-24M);

			sut.Transfers.Add(new Transfer { Raw = new RawTransfer { Amount = -5 } });

			sut.Expanses.Should().Be(-29M);
		}

		[Fact]
		public void Income_Value()
		{
			var sut = new MonthViewModel(new List<Transfer>
			{
				Transfer.FromRaw(new RawTransfer { Amount = 11M }),
				Transfer.FromRaw(new RawTransfer { Amount = 12M })
			});

			sut.Incomes.Should().Be(23M);

			sut.Transfers.Add(Transfer.FromRaw(new RawTransfer { Amount = 1 }));

			sut.Incomes.Should().Be(24M);
		}

		[Fact]
		public void Income_And_Expenditure_Value()
		{
			var sut = new MonthViewModel(new List<Transfer> { Transfer.FromRaw(new RawTransfer { Amount = -5M }),
				Transfer.FromRaw(new RawTransfer { Amount = 44M } )});

			sut.Incomes.Should().Be(44M);
			sut.Expanses.Should().Be(-5M);
		}

		[Fact]
		public void Result_Value()
		{
			var sut = new MonthViewModel(new List<Transfer> { 
				Transfer.FromRaw(new RawTransfer { Amount = -5M }), 
				Transfer.FromRaw(new RawTransfer { Amount = 44M })
			});

			sut.Balance.Should().Be(39M);

			sut.Transfers.Add(Transfer.FromRaw(new RawTransfer { Amount = 15M }));

			sut.Balance.Should().Be(54M);
			sut.Incomes.Should().Be(59M);
			sut.Expanses.Should().Be(-5M);
		}

	}
}