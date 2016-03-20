using System.Collections.Generic;
using ShowMeTheMoney.Transfers;

namespace ShowMeTheMoney.ViewModels.Events
{
	public class NewTransfers
	{
		public IList<RawTransfer> Transfers { get; set; }
	}
}