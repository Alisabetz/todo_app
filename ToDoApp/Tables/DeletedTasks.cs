using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Tables
{
    public class DeletedTasks
    {
        SqlConnection conn = null;
        SqlCommand command = null;

        public DataTable GetTable(out SqlDataAdapter adapter)
        {
            DataTable deleteTable = new DataTable();

            try
            {
                conn = new SqlConnection("server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true");
                conn.Open();

                command = new SqlCommand("select * from DeletedTasks", conn);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                adapter = new SqlDataAdapter(command);
                adapter.Fill(deleteTable);

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


            return deleteTable;
        }
    }
}
