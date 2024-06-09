using SQLite;
using System.Diagnostics;

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
        public(bool IsValid, string? ErrorMessage) Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return (false, $"{nameof(Name)} is required.");
            } else if (Importance < 1 || Importance > 10)
            {
                return (false, $"{nameof(Importance)} is invalid, choose a value between 1 - 10");
            } else if (Target < 1)
            {
                return (false, $"{nameof(Target)} is invalid, choose a value greater than 0");
            } else if (string.IsNullOrWhiteSpace(Frequency) || Frequency == "Frequency")
            {
                return (false, $"{nameof(Frequency)} is invalid");
            }
            return (true, null);
        }
    }
}
