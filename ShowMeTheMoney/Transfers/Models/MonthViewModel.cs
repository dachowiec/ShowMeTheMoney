using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;

namespace ShowMeTheMoney.Transfers.Models
{
	public class MonthViewModel : ReactiveObject
	{
		public MonthViewModel(IList<Transfer> transfers)
		{
			Transfers = new ReactiveList<Transfer>();

			this.WhenAnyObservable(x => x.Transfers.ItemsAdded)
				.Select(_ => Transfers.Sum(x => x.Amount))
				.ToProperty(this, vm => vm.Expenditure, out expenditure);

			Transfers.Add(new Transfer{ Amount = 14});
		}

		public ReactiveList<Transfer> Transfers { get; set; }

		public decimal Expenditure { get { return expenditure.Value; } }

		readonly ObservableAsPropertyHelper<decimal> expenditure;
	}


}