using System.Collections.Generic;

namespace ShowMeTheMoney.Transfers.Storage
{
	public interface ITransferDao
	{
		void Save(params Transfer[] transfers);

		List<Transfer> GetTransfers(int? year, int? month, int? day);
	}
}