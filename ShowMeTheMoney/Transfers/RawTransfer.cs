﻿using System;

namespace ShowMeTheMoney.Transfers
{
	public class RawTransfer
	{
		public DateTime Date { get; set; }

		public string Title
		{
			get { return _title; }
			set { _title = value ?? string.Empty; }
		}

		public decimal Amount { get; set; }

		public string RecipientAccountNumber
		{
			get { return _recipientAccountNumber; }
			set { _recipientAccountNumber = value ?? string.Empty; }
		}

		public override bool Equals(object obj)
		{
			var rawTransfer = obj as RawTransfer;

			if (rawTransfer == null)
				return false;

			if (ReferenceEquals(rawTransfer, this))
				return true;

			return Title.Trim() == rawTransfer.Title.Trim()
				&& Amount == rawTransfer.Amount
				&& Date == rawTransfer.Date;
		}

		public override int GetHashCode()
		{
			return Date.GetHashCode()
				& Amount.GetHashCode()
				| Title.Trim().GetHashCode()
				& RecipientAccountNumber.GetHashCode();
		}

		private string _title = string.Empty;
		private string _recipientAccountNumber = string.Empty;
	}
}