using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class DeletedTasksModel
    {
        public int TaskId { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
