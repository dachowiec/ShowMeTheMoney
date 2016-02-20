using System.IO;
using System.Linq;
using Should;
using ShowMeTheMoney.Transfers.Readers;

namespace ShowMeTheMoney.Tests.Transfers.Readers
{
	public class MBankTransferReaderTests
	{
		public void EmptyFile_Returns_EmptyCollection()
		{
			var reader = new MBankTransferReader(new MemoryStream());

			var result = reader.Read();

			result.ShouldBeEmpty();
		}

		public void Read_Sample()
		{
			var stream = 
				ResourceFileLoader.GetStream("ShowMeTheMoney.Tests.Transfers.Readers.res","mbank.csv");
			var reader = new MBankTransferReader(stream);

			var result = reader.Read().ToList();

			result.Count.ShouldEqual(4);
		}
	}
}