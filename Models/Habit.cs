using SQLite;

namespace HabitGuiderMobileSol.Models
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
        public int Importance{ get; set; }
        public int Target { get; set; }
        public string UnitName { get; set; }
        public string Frequency { get; set; }
        public string Color { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Habit Clone() => MemberwiseClone() as Habit;
    }
}
