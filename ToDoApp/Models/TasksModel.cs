using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class TasksModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int ProfileId { get; set; }
        public int CategoryId { get; set; }
        public int PeriodityId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan UntilTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string Descripton { get; set; }
    }
}
