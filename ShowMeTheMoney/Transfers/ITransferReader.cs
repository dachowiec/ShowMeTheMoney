using System.Collections.Generic;

namespace ShowMeTheMoney.Transfers
{
	public interface ITransferReader
	{
		IList<RawTransfer> Read();
	}
}