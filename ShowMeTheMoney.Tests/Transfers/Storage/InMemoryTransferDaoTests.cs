using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Storage;
using Xunit;

namespace ShowMeTheMoney.Tests.Transfers.Storage
{
	public class InMemoryTransferDaoTests
	{
		[Fact]
		public void SaveOne()
		{
			var sut = new InMemoryTransferDao();

			var t1 = new Transfer
			{
				Raw = new RawTransfer { Date = new DateTime(2000, 1, 1) },
				Category = "Test",
				Tags = new List<string> { "1", "2", "3" }
			};
			var t2 = new Transfer
			{
				Raw = new RawTransfer { Date = new DateTime(2000, 2, 1) },
				Category = "Test",
				Tags = new List<string> { "1", "2", "3" }
			};

			sut.Save(t1, t2);

			var result = sut.GetTransfers(2000, 1, 1);

			result.Should().HaveCount(1);
			result.First().ShouldBeEquivalentTo(t1);

			result = sut.GetTransfers(2000, 2);
			result.Should().HaveCount(1);
			result.First().ShouldBeEquivalentTo(t2);

			result = sut.GetTransfers(2000);
			result.ShouldBeEquivalentTo(new List<Transfer> { t1, t2 });
		}
	}
}