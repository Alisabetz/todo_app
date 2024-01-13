using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ToDo.DataLayer;
using ToDo.DataLayer.Models;
using ToDo.DataLayer.Repositories;
using ToDoApp.Models;
using System.Reflection;

namespace ToDoApp.Tables
{
    public class Category: ToDo.DataLayer.Repositories.IRepository
    {

        DataTable table;

        SqlConnection conn = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;

        public Category()
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
                if (model is ToDo.DataLayer.Models.CategoryModel inputModel)
                {
                    GetTable();

                    DataRow newRow = table.NewRow();
                    newRow[1] = inputModel.CategoryName;

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

                if (table.Select($"{table.Columns[0].ColumnName} = {id}").Length>0)
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
                    if (model is ToDo.DataLayer.Models.CategoryModel inputModel)
                    {
                        DataRow editedRow = table.Select($"{table.Columns[0].ColumnName} = {id}")[0];

                        editedRow[1] = inputModel.CategoryName;

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
