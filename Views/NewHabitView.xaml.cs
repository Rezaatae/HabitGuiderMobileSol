using HabitGuiderMobileSol.ViewModels;

namespace HabitGuiderMobileSol.Views;

public partial class NewHabitView : ContentPage
{
    private readonly NewHabitViewModel _viewModel;
    public NewHabitView(NewHabitViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;
    }
}