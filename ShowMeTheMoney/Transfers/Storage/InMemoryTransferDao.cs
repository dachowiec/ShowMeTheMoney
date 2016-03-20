using System;
using System.Collections.Generic;
using System.Linq;

namespace ShowMeTheMoney.Transfers.Storage
{
	public class InMemoryTransferDao : ITransferDao
	{
		public void Save(params Transfer[] transfers)
		{
			_transfers.AddRange(transfers);
		}

		public IList<Transfer> GetTransfers(int? year = null, int? month = null, int? day = null)
		{
			return _transfers.Where(GetPredicate(year, month, day)).ToList();
		}

		private Func<Transfer, bool> GetPredicate(int? year, int? month, int? day)
		{
			return transfer =>
			{
				if (year != null && year != transfer.Raw.Date.Year)
					return false;

				if (month != null && month != transfer.Raw.Date.Month)
					return false;

				if (day != null && day != transfer.Raw.Date.Day)
					return false;

				return true;
			};
		}

		private List<Transfer> _transfers = new List<Transfer>();
	}
}