using HabitGuiderMobileSol.Views;

namespace HabitGuiderMobileSol.Popups;

public partial class HabitTypeConfPopup
{
	public HabitTypeConfPopup()
	{
		InitializeComponent();
	}

	private async void OnBinaryHabitTypeBtnClicked(object sender, EventArgs e)
	{
        Preferences.Set("CurrentHabitType", "Binary");
        Preferences.Set("LoadFromMopupPopup", 1);
        await Shell.Current.GoToAsync($"{nameof(NewHabitView)}");
    }

    private async void OnContinuousHabitTypeBtnClicked(object sender, EventArgs e)
    {
        Preferences.Set("CurrentHabitType", "Continuous");
        Preferences.Set("LoadFromMopupPopup", 1);
        await Shell.Current.GoToAsync($"{nameof(NewHabitView)}");
    }
}