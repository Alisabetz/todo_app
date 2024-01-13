using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataLayer.Models;

namespace ToDoApp.Tables
{
    public class Task : ToDo.DataLayer.Repositories.IRepository
    {

        DataTable table;

        SqlConnection conn = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;

        public Task()
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
            try
            {
                if (model is ToDo.DataLayer.Models.TasksModel inputModel)
                {
                    GetTable();

                    DataRow newRow = table.NewRow();
                    newRow[1] = inputModel.TaskName;
                    newRow[2] = inputModel.ProfileId;
                    newRow[3] = inputModel.CategoryId;
                    newRow[4] = inputModel.PeriodityId;
                    if (inputModel.StartTime == TimeSpan.Zero)
                        newRow[5] = DBNull.Value;
                    else
                        newRow[5] = inputModel.StartTime;
                    newRow[6] = inputModel.UntilTime;
                    newRow[7] = inputModel.StartDate;
                    newRow[8] = inputModel.DeadLine;
                    if (inputModel.Descripton == string.Empty)
                        newRow[9] = DBNull.Value;
                    else
                        newRow[9] = inputModel.Descripton;

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
            try
            {
                GetTable();

                if (table.Select($"{table.Columns[0].ColumnName} = {id}").Length > 0)
                {

                    DataRow deleteRow = table.Select($"{table.Columns[0].ColumnName} = {id}")[0];

                    table.Rows.Remove(deleteRow);

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    int r = adapter.Update(table.Select(null, null, DataViewRowState.Deleted));

                    if (r != 0)
                        return true;


                    return false;
                }
                else
                    throw new IndexOutOfRangeException($"Invalid id for delete proccessing in {this.GetType().Name}");

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
            try
            {
                GetTable();

                if (table.Select($"{table.Columns[0].ColumnName} = {id}").Length > 0)
                {
                    if (model is ToDo.DataLayer.Models.TasksModel inputModel)
                    {
                        DataRow editedRow = table.Select($"{table.Columns[0].ColumnName} = {id}")[0];

                        editedRow[1] = inputModel.TaskName;
                        editedRow[2] = inputModel.ProfileId;
                        editedRow[3] = inputModel.CategoryId;
                        editedRow[4] = inputModel.PeriodityId;
                        if (inputModel.StartTime == TimeSpan.Zero)
                            editedRow[5] = DBNull.Value;
                        else
                            editedRow[5] = inputModel.StartTime;
                        editedRow[6] = inputModel.UntilTime;
                        editedRow[7] = inputModel.StartDate;
                        editedRow[8] = inputModel.DeadLine;
                        if (inputModel.Descripton == string.Empty)
                            editedRow[9] = DBNull.Value;
                        else
                            editedRow[9] = inputModel.Descripton;

                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        int r = adapter.Update(table.Select(null, null, DataViewRowState.ModifiedCurrent));

                        if (r != 0)
                            return true;
                    }
                    else
                        throw new InvalidCastException($"Invalid Type for proccessing in : {this.GetType().Name}");

                }
                else
                    throw new IndexOutOfRangeException($"id out of range : {this.GetType().Name}");

                return false;

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


    }
}
