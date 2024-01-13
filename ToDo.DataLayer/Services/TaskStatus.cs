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
    public class TaskStatus : ToDo.DataLayer.Repositories.IRepository
    {

        DataTable table;

        SqlConnection conn = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;

        public TaskStatus()
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

                command = new SqlCommand("select * from TaskStatus", conn);
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
            try
            {
                if (model is ToDo.DataLayer.Models.TaskStatusModel inputModel)
                {
                    GetTable();

                    DataRow newRow = table.NewRow();
                    newRow[0] = inputModel.TaskId;
                    newRow[1] = inputModel.TaskStatus;
                    newRow[2] = inputModel.date;


                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    int r = adapter.Update(table.Select(null, null, DataViewRowState.Added));

                    if (r != 0)
                        return true;


                    return false;
                }
                else
                    throw new InvalidCastException($"Invalid Type for proccessing in {this.GetType().Name}");

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                adapter.Dispose();
            }
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override DataRow GetById(int id)
        {
            try
            {
                GetTable();

                if (table.Select($"{table.Columns[0].ColumnName} = {id}").Length > 0)
                {

                    DataRow row = table.Select($"{table.Columns[0].ColumnName} = {id}")[0];

                    return row;
                }
                else
                    throw new IndexOutOfRangeException($"id out of range : {this.GetType().Name}");

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                adapter.Dispose();
            }
        }

        public override bool Modify(int id, ModelsInterface model)
        {
            throw new NotImplementedException();
        }

    }
}
