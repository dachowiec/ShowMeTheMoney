using ShowMeTheMoney.Transfers.Models;

namespace ShowMeTheMoney.Transfers.Storage
{
	public interface ITransferService
	{
		void SaveTransfers(params RawTransfer[] rawTransfers);

		YearModel GetByYear(int year);
	}
}