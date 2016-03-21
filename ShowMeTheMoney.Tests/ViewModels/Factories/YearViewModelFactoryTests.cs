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
			_dao = A.Fake<ITransferDao>();
			A.CallTo(() => _dao.GetTransfers(2000, null, null))
				.ReturnsLazily(() => _transactions2000);
			_sut = new YearViewModelFactory(_dao);
		}

		[Fact]
		public void Create_Empty()
		{
			var result = _sut.CreatForYears();

			result.Should().BeEmpty();
		}

		[Fact]
		public void Create_SingleEmptyYear()
		{
			var result = _sut.CreatForYears(1900);

			result.Should().HaveCount(1);
			result.First().Year.Should().Be(1900);
		}

		[Fact]
		public void Create_WithMonths()
		{
			_transactions2000 = new List<Transfer>
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

			var result = _sut.CreatForYears(2000);

			var yearViewModel = result.First();

			yearViewModel.Months.Should().HaveCount(_transactions2000.Count);

		}

		private readonly YearViewModelFactory _sut;
		private readonly ITransferDao _dao;
		private List<Transfer> _transactions2000 = new List<Transfer>();
	}
}