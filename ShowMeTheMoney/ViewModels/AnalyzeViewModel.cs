using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class AnalyzeViewModel : ReactiveObject, IRoutableViewModel
	{
		public AnalyzeViewModel(IScreen screen)
		{
			HostScreen = screen;
		}

		public ReactiveList<IFinancialPeriodViewModel> FinancialPeriods
		{
			get { return _financialPeriods; }
			set { this.RaiseAndSetIfChanged(ref _financialPeriods, value); }
		}

		private ReactiveList<IFinancialPeriodViewModel> _financialPeriods;

		public IScreen HostScreen { get; set; }

		public string UrlPathSegment { get; set; }
	}
}