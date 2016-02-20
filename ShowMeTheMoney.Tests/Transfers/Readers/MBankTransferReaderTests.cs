using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Readers;

namespace ShowMeTheMoney.Tests.Transfers.Readers
{
	public class MBankTransferReaderTests
	{
		public void EmptyFile_Returns_EmptyCollection()
		{
			var reader = new MBankTransferReader(new MemoryStream());

			var result = reader.Read();

			result.Should().BeEmpty();
		}

		public void Read_Sample()
		{
			var stream =
				ResourceFileLoader.GetStream("ShowMeTheMoney.Tests.Transfers.Readers.res", "mbank.csv");
			var reader = new MBankTransferReader(stream);

			var result = reader.Read().ToList();

			result.Count.ShouldBeEquivalentTo(4);

			result.ShouldBeEquivalentTo(new List<Transfer>
				{
					new Transfer
					{
						Date = new DateTime(2010,12,18),
						Amount = -139.31M,
						Title = "TESCO POZNAN KASA N/POZNAN",
						RecipientAccountNumber = ""
					},
					new Transfer
					{
						Date = new DateTime(2010,12,24),
						Amount = -186.85M,
						Title = "PKN STACJA NR 1161 /POZNAN",
						RecipientAccountNumber = ""
					},
					new Transfer
					{
						Date = new DateTime(2010,12,28),
						Amount = -1100.51M,
						Title = "LOTOS PALIWA SF 224/POZNAN",
						RecipientAccountNumber = ""
					},
					new Transfer
					{
						Date = new DateTime(2010,12,8),
						Amount = -101.48M,
						Title = "/NIP//IDP//TXT/1//-            //                                 //",
						RecipientAccountNumber = "22222222222222222222222222"
					},
				});
		}
	}
}