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

    private void OnColorPickerClicke(object sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new ColorPickerPopup());
    }
}