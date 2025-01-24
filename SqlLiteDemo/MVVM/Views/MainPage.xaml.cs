using SqlLiteDemo.MVVM.ViewModels;

namespace SqlLiteDemo.MVVM.Views;

public partial class MainPage : ContentPage
{
	private MainPageViewModel _viewModel = new MainPageViewModel();
	public MainPage()
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}
}