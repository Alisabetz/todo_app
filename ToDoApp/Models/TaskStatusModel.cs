using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class TaskStatusModel
    {
        public int TaskId { get; set; }
        public int TaskStatus { get; set; }
        public DateTime date { get; set; }
    }
}
