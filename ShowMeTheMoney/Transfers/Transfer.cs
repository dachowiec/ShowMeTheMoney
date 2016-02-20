using System;

namespace ShowMeTheMoney.Transfers
{
	public class Transfer
	{
		public DateTime Date { get; set; }

		public string Title { get; set; }

		public decimal Amount { get; set; }

		public string RecipientAccountNumber { get; set; }

		public string AddtitionalInfo { get; set; }
	}
}