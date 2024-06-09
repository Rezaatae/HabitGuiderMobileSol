using HabitGuiderMobileSol.Popups;
using HabitGuiderMobileSol.ViewModels;
using Mopups.Services;

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
        Preferences.Clear();
        await _viewModel.LoadHabitsAsync();
    }

    private void OnNewHabitBtnClicked(object sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new HabitTypeConfPopup());
    }
}