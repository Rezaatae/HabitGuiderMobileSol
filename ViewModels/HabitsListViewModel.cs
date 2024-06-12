using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabitGuiderMobileSol.Data;
using HabitGuiderMobileSol.Models;
using HabitGuiderMobileSol.Popups;
using Mopups.Services;
using System.Collections.ObjectModel;


namespace HabitGuiderMobileSol.ViewModels
{
    public partial class HabitsListViewModel : ObservableObject
    {
        private readonly DatabaseContext _databaseContext;
        public HabitsListViewModel(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [ObservableProperty]
        private ObservableCollection<Habit> _habits = new();

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _busyText;

        public async Task LoadHabitsAsync()
        {
            await ExecuteAsync(async () =>
            {
                var habits = await _databaseContext.GetAllAsync<Habit>();
                if (habits is not null && habits.Any())
                {
                    Habits ??= new ObservableCollection<Habit>();
                    if (Habits.Count != 0)
                    {
                        Habits.Clear();
                    }
                    foreach (var habit in habits)
                    {
                        Habits.Add(habit);
                    }
                }
            }, "Loading your habits...");
        }

        [RelayCommand]
        private void LaunchHabitLogPopup(int id)
        {
            Console.WriteLine("reztest logg habit id " + id);
            Preferences.Set("CurrentHabitId", id);
            MopupService.Instance.PushAsync(new CreateHabitLogPopup());
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
