using HabitGuiderMobileSol.ViewModels;

namespace HabitGuiderMobileSol.Views;

public partial class HabitsListView : ContentPage
{
    private readonly HabitsListViewModel _viewModel;
    public HabitsListView(HabitsListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadHabitsAsync();
    }
}