using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Models;
using ToDoApp.Tables;

namespace ToDoApp
{
    public partial class TasksForm : Form
    {
        public enum TaskMode
        {
            create,
            edit
        }
        public TasksForm(int id=0,int taskId=0,TaskMode mode=TaskMode.create)
        {
            InitializeComponent();
            SetCategoryComboBox();

            ProfileId = id;
            TaskId = taskId;
        }


        //props
        public int ProfileId { get; set; }
        public int TaskId { get; set; }
        private TaskMode taskMode;
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter dataAdapter;

        DataTable categoryTable = new Category().GetTable();
        DataTable perioTable = new Periodities().GetTable();
        DataTable taskStatusTable = new Tables.TaskStatus().GetTable();
        DataTable taskTabke;


        //Methods
        private bool Validation()
        {
            if (IsTaskNameCorrect() && IsCategorySelected() && IsPerioditySelected())
            {
                if (IsTimesSetCorrect() && IsDeadLineSet())
                {
                    if (IsDescValid())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsTaskNameCorrect()
        {
            string taskName = taskNameTxtBox.Text.ToString();

            if (string.IsNullOrEmpty(taskName) == false && string.IsNullOrWhiteSpace(taskName) == false)
            {
                Regex re = new Regex(@"^([A-Za-z]+ )+[A-Za-z0-9_]+$|^[A-Za-z0-9_]{3,20}$");
                if (re.Match(taskName).Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(".نام پروفایل میتواند بین 3 تا 20 کلمه و 1 خط فاصله بین کلمات باشد");
                    return false;
                }
            }
            else
            {
                MessageBox.Show(".نام پروفایل نمیتواند خالی باشد");
                taskNameTxtBox.Text = string.Empty;
            }
            return false;
        }
        private bool IsCategorySelected()
        {
            if (categoryCbox.SelectedIndex == -1)
            {
                MessageBox.Show("choose a category .");
                return false;
            }
            else
                return true;
        }
        private bool IsPerioditySelected()
        {
            if (perioChbox.SelectedIndex == -1)
            {
                MessageBox.Show("choose a periodity .");
                return false;
            }
            else
                return true;
        }
        private bool IsTimesSetCorrect()
        {
            int startHour = Convert.ToInt32(timePicker1.Value.Hour.ToString());
            int startMin = Convert.ToInt32(timePicker1.Value.Minute.ToString());

            int endHour = Convert.ToInt32(timePicker2.Value.Hour.ToString());
            int endMin = Convert.ToInt32(timePicker2.Value.Minute.ToString());

            int untilTime = Convert.ToInt32(untilTimePicker.Value.Hour.ToString());
            int endUntilTime = Convert.ToInt32(untilTimePicker.Value.Minute.ToString());

            bool timeToTime = timeToTimeChBox.Checked;
            bool untilTimeCheck = untilTimeChBox.Checked;

            if (timeToTime)
            {
                if (startHour > endHour && startMin > endMin)
                {
                    MessageBox.Show("your start time is after your end time !");
                }
                else if (startHour == endHour && startMin == endMin)
                {
                    MessageBox.Show("your start time and end time can not be same !");
                }
                else
                {
                    return true;
                }

            }
            else
            {
                string selectedDeadLine = deadLineCombo.SelectedItem.ToString().ToLower();
                int number = Convert.ToInt32(setDayNumeric.Value);

                if (selectedDeadLine == "day" && number == 1)
                {
                    int result = DateTime.Compare(untilTimePicker.Value, DateTime.Now);
                    if (result == -1)
                    {
                        MessageBox.Show($"your choosed time for today is passed ! the time is now {DateTime.Now.ToString("HH:mm")}");
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }


            return false;
        }
        private bool IsDeadLineSet()
        {
            object defaultItem = deadLineCombo.SelectedItem;

            if (defaultItem != null)
            {
                string selectedDeadLine = deadLineCombo.SelectedItem.ToString().ToLowerInvariant();
                int number = Convert.ToInt32(setDayNumeric.Value);


                if (selectedDeadLine == "month" && number > 12)
                {

                    MessageBox.Show("you cant choose more than 12 months");

                    return false;
                }
                else if (number == 0)
                {
                    MessageBox.Show("days of deadline can not be zero");
                }
                else if (selectedDeadLine == "week" && (number > 52))
                {

                    MessageBox.Show("you cant choose more than 52 week wich is a year");

                    return false;
                }

                return true;
            }
            else
            {
                MessageBox.Show("choose a deadline");
            }

            return false;
        }
        private bool IsDescValid()
        {
            string desc = desctiptionTxtBox.Text.ToString();

            if (string.IsNullOrEmpty(desc) == false && string.IsNullOrWhiteSpace(desc) == false)
            {
                Regex re = new Regex(@"^([A-Za-z]+ )+[A-Za-z0-9_]+$|^[A-Za-z0-9_]{5,40}$");
                if (re.Match(desc).Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("desc should be beetwen 5 to 30 characters");
                }
            }
            else
            {
                desctiptionTxtBox.Text = string.Empty;
                return true;
            }

            return false;
        }
        private void SetCategoryComboBox()
        {
            if (categoryTable.Rows.Count != 0)
            {
                for (int i = 0; i < categoryTable.Rows.Count; i++)
                {
                    string categoryName = categoryTable.Rows[i][1].ToString();
                    categoryCbox.Items.Add(categoryName);
                }
            }

        }
        private void GetTaskTable()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
                conn.Open();

                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Tasks";
                command.ExecuteNonQuery();

                dataAdapter = new SqlDataAdapter(command);
                taskTabke = new DataTable(Name);
                dataAdapter.Fill(taskTabke);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GetTaskStatusTable()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "server=desktop-iekfilg;database=ToDo_DB;integrated security=true;MultipleActiveResultSets=true";
                conn.Open();

                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from TaskStatus";
                command.ExecuteNonQuery();

                dataAdapter = new SqlDataAdapter(command);
                taskTabke = new DataTable(Name);
                dataAdapter.Fill(taskTabke);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool InsertTask()
        {
            string taskName = taskNameTxtBox.Text.ToString();
            string categoryName = categoryCbox.SelectedItem.ToString().ToLower();
            string perioName = perioChbox.SelectedItem.ToString().ToLower();
            TimeSpan startTime = timePicker1.Value.TimeOfDay;
            TimeSpan endTime = timePicker2.Value.TimeOfDay;
            TimeSpan untilTime = untilTimePicker.Value.TimeOfDay;
            string desc = desctiptionTxtBox.Text.ToString();

            TasksModel model;

            if (untilTimeChBox.Checked)
            {
                model = new TasksModel
                {
                    TaskName = taskName,
                    ProfileId = ProfileId,
                    CategoryId = Convert.ToInt32(categoryTable.Select($"CategoryName = '{categoryName}' ")[0][0]),
                    PeriodityId = Convert.ToInt32(perioTable.Select($"PeriodityName = '{perioName}' ")[0][0]),
                    UntilTime = untilTime,
                    StartDate = DateTime.Now,
                    DeadLine = CalculteDeadLine(untilTimePicker.Value),
                    Descripton = desc,

                };
            }
            else
            {
                model = new TasksModel
                {
                    TaskName = taskName,
                    ProfileId = ProfileId,
                    CategoryId = Convert.ToInt32(categoryTable.Select($"CategoryName = '{categoryName}' ")[0][0]),
                    PeriodityId = Convert.ToInt32(perioTable.Select($"PeriodityName = '{perioName}' ")[0][0]),
                    StartTime = startTime,
                    UntilTime = endTime,
                    StartDate = DateTime.Now,
                    DeadLine = CalculteDeadLine(timePicker2.Value),
                    Descripton = desc,
                };
            }

            GetTaskTable();

            DataRow newRow = taskTabke.NewRow();

            newRow[1] = model.TaskName;
            newRow[2] = model.ProfileId;
            newRow[3] = model.CategoryId;
            newRow[4] = model.PeriodityId;
            if (model.StartTime == TimeSpan.Zero)
                newRow[5] = DBNull.Value;
            else
                newRow[5] = model.StartTime;
            newRow[6] = model.UntilTime;
            newRow[7] = model.StartDate;
            newRow[8] = model.DeadLine;
            if (model.Descripton == string.Empty)
                newRow[9] = DBNull.Value;
            else
                newRow[9] = model.Descripton;

            taskTabke.Rows.Add(newRow);

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            int i = dataAdapter.Update(taskTabke.Select(null, null, DataViewRowState.Added));

            if (i != 0)
            {
                return true;
            }

            return false;
        }
        private DateTime CalculteDeadLine(DateTime endTime)
        {

            DateTime deadLine;

            string deadLineDate = deadLineCombo.SelectedItem.ToString().ToLowerInvariant();
            int deadLineTime = Convert.ToInt32(setDayNumeric.Value);

            if (deadLineDate == "day")
            {

                deadLine = endTime.AddDays(deadLineTime);
                DateTime today = DateTime.Now;

                if (setDayNumeric.Value == 1 && today.Subtract(deadLine).Days < 0)
                {
                    deadLine = endTime.AddHours(0);
                }
            }
            else if (deadLineDate == "week")
            {
                deadLine = endTime.AddDays(deadLineTime * 7);
            }
            else
            {
                deadLine = endTime.AddMonths(deadLineTime);
            }

            return deadLine;


        }

        private int GetDeadlineDays(DateTime startDate,DateTime deadLine)
        {
            TimeSpan r = deadLine.Subtract(startDate);

            return r.Days;
        }

        private void GetTaskDetails()
        {
            taskTabke = new Tables.Tasks().GetTable();
            DataRow editRow = taskTabke.Select($"id = {TaskId}")[0];

            TasksModel model = new TasksModel()
            {
                TaskName = editRow["TaskName"].ToString(),
                CategoryId = Convert.ToInt32(editRow["Category"]),
                PeriodityId = Convert.ToInt32(editRow["Periodity"]),
                StartTime = TimeSpan.Parse(editRow["StartTime"].ToString()),
                UntilTime = TimeSpan.Parse(editRow["UntilTime"].ToString()),
                StartDate = DateTime.Parse(editRow["StartDate"].ToString()),
                DeadLine = DateTime.Parse(editRow["DeadLine"].ToString()),
                Descripton = editRow["Description"].ToString()
            };

            taskNameTxtBox.Text = model.TaskName;
            for (int i = 0; i < categoryCbox.Items.Count; i++)
            {
                if (categoryCbox.Items[i].ToString() == categoryTable.Select($"Id = {model.CategoryId}")[0]["CategoryName"].ToString())
                {
                    categoryCbox.SelectedItem = categoryCbox.Items[i].ToString();
                }
            }
            for (int i = 0; i < perioChbox.Items.Count; i++)
            {
                if (perioChbox.Items[i].ToString() == perioTable.Select($"Id = {model.PeriodityId}")[0]["PeriodityName"].ToString())
                {
                    perioChbox.SelectedItem = perioChbox.Items[i].ToString();
                }
            }
            MessageBox.Show(model.StartTime.ToString());
            if (string.IsNullOrEmpty(model.StartTime.ToString()))
            {
                untilTimeChBox.Checked = true;
                timeToTimeChBox.Checked = false;

                untilTimePicker.Value = DateTime.Parse(model.UntilTime.ToString());
            }
            else
            {
                untilTimeChBox.Checked = false;
                timeToTimeChBox.Checked = true;

                timePicker1.Value = DateTime.Parse(model.StartTime.ToString());
                timePicker2.Value = DateTime.Parse(model.UntilTime.ToString());
            }

            setDayNumeric.Value = GetDeadlineDays(model.StartDate, model.DeadLine);
            deadLineCombo.SelectedItem = deadLineCombo.Items[0];
            if (string.IsNullOrEmpty(model.Descripton)==false)
            {
                desctiptionTxtBox.Text = model.Descripton;
            }
        }
        private bool UpdateTask()
        {
            string taskName = taskNameTxtBox.Text.ToString();
            string categoryName = categoryCbox.SelectedItem.ToString().ToLower();
            string perioName = perioChbox.SelectedItem.ToString().ToLower();
            TimeSpan startTime = timePicker1.Value.TimeOfDay;
            TimeSpan endTime = timePicker2.Value.TimeOfDay;
            TimeSpan untilTime = untilTimePicker.Value.TimeOfDay;
            string desc = desctiptionTxtBox.Text.ToString();

            TasksModel model;

            if (untilTimeChBox.Checked)
            {
                model = new TasksModel
                {
                    TaskName = taskName,
                    //ProfileId = ProfileId,
                    CategoryId = Convert.ToInt32(categoryTable.Select($"CategoryName = '{categoryName}' ")[0][0]),
                    PeriodityId = Convert.ToInt32(perioTable.Select($"PeriodityName = '{perioName}' ")[0][0]),
                    UntilTime = untilTime,
                    StartDate = DateTime.Now,
                    DeadLine = CalculteDeadLine(untilTimePicker.Value),
                    Descripton = desc,

                };
            }
            else
            {
                model = new TasksModel
                {
                    TaskName = taskName,
                    //ProfileId = ProfileId,
                    CategoryId = Convert.ToInt32(categoryTable.Select($"CategoryName = '{categoryName}' ")[0][0]),
                    PeriodityId = Convert.ToInt32(perioTable.Select($"PeriodityName = '{perioName}' ")[0][0]),
                    StartTime = startTime,
                    UntilTime = endTime,
                    StartDate = DateTime.Now,
                    DeadLine = CalculteDeadLine(timePicker2.Value),
                    Descripton = desc,
                };
            }

            GetTaskTable();

            DataRow newRow = taskTabke.Select($"Id = {TaskId}")[0];

            newRow[1] = model.TaskName;
            //newRow[2] = model.ProfileId;
            newRow[3] = model.CategoryId;
            newRow[4] = model.PeriodityId;
            if (model.StartTime == TimeSpan.Zero)
                newRow[5] = DBNull.Value;
            else
                newRow[5] = model.StartTime;
            newRow[6] = model.UntilTime;
            newRow[7] = model.StartDate;
            newRow[8] = model.DeadLine;
            if (model.Descripton == string.Empty)
                newRow[9] = DBNull.Value;
            else
                newRow[9] = model.Descripton;


            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            int i = dataAdapter.Update(taskTabke.Select(null, null, DataViewRowState.ModifiedCurrent));

            if (i != 0)
            {
                return true;
            }


            return false;
        }

        //Events
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            if (taskMode==TaskMode.edit)
            {
                if (Validation())
                {
                    bool result = UpdateTask();

                    if (result)
                    {
                        MessageBox.Show("Task updated !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Somthing went wrong");
                    }
                }
            }
            else
            {
                if (Validation())
                {
                    bool result = InsertTask();

                    if (result)
                    {
                        MessageBox.Show("Task Created");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Somthing went wrong");
                    }
                }
            }
           
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timeToTimeChBox_CheckedChanged(object sender, EventArgs e)
        {
            bool timeToTime = timeToTimeChBox.Checked;

            if (timeToTime)
            {
                untilTimeChBox.Checked = false;

                untilTimePicker.Enabled = false;
                timePicker1.Enabled = true;
                timePicker2.Enabled = true;
            }
            else
            {
                untilTimeChBox.Checked = true;
            }


        }
        private void untilTimeChBox_CheckedChanged(object sender, EventArgs e)
        {

            bool untilTimeCheck = untilTimeChBox.Checked;

            if (untilTimeCheck)
            {
                timeToTimeChBox.Checked = false;

                untilTimePicker.Enabled = true;
                timePicker1.Enabled = false;
                timePicker2.Enabled = false;
            }
            else
            {
                untilTimePicker.Enabled = false;
                timeToTimeChBox.Checked = true;
            }


        }
        private void TasksForm_Load(object sender, EventArgs e)
        {
            if (TaskId!=0)
            {
                taskMode = TaskMode.edit;
                addTaskBtn.Text = "Edit Task";
                GetTaskDetails();
            }
            else
            {
                taskMode = TaskMode.create;
            }

            timeToTimeChBox.Checked = true;
        }
        private void setDayNumeric_ValueChanged(object sender, EventArgs e)
        {

        }
        private void addCategoryBtn_Click(object sender, EventArgs e)
        {
            CategoryNameForm categoryForm = new CategoryNameForm();
            categoryForm.ShowDialog();
        }


    }
}
