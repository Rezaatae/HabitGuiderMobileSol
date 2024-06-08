using CommunityToolkit.Mvvm.ComponentModel;

namespace HabitGuiderMobileSol.ViewModels
{
    public partial class NewHabitViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isContinuousHabit;
    }


}
