﻿using System;
using System.Windows;
using Caliburn.Micro;
using ReactiveUI;
using ShowMeTheMoney.Model;
using ShowMeTheMoney.Other;
using ShowMeTheMoney.Transfers;
using ShowMeTheMoney.Transfers.Factories;
using ShowMeTheMoney.Transfers.Storage;
using ShowMeTheMoney.ViewModels;
using ShowMeTheMoney.Views;
using Splat;

namespace ShowMeTheMoney
{
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			SetContainerRegistrations();

			RegisterExceptionHandlers();
		}

		private void SetContainerRegistrations()
		{
			RegisterViews();

			Locator.CurrentMutable.Register(() => new DbBankTransferReaderFactory(), typeof(ITransferReaderFactory));
			Locator.CurrentMutable.Register(() => new MBankTransferReaderFactory(), typeof(ITransferReaderFactory));
			Locator.CurrentMutable.Register(() => new CsvReaderTransactionDialog(), typeof(CsvReaderTransactionDialog));
			Locator.CurrentMutable.Register(() => new SelectTransactionReaderDialogViewModel(), typeof(SelectTransactionReaderDialogViewModel));

			Locator.CurrentMutable.RegisterConstant(new EventAggregator(), typeof(IEventAggregator));

			Locator.CurrentMutable.RegisterConstant(new InMemoryTransferDao(), typeof(ITransferDao));
			Locator.CurrentMutable.RegisterConstant(new InMemoryCategoryDao(), typeof(ICategoryDao));

			var viewSettings = (ViewSettings)Resources["ViewSettings"];
			new StatePersister(new XmlFileStateDao()).Observe(viewSettings,
					Ploeh.Albedo.Properties.Select(() => viewSettings.FontSize));
			Locator.CurrentMutable.RegisterConstant(viewSettings, typeof(ViewSettings));
		}

		private void RegisterViews()
		{
			Locator.CurrentMutable.Register(() => new EncouragementView(), typeof(IViewFor<EncouragementViewModel>));
			Locator.CurrentMutable.Register(() => new AnalyzeView(), typeof(IViewFor<AnalyzeViewModel>));
			Locator.CurrentMutable.Register(() => new CsvReaderTransactionDialog(), typeof(IViewFor<SelectTransactionReaderDialogViewModel>));
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
