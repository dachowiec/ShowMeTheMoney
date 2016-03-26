using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.ViewModels;
using Xunit;

namespace ShowMeTheMoney.Tests.Transfers.ViewModels
{
	public class SelectTransactionReaderDialogViewModelTest
	{
		[Fact]
		public void ReadTransactions_CanExecute_FalseByDefault()
		{
			var fakeReader = A.Fake<ITransferReaderFactory>();

			var viewModel = new SelectTransactionReaderDialogViewModel(new List<ITransferReaderFactory> {fakeReader});

			viewModel.ReadTransactions.CanExecute(new object()).Should().BeFalse();
		}

		[Fact]
		public void ReadTransactions_CanExecute_TrueWhenFileAndReaderSelected()
		{
			var fakeReader = A.Fake<ITransferReaderFactory>();

			var viewModel = new SelectTransactionReaderDialogViewModel(new List<ITransferReaderFactory> { fakeReader });
			viewModel.SelectedFile = "fakeFile.csv";
			viewModel.SelectedReader = fakeReader;

			viewModel.ReadTransactions.CanExecute(new object()).Should().BeTrue();
		}

		[Fact]
		public void ReadTransactions_CanExecute_FalseWhenOnlyFileSelected()
		{
			var fakeReader = A.Fake<ITransferReaderFactory>();

			var viewModel = new SelectTransactionReaderDialogViewModel(new List<ITransferReaderFactory> { fakeReader });
			viewModel.SelectedFile = "fakeFile.csv";

			viewModel.ReadTransactions.CanExecute(new object()).Should().BeFalse();
		}

		[Fact]
		public void ReadTransactions_CanExecute_FalseWhenOnlyReaderSelected()
		{
			var fakeReader = A.Fake<ITransferReaderFactory>();

			var viewModel = new SelectTransactionReaderDialogViewModel(new List<ITransferReaderFactory> { fakeReader });
			viewModel.SelectedReader = fakeReader;
			viewModel.SelectedFile = "";

			viewModel.ReadTransactions.CanExecute(new object()).Should().BeFalse();
		}
	}
}