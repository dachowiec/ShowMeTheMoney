using System;
using System.IO;
using ShowMeTheMoney.Transfers.Readers;

namespace ShowMeTheMoney.Transfers.Factories
{
	public class DbBankTransferReaderFactory : ITransferReaderFactory
	{
		public ITransferReader Create(object data)
		{
			var stream = data as Stream;
			if(stream == null)
				throw new ArgumentException("Parameter is not a stream","data");
			return new DBankTransferReader(stream);
		}

		public string DisplayName { get { return "Deutsche Bank"; } }

		public string Image
		{
			get { return "pack://application:,,,/ShowMeTheMoney;component/images/deutscheBank.png"; }
		}

		public Type GetAcceptedType()
		{
			return typeof (Stream);
		}
	}
}