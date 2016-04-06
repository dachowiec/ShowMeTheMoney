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
			get { return financialPeriods; }
			set { this.RaiseAndSetIfChanged(ref financialPeriods, value); }
		}

		private ReactiveList<IFinancialPeriodViewModel> financialPeriods;

		public IScreen HostScreen { get; set; }

		public string UrlPathSegment { get; set; }
	}
}