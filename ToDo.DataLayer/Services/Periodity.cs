using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataLayer.Models;

namespace ToDoApp.Tables
{
    public class Periodity : ToDo.DataLayer.Repositories.IRepository
    {

        DataTable table;

        SqlConnection conn = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;
        public DataTable GetTable()
        {
            table = new DataTable();

            try
            {
                conn = new SqlConnection("server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true");
                conn.Open();

                command = new SqlCommand("select * from Categories", conn);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                command.Dispose();
            }


            return table;
        }

        public bool Add(ModelsInterface model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataRow GetById(int id)
        {
            throw new NotImplementedException();
        }


        public bool Modify(int id, ModelsInterface model)
        {
            throw new NotImplementedException();
        }
    }
}
