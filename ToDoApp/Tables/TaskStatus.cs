using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Tables
{
    public class TaskStatus
    {
        SqlConnection conn = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;


        public DataTable GetTable()
        {
            DataTable taskTable = new DataTable();

            try
            {
                conn = new SqlConnection("server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true");
                conn.Open();

                command = new SqlCommand("select * from TaskStatus", conn);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                adapter = new SqlDataAdapter(command);
                adapter.Fill(taskTable);
                return taskTable;

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
                adapter.Dispose();
            }


        }
    }
}
