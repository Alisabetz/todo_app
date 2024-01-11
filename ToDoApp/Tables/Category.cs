using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ToDoApp.Tables
{
    public class Category
    {

        SqlConnection conn = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;

        public Category()
        {

        }
        public DataTable GetTable()
        {
            DataTable categoryTable = new DataTable();

            try
            {
                conn = new SqlConnection("server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true");
                conn.Open();

                command = new SqlCommand("select * from Categories",conn);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                adapter = new SqlDataAdapter(command);
                adapter.Fill(categoryTable);

            }
            catch(SqlException)
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


            return categoryTable;
        }


    }
}
