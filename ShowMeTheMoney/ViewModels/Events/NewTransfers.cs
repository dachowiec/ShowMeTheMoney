using System.Collections.Generic;
using ShowMeTheMoney.Transfers;

namespace ShowMeTheMoney.ViewModels.Events
{
	public class NewTransfers
	{
		public IList<Transfer> Transfers { get; set; }
	}
}