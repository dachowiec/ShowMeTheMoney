using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace ShowMeTheMoney.Transfers.Readers
{
	public class DBankTransferReader : ITransferReader
	{
		public DBankTransferReader(Stream stream)
		{
			this.stream = stream;
		}

		public IList<RawTransfer> Read()
		{
			var reader = new CsvReader(new StreamReader(stream), GetConfiguration());
			var transfers = new List<RawTransfer>();

			while (reader.Read())
			{
				transfers.Add(
					new RawTransfer
					{
						Date = reader.GetField<DateTime>(0),
						Amount = decimal.Parse(reader.GetField<string>(3)),
						Title = reader.GetField<string>(2)
					});
			}

			return transfers;
		}

		private CsvConfiguration GetConfiguration()
		{
			return new CsvConfiguration
			{
				Delimiter = ";",
				HasHeaderRecord = false
			};
		}

		private readonly Stream stream;
	}
}