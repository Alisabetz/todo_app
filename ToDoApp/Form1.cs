using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Tables;

namespace ToDoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        //Properties
        private DataTable profileTable { get; set; }
        IList<Button> deleteBtns;
        IList<Button> editBtns;
        SqlDataAdapter adapter;

        //Methods
        private DataRow GetProfileRow(int number)
        {
            profileTable = new Profiles().GetTable();
            for (int i = 0; i < profileTable.Rows.Count; i++)
            {
                DataRow row = profileTable.Rows[i];

                if (number == Convert.ToInt32(row["ProfileNumber"]))
                {
                    return profileTable.Rows[i];
                }

            }

            return null;
        }
        private void LoadProfiles()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (i == 1)
                {
                    profile1.Text = GetProfileRow(1) == null ? "----" : GetProfileRow(1)["ProfileName"].ToString();
                }
                if (i == 2)
                {

                    profile2.Text = GetProfileRow(2) == null ? "----" : GetProfileRow(2)["ProfileName"].ToString();
                }
                if (i == 3)
                {
                    profile3.Text = GetProfileRow(3) == null ? "----" : GetProfileRow(3)["ProfileName"].ToString();
                }
                if (i == 4)
                {
                    profile4.Text = GetProfileRow(4) == null ? "----" : GetProfileRow(4)["ProfileName"].ToString();
                }
            }
        }
        private DataTable GetProfileTable()
        {
            DataTable table = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
            conn.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Profiles";
            command.ExecuteNonQuery();

            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }
        private DataTable GetTaskTable()
        {
            DataTable table = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
            conn.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Tasks";
            command.ExecuteNonQuery();

            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }

        private bool AreYouSure()
        {
            DialogResult result = MessageBox.Show("Are you sure about delete ?","Delete Profile",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                return true;
            }

            return false;
        }
        private bool DeleteTasks(int profileId)
        {
            DataTable taskTable = GetTaskTable();


            for (int i = 0; i < taskTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(taskTable.Rows[i]["ProfileId"]) == profileId)
                {
                    taskTable.Rows[i].Delete();
                }
            }

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int result = adapter.Update(taskTable.Select(null, null, DataViewRowState.Deleted));  

            if (result!=0)
            {
                return true;
            }

            return false;
        }
        private bool DeleteProfile(int Id)
        {

            DeleteTasks(Id);
            profileTable = GetProfileTable();

            for (int i = 0; i < profileTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(profileTable.Rows[i]["ProfileNumber"]) == Id)
                {
                    profileTable.Rows[i].Delete();
                }
            }

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int result = adapter.Update(profileTable.Select(null, null, DataViewRowState.Deleted));
            
            if (result !=0)
            {
                return true;
            }

            return false;
        }
        private void VisibleButtonsCheck()
        {
           
            for (int i = 0; i < 4; i++)
            {
                if (GetProfileRow(i+1) == null)
                {
                    deleteBtns[i].Visible = false;
                    deleteBtns[i].Visible = false;

                    editBtns[i].Visible = false;
                    editBtns[i].Visible = false;
                }
                else
                {
                    deleteBtns[i].Visible = true;
                    deleteBtns[i].Visible = true;

                    editBtns[i].Visible = true;
                    editBtns[i].Visible = true;
                }
            }

        }

        //Events
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProfiles();
            deleteBtns = new List<Button>
            {
                deleteP1Btn,
                deleteP2Btn,
                deleteP3Btn,
                deleteP4Btn,
            };
            editBtns = new List<Button>
            {
                 EditP1Btn,
                 EditP2Btn,
                 EditP3Btn,
                 EditP4Btn,
            };

            VisibleButtonsCheck();
        }
        private void test_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.ShowDialog();
        }
        private void profile1_Click(object sender, EventArgs e)
        {
            if (GetProfileRow(1) == null)
            {
                ProfileNameForm profile = new ProfileNameForm(1, ProfileNameForm.Action.Add);
                profile.ShowDialog();
                LoadProfiles();
            }
            else
            {
                int profileId = Convert.ToInt32(GetProfileRow(1)[2]);
                ProfileForm profileForm = new ProfileForm(profileId);
                profileForm.ShowDialog();
            }

            VisibleButtonsCheck();
        }
        private void profile2_Click(object sender, EventArgs e)
        {
            if (GetProfileRow(2) == null)
            {
                ProfileNameForm profile = new ProfileNameForm(2, ProfileNameForm.Action.Add);
                profile.ShowDialog();
                LoadProfiles();

            }
            else
            {
                int profileId = Convert.ToInt32(GetProfileRow(2)[2]);
                ProfileForm profileForm = new ProfileForm(profileId);
                profileForm.ShowDialog();
            }
            VisibleButtonsCheck();

        }
        private void profile3_Click(object sender, EventArgs e)
        {
            if (GetProfileRow(3) == null)
            {
                ProfileNameForm profile = new ProfileNameForm(3, ProfileNameForm.Action.Add);
                profile.ShowDialog();
                LoadProfiles();
            }
            else
            {
                int profileId = Convert.ToInt32(GetProfileRow(3)[2]);
                ProfileForm profileForm = new ProfileForm(profileId);
                profileForm.ShowDialog();

            }
            VisibleButtonsCheck();

        }
        private void profile4_Click(object sender, EventArgs e)
        {
            if (GetProfileRow(4) == null)
            {
                ProfileNameForm profile = new ProfileNameForm(4,ProfileNameForm.Action.Add);
                profile.ShowDialog();
                LoadProfiles();

            }
            else
            {
                int profileId = Convert.ToInt32(GetProfileRow(4)[2]);
                ProfileForm profileForm = new ProfileForm(profileId);
                profileForm.ShowDialog();

            }
            VisibleButtonsCheck();

        }

        private void deleteP1Btn_Click(object sender, EventArgs e)
        {
            if (AreYouSure())
            {
                int rowNumber = Convert.ToInt32(GetProfileRow(1)["ProfileNumber"]);
                DeleteProfile(rowNumber);
                LoadProfiles();
                VisibleButtonsCheck();
            }
           
        }
        private void deleteP2Btn_Click(object sender, EventArgs e)
        {

            if (AreYouSure())
            {
                int rowNumber = Convert.ToInt32(GetProfileRow(2)["ProfileNumber"]);
                DeleteProfile(rowNumber);
                LoadProfiles();
                VisibleButtonsCheck();
            }
           
        }
        private void deleteP3Btn_Click(object sender, EventArgs e)
        {

            if (AreYouSure())
            {
                int rowNumber = Convert.ToInt32(GetProfileRow(3)["ProfileNumber"]);
                DeleteProfile(rowNumber);
                LoadProfiles();
                VisibleButtonsCheck();
            }
           
        }
        private void deleteP4Btn_Click(object sender, EventArgs e)
        {

            if (AreYouSure())
            {
                int rowNumber = Convert.ToInt32(GetProfileRow(4)["ProfileNumber"]);
                DeleteProfile(rowNumber);
                LoadProfiles();
                VisibleButtonsCheck();
            }
           
        }

        private void EditP1Btn_Click(object sender, EventArgs e)
        {
            ProfileNameForm profile = new ProfileNameForm(1, ProfileNameForm.Action.Edit);
            profile.ShowDialog();
            LoadProfiles();
        }
        private void EditP2Btn_Click(object sender, EventArgs e)
        {
            ProfileNameForm profile = new ProfileNameForm(2, ProfileNameForm.Action.Edit);
            profile.ShowDialog();
            LoadProfiles();

        }
        private void EditP3Btn_Click(object sender, EventArgs e)
        {
            ProfileNameForm profile = new ProfileNameForm(3, ProfileNameForm.Action.Edit);
            profile.ShowDialog();
            LoadProfiles();

        }
        private void EditP4Btn_Click(object sender, EventArgs e)
        {
            ProfileNameForm profile = new ProfileNameForm(4, ProfileNameForm.Action.Edit);
            profile.ShowDialog();
            LoadProfiles();

        }

    }
}
