﻿using System.Collections.Generic;

namespace ShowMeTheMoney.Transfers
{
	public class Transfer
	{
		public RawTransfer Raw { get; set; }

		public string Category { get; set; }

		public List<string> Tags { get; set; }

		public static Transfer FromRaw(RawTransfer rawTransfer)
		{
			return new Transfer
			{
				Raw = rawTransfer
			};
		}
	}
}