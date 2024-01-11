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
    public interface IRepository
    {
        DataTable GetTable();
        DataRow GetById(int id);
        bool Add(ModelsInterface model);
        bool Delete(int id);
        bool Modify(int id, ModelsInterface model);

    }
}
