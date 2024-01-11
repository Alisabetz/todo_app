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

        public Periodity()
        {
            GetTable();
        }
        public override DataTable GetTable()
        {
            table = new DataTable();

            try
            {
                conn = new SqlConnection(connStr);
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

        public override bool Add(ModelsInterface model)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override DataRow GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Modify(int id, ModelsInterface model)
        {
            throw new NotImplementedException();
        }

    }
