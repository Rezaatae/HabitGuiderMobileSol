using HabitGuiderMobileSol.Popups;
using HabitGuiderMobileSol.ViewModels;
using Mopups.Services;

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

    private void OnColorPickerClicked(object sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new ColorPickerPopup());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (Preferences.Get("LoadFromMopupPopup", 3)==1)
        {
            MopupService.Instance.PopAsync();
        }
        if (Preferences.Get("CurrentHabitType", "None") == "Continuous")
        {
            _viewModel.IsContinuousHabit = true;
        }
        if (Preferences.Get("CurrentHabitType", "None") == "Binary")
        {
            _viewModel.IsContinuousHabit = false;
        }
        Preferences.Clear();
    }
}