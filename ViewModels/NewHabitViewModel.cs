using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitGuiderMobileSol.Data;
using HabitGuiderMobileSol.Models;
using HabitGuiderMobileSol.Views;

namespace HabitGuiderMobileSol.ViewModels
{
    public partial class NewHabitViewModel : ObservableObject
    {
        private DatabaseContext _databaseContext;
        public NewHabitViewModel(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [ObservableProperty]
        private Habit _currentHabit = new();

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _busyText;

        [ObservableProperty]
        private bool _isContinuousHabit;

        [RelayCommand]
        private void SetCurrentHabit(Habit habit) => CurrentHabit = habit ?? new();

        [RelayCommand]
        private async Task SaveHabitAsync()
        {
            if (CurrentHabit is null)
                return;
            var (isValid, errorMessage) = CurrentHabit.Validate();
            if(!isValid)
            {
                await Shell.Current.DisplayAlert("Validation error", errorMessage, "Ok");
                return;
            }
            await ExecuteAsync(async () =>
            {
                if(CurrentHabit.Id == 0)
                {
                    // create
                    await _databaseContext.AddItemAsync<Habit>(CurrentHabit);
                }
                else
                {
                    //update
                    if (await _databaseContext.UpdateItemAsync<Habit>(CurrentHabit))
                    {
                        await Shell.Current.DisplayAlert("Success", "Habit updated successfully", "Ok");
                        return;
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Habit not found", "Ok");
                        return;
                    }
                }
                setCurrentHabitCommand.Execute(new());
            }, "Saving habit...");
        }

        private async Task ExecuteAsync(Func<Task> operation, string? busyText = null)
        {
            IsBusy = true;
            BusyText = busyText ?? "Processing...";
            try
            {
                await operation?.Invoke();
            }
            finally
            {
                IsBusy = false;
                BusyText = "Processing...";
            }
        }



    }


}
