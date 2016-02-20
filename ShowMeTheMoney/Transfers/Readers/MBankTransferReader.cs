using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace ShowMeTheMoney.Transfers.Readers
{
	public class MBankTransferReader : ITransferReader
	{
		public MBankTransferReader(Stream stream)
		{
			this.stream = stream;
		}

		private static CsvConfiguration GetConfiguration()
		{
			return new CsvConfiguration
			{
				Delimiter = ";",
				HasHeaderRecord = false,
				SkipEmptyRecords = false
			};
		}

		public IList<Transfer> Read()
		{
			var csvReader = new CsvReader();
			return new List<Transfer>();
			

			//while (csvReader.Read())
			//{
			//	if (csvReader.CurrentRecord == null)
			//		yield break;

			//	if (string.IsNullOrEmpty(csvReader.GetField<string>(0)))
			//		break;

			//	yield return new Transfer
			//	{
			//		Date = csvReader.GetField<DateTime>(0)
			//	};

			//}
		}

		private void SkipHeader()
		{
			var toSkip = 38;
			while (toSkip-- > 0 && reader.ReadLine() != null)
			{ }
		}

		private readonly TextReader reader;
		private Stream stream;
	}
}