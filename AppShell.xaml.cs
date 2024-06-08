using HabitGuiderMobileSol.Views;

namespace HabitGuiderMobileSol
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(HabitsListView), typeof(HabitsListView));
            Routing.RegisterRoute(nameof(NewHabitView), typeof(NewHabitView));
        }
    }
}
