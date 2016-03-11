using System;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ShowMeTheMoney.Transfers.Readers;

namespace ShowMeTheMoney.Transfers.Factories
{
	public class MBankTransferReaderFactory : ITransferReaderFactory
	{
		public ITransferReader Create(object data)
		{
			var stream = data as Stream;
			if(stream == null)
				throw new ArgumentException("Parameter is no a Stream","data");
			return new MBankTransferReader(stream);
		}

		public string DisplayName
		{
			get { return "mBank"; }
		}

		public string Image
		{
			get { return "pack://application:,,,/ShowMeTheMoney;component/images/mbank.jpg"; }
		}

		public Type GetAcceptedType()
		{
			return typeof (Stream);
		}
	}
}