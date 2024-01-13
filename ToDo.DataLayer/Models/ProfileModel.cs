using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataLayer.Models;

namespace ToDo.DataLayer.Models
{
    public class ProfileModel : ModelsInterface
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
    }
}
