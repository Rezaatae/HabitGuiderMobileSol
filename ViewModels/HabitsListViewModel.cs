using CommunityToolkit.Mvvm.ComponentModel;
using HabitGuiderMobileSol.Data;
using HabitGuiderMobileSol.Models;
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
                    foreach (var habit in habits)
                    {
                        Habits.Add(habit);
                    }
                }
            }, "Loading your habits...");
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
