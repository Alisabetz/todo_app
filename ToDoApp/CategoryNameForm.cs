using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Tables;
using ToDoApp.Models;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.Common;

namespace ToDoApp
{
    public partial class CategoryNameForm : Form
    {
        public CategoryNameForm()
        {
            InitializeComponent();
            GetCategoryTable();
        }

        DataTable categoryTable;
        SqlConnection conn = null;
        SqlCommand command = null;
        SqlDataAdapter dataAdapter;

        //Methods
        private bool Validation()
        {
            if (IsCategoryNameCorrect() is true)
            {
                if (IsCategoryNameRepeated() is false)
                {
                    return true;
                }
            }

            return false;
        }
        private bool IsCategoryNameRepeated()
        {
            for (int i = 0; i < categoryTable.Rows.Count; i++)
            {
                if (categoryNameTxtBox.Text.ToLowerInvariant() == categoryTable.Rows[i][1].ToString().ToLowerInvariant())
                {
                    MessageBox.Show("this profile name has already taken.");
                    categoryNameTxtBox.Text = string.Empty;

                    return true;
                }
               
            }

            return false;
        }
        private bool IsCategoryNameCorrect()
        {
            Regex re = new Regex(@"^([A-Za-z]+ )+[A-Za-z0-9_]+$|^[A-Za-z0-9_]{3,20}$");
            if (categoryNameTxtBox.Text == string.Empty || re.Match(categoryNameTxtBox.Text).Success==false)
            {
                MessageBox.Show(".نام پروفایل میتواند بین 3 تا 20 کلمه و 1 خط فاصله بین کلمات باشد");
                categoryNameTxtBox.Text = string.Empty;
                return false;
            }
            else
                return true;
        }
        private void GetCategoryTable()
        {
            
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
                conn.Open();

                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Categories";
                command.ExecuteNonQuery();

                dataAdapter = new SqlDataAdapter(command);
                categoryTable = new DataTable(Name);
                dataAdapter.Fill(categoryTable);
            }
            catch (Exception)
            {
                throw;
            }

        }
        private bool InsertCategory()
        {
            if (Validation() is true)
            {
                
                CategoryModel model = new CategoryModel
                {
                    CategoryName = categoryNameTxtBox.Text.ToString()
                };

                DataRow newRow = categoryTable.NewRow();
                newRow[1] = model.CategoryName;

                categoryTable.Rows.Add (newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                int i = dataAdapter.Update(categoryTable.Select(null, null,DataViewRowState.Added));

                if(i!=0)
                {
                    conn.Dispose();
                    dataAdapter.Dispose();
                    command.Dispose();

                    return true;
                }                    
                else
                    MessageBox.Show("not added !");
                return false;

            }
            else
            {
                return false;
            }
        }


        //Events
        private void addProfileBtn_Click(object sender, EventArgs e)
        {
            if(InsertCategory())
            {
                MessageBox.Show("sucessfully created !");
            }

        }


    }
}
