using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Storage;
using ShowMeTheMoney.ViewModels.Factories;
using Xunit;

namespace ShowMeTheMoney.Tests.ViewModels.Factories
{
	public class YearViewModelFactoryTests
	{
		public YearViewModelFactoryTests()
		{
			transferDao = A.Fake<ITransferDao>();
			A.CallTo(() => transferDao.GetTransfers(2000, null, null))
				.ReturnsLazily(() => transactions2000);
			yearViewModelFactory = new YearViewModelFactory(transferDao);
		}

		[Fact]
		public void Create_Empty()
		{
			var result = yearViewModelFactory.CreatForYears();

			result.Should().BeEmpty();
		}

		[Fact]
		public void Create_SingleEmptyYear()
		{
			var result = yearViewModelFactory.CreatForYears(1900);

			result.Should().HaveCount(1);
			result.First().Year.Should().Be(1900);
		}

		[Fact]
		public void Create_WithMonths()
		{
			transactions2000 = new List<Transfer>
			{
				new Transfer
				{
					Raw = new RawTransfer { Amount = 15M, Date = new DateTime(2000,1,1), Title = "Ok"}
				},
				new Transfer
				{
					Raw = new RawTransfer { Amount = -10M, Date = new DateTime(2000,2,2), Title = "Not ok"}
				},
			};

			var result = yearViewModelFactory.CreatForYears(2000);

			var yearViewModel = result.First();

			yearViewModel.Months.Should().HaveCount(transactions2000.Count);

		}

		private readonly YearViewModelFactory yearViewModelFactory;
		private readonly ITransferDao transferDao;
		private List<Transfer> transactions2000 = new List<Transfer>();
	}
}