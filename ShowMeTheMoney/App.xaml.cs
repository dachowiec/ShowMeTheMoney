using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using ReactiveUI;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Factories;
using ShowMeTheMoney.ViewModels;
using ShowMeTheMoney.Views;
using Splat;

namespace ShowMeTheMoney
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			SetContainerRegistrations();

			RegisterExceptionHandlers();
		}

		private void SetContainerRegistrations()
		{
			Locator.CurrentMutable.Register(() => new DbBankTransferReaderFactory(), typeof(ITransferReaderFactory));
			Locator.CurrentMutable.Register(() => new MBankTransferReaderFactory(), typeof(ITransferReaderFactory));
			Locator.CurrentMutable.Register(() => new CsvReaderTransactionDialog(), typeof(CsvReaderTransactionDialog));
			Locator.CurrentMutable.Register(() => new SelectTransactionReaderDialogViewModel(), typeof(SelectTransactionReaderDialogViewModel));
			Locator.CurrentMutable.RegisterConstant(new EventAggregator(), typeof(IEventAggregator));
			Locator.CurrentMutable.Register(() => new EncouragementView(), typeof(IViewFor<EncouragementViewModel>));
			Locator.CurrentMutable.Register(() => new AnalyzeView(), typeof(IViewFor<AnalyzeViewModel>));
		}

		private static void RegisterExceptionHandlers()
		{
			AppDomain.CurrentDomain.UnhandledException +=
				(sender, args) => new ExceptionWindow(args.ExceptionObject as Exception).Show();

			Current.DispatcherUnhandledException += (sender, args) =>
			{
				new ExceptionWindow(args.Exception).Show();
				args.Handled = true;
			};
		}
	}
}
