using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataLayer;
using ToDo.DataLayer.Models;

namespace ToDoApp.Models
{
    public class CategoryModel: ModelsInterface
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } 
    }
}
