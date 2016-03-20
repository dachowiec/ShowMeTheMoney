using System;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using Xunit;

namespace ShowMeTheMoney.Tests.Transfers
{
	public class RawTansferTests
	{
		[Fact]
		public void Transfer_Equals_Itself()
		{
			var transfer = GetSample();
			AreEqual(transfer, transfer);
		}

		[Fact]
		public void Transfer_Equals_EmptyObjects()
		{
			AreEqual(new RawTransfer(), new RawTransfer());
		}

		[Fact]
		public void Transfer_IsEqualTo_Differs_Date()
		{
			RunDifferent(t => t.Date = new DateTime(1900, 1, 1));
		}

		[Fact]
		public void Transfer_Equals_Differs_Amount()
		{
			RunDifferent(t => t.Amount = 999M);
		}

		[Fact]
		public void Transfer_Equals_Differs_Title()
		{
			RunDifferent(t => t.Title = "no");
		}

		[Fact]
		public void Transfer_Equals_TrueWhenTitleIsNullOrWhiteSpace()
		{
			var transfer = new RawTransfer { Title = " " };
			var transfer2 = new RawTransfer { Title = null };

			AreEqual(transfer, transfer2);
		}

		[Fact]
		public void Transfer_Equals_FalseWHenNull()
		{
			AreDifferent(new RawTransfer(), null);
		}

		private static void AreEqual(RawTransfer transfer, RawTransfer transfer2)
		{
			transfer.Equals(transfer2).Should().BeTrue();
			transfer.GetHashCode().Should().Be(transfer2.GetHashCode(),
				"When to objects are equal they should have same HashId");
		}

		private void RunDifferent(Action<RawTransfer> modifier)
		{
			var transfer = GetSample();
			modifier(transfer);
			AreDifferent(GetSample(), transfer);
		}

		private static void AreDifferent(RawTransfer transfer, RawTransfer transfer2)
		{
			transfer.Equals(transfer2).Should().BeFalse();
		}

		private RawTransfer GetSample()
		{
			return new RawTransfer
			{
				Title = "yes",
				Amount = 15M,
				Date = new DateTime(2016, 10, 10),
				RecipientAccountNumber = "111"
			};
		}


	}
}