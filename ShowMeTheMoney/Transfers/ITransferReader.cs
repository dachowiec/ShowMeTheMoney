using System.Collections.Generic;

namespace ShowMeTheMoney.Transfers
{
	public interface ITransferReader
	{
		IList<Transfer> Read();
	}
}