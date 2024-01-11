using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Models;
using ToDoApp.Tables;
using System.Text.RegularExpressions;

namespace ToDoApp
{
    public partial class ProfileNameForm : Form
    {
        public enum Action{
            Add,
            Edit
        }
        public ProfileNameForm(int profileNumber,Action action)
        {
            InitializeComponent();
            GetProfileTable();
            ProfileNumber = profileNumber;

            this.action = action;
        }


        //Properties
        public int ProfileNumber { get; set; }
        SqlDataAdapter dataAdapter; // used in two methods
        DataTable profileTable; // holds profile table
        private Action action;

        //Methods
        public bool Validation()
        {
            if (IsProfileNameCorrect())
            {
                if (IsProfileNameRepeated())
                {
                    return true;
                }
            }

            return false;
        }
        public bool IsProfileNameRepeated()
        {
            for (int i = 0; i < profileTable.Rows.Count; i++)
            {
                if(profileNameTxtBox.Text.ToLowerInvariant() == profileTable.Rows[i][1].ToString().ToLowerInvariant())
                {
                    MessageBox.Show("this profile name has already taken.");
                    profileNameTxtBox.Text = string.Empty;
                    return false;
                }
            }

            return true;
        }
        public bool IsProfileNameCorrect()
        {
            Regex re = new Regex(@"^([A-Za-z]+ )+[A-Za-z0-9_]+$|^[A-Za-z0-9_]{3,20}$");
            if (profileNameTxtBox.Text != string.Empty && re.Match(profileNameTxtBox.Text).Success)
            {
                return true;
            }
            else
                MessageBox.Show(".نام پروفایل میتواند بین 3 تا 20 کلمه و 1 خط فاصله بین کلمات باشد");
            profileNameTxtBox.Text = string.Empty;
            return false;
        }
        public void GetProfileTable()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Profiles";
                command.ExecuteNonQuery();

                dataAdapter = new SqlDataAdapter(command);
                profileTable = new DataTable(Name);
                dataAdapter.Fill(profileTable);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool InsetProfile()
        {

            if (Validation())
            {

                ProfileModel model = new ProfileModel()
                {
                    ProfileName = profileNameTxtBox.Text.ToString(),
                };

                DataRow dataRow = profileTable.NewRow();
                dataRow[1] = model.ProfileName;
                dataRow[2] = ProfileNumber;

                profileTable.Rows.Add(dataRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                int result = dataAdapter.Update(profileTable.Select(null,null,DataViewRowState.Added));
          
                dataAdapter.Dispose();

                if (result != 0)
                {
                    return true;
                }
            }

            return false;
        }
        private bool EditProfile()
        {
            if (Validation())
            {
                for (int i = 0; i < profileTable.Rows.Count; i++)
                {
                    if (Convert.ToInt32(profileTable.Rows[i]["ProfileNumber"]) == ProfileNumber)
                    {
                        profileTable.Rows[i]["ProfileName"] = profileNameTxtBox.Text.ToString();
                        SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
                        int result = dataAdapter.Update(profileTable.Select(null, null, DataViewRowState.ModifiedCurrent));

                        if(result !=0)
                        {
                            return true;
                        }
                        MessageBox.Show("something went wrong !");
                    }
                }
            }

            return false;
        }

        //Events

        private void addProfileBtn_Click(object sender, EventArgs e)
        {
            if (action == Action.Add)
            {
                bool result = InsetProfile();
                if (result)
                {
                    MessageBox.Show("successfuly Created");
                    this.Dispose();
                }
            }
            else
            {
                bool result = EditProfile();
                if (result)
                {
                    MessageBox.Show("successfuly Edited");
                    this.Dispose();
                }
            }

          
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void profileNameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ProfileNameForm_Load(object sender, EventArgs e)
        {
            if (action == Action.Edit)
            {
                addProfileBtn.Text = "Edit";
            }
        }


    }
}
