using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Storage;
using ShowMeTheMoney.ViewModels.Factories;
using Xunit;

namespace ShowMeTheMoney.Tests.ViewModels.Factories
{
	public class FinancialperiodViewModelFactoryTests
	{
		[Fact]
		public void Empty()
		{
			var dao = A.Fake<ITransferDao>();

			var sut = new FinancialperiodViewModelFactory(dao);

			sut.CreatForYears(2010).Should().BeEmpty();
		}

		[Fact]
		public void SingleEntryCreatesYearAndMonh()
		{
			var dao = A.Fake<ITransferDao>();
			A.CallTo(() => dao.GetTransfers(2000, null, null))
				.Returns(new List<Transfer>
				{
					new Transfer
					{
						Raw = new RawTransfer
						{
							Amount = 10
						}
					}
				});

			var sut = new FinancialperiodViewModelFactory(dao);

			var result = sut.CreatForYears(2000);

			result.Should().NotBeEmpty();
			result.Count.Should().Be(2);
		}
	}
}