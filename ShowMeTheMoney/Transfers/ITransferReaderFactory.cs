using System;

namespace ShowMeTheMoney.Transfers
{
	public interface ITransferReaderFactory
	{
		ITransferReader Create(object data);

		string DisplayName { get; }

		string Image { get; }

		Type GetAcceptedType();
	}
}