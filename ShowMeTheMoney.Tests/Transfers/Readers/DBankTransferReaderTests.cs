using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Readers;

namespace ShowMeTheMoney.Tests.Transfers.Readers
{
	public class DBankTransferReaderTests
	{
		public void EmptyFile_Returns_EmptyCollection()
		{
			var reader = new DBankTransferReader(new MemoryStream());

			var result = reader.Read();

			result.Should().BeEmpty();
		}

		public void ReadSample()
		{
			var stream = ResourceFileLoader.GetStream("ShowMeTheMoney.Tests.Transfers.Readers.res", "deutsche_bank.csv");
			var reader = new DBankTransferReader(stream);

			var result = reader.Read().ToList();

			result.Count.ShouldBeEquivalentTo(4);

			result.ShouldBeEquivalentTo(new List<Transfer>
				{
					new Transfer
					{
						Date = new DateTime(2016,1,19),
						Amount = 1000.61M,
						Title = "PRZELEW Z INNEGO BANKU Nr. dok.: 111111/1; Data waluty: 2016.01.19; Nadawca: 123 00000000000000000000000 Treść: Wynag rodzenie - styczeń 2016r.",
					},
					new Transfer
					{
						Date = new DateTime(2016,1,14),
						Amount = -17M,
						Title = "OPERACJA KARTĄ Treść: Zakup 2016-01-14, PLAC POBORU OPLAT N POL, 17.00 P LN 17.00 PLN, Karta: 123456-1234 EUR/PLN:",
					},
					new Transfer
					{
						Date = new DateTime(2016,1,14),
						Amount = -8.30M,
						Title = "OPERACJA KARTĄ Treść: Zakup 2016-01-14, GDDKiA Emilia SPO POL, 8.30 PLN 8 .30 PLN, Karta: 123456-1234 EUR/PLN:",
					},
					new Transfer
					{
						Date = new DateTime(2016,1,14),
						Amount = -132.18M,
						Title = "OPERACJA KARTĄ Treść: Zakup 2016-01-14, LOTOS PALIWA SF 224 POL, 132.18 P LN 132.18 PLN, Karta: 123456-1234 EUR/PLN:",
					},
				});
		} 
	}
}