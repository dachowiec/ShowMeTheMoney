using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

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
			stream.Position = 0;

			var transfers = new List<Transfer>();
			var csvReader = new CsvReader(new StringReader(GetContent()), GetConfiguration());

			while (csvReader.Read())
			{
				if (string.IsNullOrEmpty(csvReader.GetField<string>(0)))
					break;

				transfers.Add(new Transfer
				{
					Date = csvReader.GetField<DateTime>(0),
					Amount = decimal.Parse(csvReader.GetField<string>(6)),
					Title = csvReader.GetField<string>(3),
					RecipientAccountNumber = GetRecipientAccountNumber(csvReader)
				});
			}

			return transfers;
		}

		private static string GetRecipientAccountNumber(CsvReader csvReader)
		{
			return csvReader.GetField<string>(5).Trim(new[] { '\'' });
		}

		private string GetContent()
		{
			var reader = new StreamReader(stream);

			SkipHeader(reader);

			return reader.ReadToEnd();
		}

		private static void SkipHeader(StreamReader reader)
		{
			var toSkip = 38;
			while (toSkip-- > 0 && reader.ReadLine() != null)
			{
			}
		}

		private readonly Stream stream;
	}
}