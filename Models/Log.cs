using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitGuiderMobileSol.Models
{
    public class Log
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int HabitId { get; set; }
        public int Status { get; set; }
        public int Progress { get; set; }
        public Log Clone() => MemberwiseClone() as Log;
    }
}
