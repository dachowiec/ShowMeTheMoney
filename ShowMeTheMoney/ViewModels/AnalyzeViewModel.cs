using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class AnalyzeViewModel : ReactiveObject
	{
		private ReactiveList<IFinancialPeriodViewModel> _financialPeriods;

		public ReactiveList<IFinancialPeriodViewModel> FinancialPeriods
		{
			get { return _financialPeriods; }
			set { this.RaiseAndSetIfChanged(ref _financialPeriods, value); }
		}

		//public List<YearViewModel> YearModels
		//{
		//	get { return _yearModels; }
		//	set { this.RaiseAndSetIfChanged(ref _yearModels, value); }
		//}

		//private List<YearViewModel> _yearModels;
	}
}