using System.Windows;
using ReactiveUI;
using ShowMeTheMoney.ViewModels;

namespace ShowMeTheMoney.Views
{
	/// <summary>
	/// Interaction logic for CategoriesView.xaml
	/// </summary>
	public partial class CategoriesView : IViewFor<CategoriesViewModel>
	{
		public CategoriesView()
		{
			InitializeComponent();
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = value as CategoriesViewModel; }
		}

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
			"ViewModel", typeof (CategoriesViewModel), typeof (CategoriesView), new PropertyMetadata(default(CategoriesViewModel)));

		public CategoriesViewModel ViewModel
		{
			get { return (CategoriesViewModel) GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}
	}
}
