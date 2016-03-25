using System.Collections.Generic;
using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class AnalyzeViewModel : ReactiveObject
	{
		public List<YearViewModel> YearModels
		{
			get { return _yearModels; }
			set { this.RaiseAndSetIfChanged(ref _yearModels, value); }
		}

		private List<YearViewModel> _yearModels;
	}
}