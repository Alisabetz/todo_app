using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataLayer;
using ToDo.DataLayer.Models;

namespace ToDo.DataLayer.Repositories
{
    public abstract class IRepository
    {
        public string connStr = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
        public abstract DataTable GetTable();
        public abstract DataRow GetById(int id);
        public abstract bool Add(ModelsInterface model);
        public abstract bool Delete(int id);
        public abstract bool Modify(int id, ModelsInterface model);

    }
}
