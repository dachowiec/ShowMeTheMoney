using System.Collections.Generic;
using ReactiveUI;

namespace ShowMeTheMoney.ViewModels
{
	public class YearViewModel : ReactiveObject
	{
		public YearViewModel(int year)
		{
			Year = year;
		}

		public int Year { get; private set; }

		public List<MonthViewModel> Months { get; set; }
	}
}