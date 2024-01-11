using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Data;

namespace ToDoApp.Tables
{
    public class Profiles
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter dataAdapter;

        public Profiles()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
            conn.Open();
        }

        public DataTable GetTable()
        {
            
            try
            {
                DataTable table = new DataTable();

                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from Profiles";
                command.ExecuteNonQuery();

                dataAdapter = new SqlDataAdapter(command);           
                dataAdapter.Fill(table);

                return table;
            }
            catch(SqlException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                command.Dispose();
                dataAdapter.Dispose();
            }

        }

    }
}
