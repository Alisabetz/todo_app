using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataLayer.Models;

namespace ToDo.DataLayer.Models
{
    public class DeletedTasksModel : ModelsInterface
    {
        public int TaskId { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
