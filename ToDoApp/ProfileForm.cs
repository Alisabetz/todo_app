using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Tables;
using ToDoApp.Models;
using System.Runtime.InteropServices.ComTypes;

namespace ToDoApp
{
    public partial class ProfileForm : Form
    {
        private enum Display
        {
            Done,
            UnDone,
            All
        }
        private enum Sort
        {
            Time,
            Date,
            Periordity
        }

        public ProfileForm(int profileId)
        {
            InitializeComponent();
            ProfileId = profileId;
        }


        int YLocationPanel = 170;
        private Display display = Display.All;
        private Sort sort = Sort.Periordity;

        DataTable Tasktable = new Tasks().GetTable();
        DataTable categoryTable = new Category().GetTable();
        DataTable perioTable = new Periodities().GetTable();
        DataTable taskStatusTable = new Tables.TaskStatus().GetTable();

        Panel[] panelGroups;


        //Properties
        private DataTable profileTable { get; set; }
        private int ProfileId { get; set; }
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter dataAdapter;

        //Methods
        private DataRow GetProfileRow(int id)
        {
            profileTable = new Profiles().GetTable();

            for (int i = 0; i < profileTable.Rows.Count; i++)
            {
                DataRow row = profileTable.Rows[i];

                if (id == Convert.ToInt32(row["ProfileNumber"]))
                {
                    return profileTable.Rows[i];
                }

            }

            return null;
        }
        private string CalculateDeadLine(int id)
        {
            Tasktable = new Tables.Tasks().GetTable();
            DateTime deadline = (DateTime)Tasktable.Select($"Id = {id}")[0]["DeadLine"];

            DateTime today = DateTime.Now;

            TimeSpan subtract = deadline.Subtract(today); //different of two times

            if (subtract.Days < 1)
            {
                return "today";
            }
            else if (subtract.Days > 1 && subtract.Days < 2 || subtract.Days == 1 && subtract.Hours < 1)
            {
                return $"Tommorow at : {deadline.Subtract(DateTime.Now).Hours}:{deadline.Subtract(DateTime.Now).Minutes}";
            }
            else
            {
                return $"{subtract.Days} day(s) , {subtract.Hours} hr(s)";
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
                Tasktable = new DataTable(Name);
                dataAdapter.Fill(Tasktable);
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
                Tasktable = new DataTable(Name);
                dataAdapter.Fill(taskStatusTable);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private DataTable SortTable(Sort sort)
        {
            Tasktable = new Tasks().GetTable();
            DataTable sortedTable = Tasktable.DefaultView.ToTable();

            if (sort == Sort.Time)
            {
                sortedTable.DefaultView.Sort = "StartTime ASC";
                sortedTable = sortedTable.DefaultView.ToTable();
            }
            else if (sort == Sort.Date)
            {
                sortedTable.DefaultView.Sort = "DeadLine ASC";
                sortedTable = sortedTable.DefaultView.ToTable();
            }
            else if (sort == Sort.Periordity)
            {
                sortedTable.DefaultView.Sort = "Periodity DESC";
                sortedTable = sortedTable.DefaultView.ToTable();
            }

            return sortedTable;
        }
        private DataTable DisplayTable(Display display)
        {
            Tasktable = new Tasks().GetTable();
            DataTable displayedTable = Tasktable.Clone();
            taskStatusTable = new Tables.TaskStatus().GetTable();

            if (display == Display.UnDone)
            {
                for (int i = 0; i < Tasktable.Rows.Count; i++)
                {
                    int taskId = Convert.ToInt32(Tasktable.Rows[i][0]);
                    if (IsTaskDoneable(taskId))
                    {
                        displayedTable.ImportRow(Tasktable.Rows[i]);
                    }
                }
            }
            else if (display == Display.Done)
            {
                for (int i = 0; i < Tasktable.Rows.Count; i++)
                {
                    int taskId = Convert.ToInt32(Tasktable.Rows[i][0]);
                    if (IsTaskDoneable(taskId) == false)
                    {
                        displayedTable.ImportRow(Tasktable.Rows[i]);
                    }
                }
            }
            else
            {
                displayedTable = new Tasks().GetTable();
            }

            return displayedTable;
        }
        private DataTable CombinateTables(DataTable sortedTable, DataTable displayedTable)
        {
            DataTable resultTable = Tasktable.Clone();
            if (display != Display.All)
            {
                for (int i = 0; i < sortedTable.Rows.Count; i++)
                {
                    int taskId1 = Convert.ToInt32(sortedTable.Rows[i][0]);

                    for (int j = 0; j < displayedTable.Rows.Count; j++)
                    {
                        int taskId2 = Convert.ToInt32(displayedTable.Rows[j][0]);

                        if (taskId1 == taskId2)
                        {
                            resultTable.ImportRow(sortedTable.Rows[i]);
                        }
                    }
                }
            }
            else
            {
                resultTable = sortedTable;
            }

            return resultTable;
        }

        private void CleanProfilePage()
        {
            if (panelGroups != null)
            {
                for (int i = 0; i < panelGroups.Length; i++)
                {
                    this.Controls.Remove(panelGroups[i]);
                }

            }

        }
        private bool IsTaskDoneable(int taskId)
        {
            if (IsTaskDeadLinePast(taskId) == false)
            {
                if (IsTaskDoneToday(taskId) == false)
                {
                    if (IsTaskFinishTimePast(taskId) == false)
                    {
                        return true;
                    }
                    else
                    {
                        FinishTask(taskId, 0, DateTime.Now);
                    }

                }

            }
            DeleteTask(taskId);


            return false;
        }
        private bool IsTaskDeadLinePast(int taskId)
        {
            Tasktable = new Tasks().GetTable();
            taskStatusTable = new Tables.TaskStatus().GetTable();

            DataRow taskRow = Tasktable.Select($"Id = {taskId}")[0];
            DateTime deadLine = DateTime.Parse(taskRow["DeadLine"].ToString());

            if (DateTime.Compare(deadLine, DateTime.Now) < 0)
            {
                return true;
            }

            return false;
        }
        private bool IsTaskDoneToday(int taskId)
        {
            Tasktable = new Tasks().GetTable();
            taskStatusTable = new Tables.TaskStatus().GetTable();

            DataRow taskRow = Tasktable.Select($"Id = {taskId}")[0];
            int id = Convert.ToInt32(taskRow[0]);

            for (int i = 0; i < taskStatusTable.Rows.Count; i++)
            {
                //int taskStatus = Convert.ToInt32(taskStatusTable.Rows[i][1]);
                int taskStatusId = Convert.ToInt32(taskStatusTable.Rows[i][0]);
                DateTime taskDoneDate = DateTime.Parse(taskStatusTable.Rows[i][2].ToString());

                if (id == taskStatusId)
                {
                    if (DateTime.Compare(taskDoneDate.Date, DateTime.Now.Date) == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private bool IsTaskFinishTimePast(int taskId)
        {
            Tasktable = new Tasks().GetTable();
            taskStatusTable = new Tables.TaskStatus().GetTable();

            DataRow taskRow = Tasktable.Select($"Id = {taskId}")[0];
            TimeSpan finishTime = TimeSpan.Parse(taskRow["UntilTime"].ToString());

            if (taskRow["StartTime"] == DBNull.Value)
            {

                if (TimeSpan.Compare(finishTime, DateTime.Now.TimeOfDay) == -1)
                {
                    return true;
                }
            }
            else if (TimeSpan.Compare(finishTime, DateTime.Now.TimeOfDay) != 1)
            {
                return true;
            }

            return false;
        }

        private bool FinishTask(int id, int status, DateTime date)
        {
            Tasktable = new Tasks().GetTable();
            taskStatusTable = new Tables.TaskStatus().GetTable();

            //DataRow finishedRow = Tasktable.Select($"Id = {id}")[0];

            TaskStatusModel model = new TaskStatusModel
            {
                TaskId = id,
                TaskStatus = status,
                date = date
            };

            DataRow newRow = taskStatusTable.NewRow();
            newRow[0] = model.TaskId;
            newRow[1] = model.TaskStatus;
            newRow[2] = model.date;

            taskStatusTable.Rows.Add(newRow);

            GetTaskStatusTable();

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            int i = dataAdapter.Update(taskStatusTable.Select(null, null, DataViewRowState.Added));

            if (i != 0)
            {
                return true;
            }

            return false;
        }
        private bool DeleteTask(int id)
        {
            Tasktable = new Tasks().GetTable();
            DataTable deletedTaskTable = new DeletedTasks().GetTable(out dataAdapter);

            DataRow deletedRow = Tasktable.Select($"id = {id}")[0];

            DeletedTasksModel tasksModel = new DeletedTasksModel
            {
                TaskId = Convert.ToInt32(deletedRow["id"]),
                DeadLine = DateTime.Parse(deletedRow["DeadLine"].ToString())
            };

            DataRow newRow = deletedTaskTable.NewRow();
            newRow[0] = tasksModel.TaskId;
            newRow[1] = tasksModel.DeadLine;

            deletedTaskTable.Rows.Add(newRow);

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            int i = dataAdapter.Update(deletedTaskTable.Select(null, null, DataViewRowState.Added));

            if (i != 0)
            {
                return true;
            }

            return false;
        }
        private async Task FinishPastTasks()
        {

            await Task.Run(() =>
            {
                Tasktable = new Tables.Tasks().GetTable();
                taskStatusTable = new Tables.TaskStatus().GetTable();

                DataRow[] profileTasks = Tasktable.Select($"ProfileId = {ProfileId}");

                for (int i = 0; i < profileTasks.Length; i++)
                {
                    int taskId = Convert.ToInt16(profileTasks[i][0]);

                    taskStatusTable.DefaultView.Sort = "date DESC";
                    taskStatusTable = taskStatusTable.DefaultView.ToTable();
                    DataRow[] taskStatus = taskStatusTable.Select($"task_id = {taskId}");

                    if (taskStatus.Length > 0)
                    {
                        DateTime lastStatusDate = DateTime.Parse(taskStatus[0]["date"].ToString());
                        DateTime deadLine = DateTime.Parse(profileTasks[i]["DeadLine"].ToString());
                        TimeSpan difference = DateTime.Now.Subtract(lastStatusDate);

                        if (DateTime.Now.Subtract(deadLine).Days < 0) // if now is ealier deadline
                        {
                            difference = DateTime.Now.Subtract(lastStatusDate);
                        }
                        else
                        {
                            difference = deadLine.Subtract(lastStatusDate);
                        }

                        int differenceDays = Convert.ToInt32(difference.Days+1);

                        if (differenceDays == 1)
                        {
                            if (IsTaskFinishTimePast(taskId))
                            {
                                FinishTask(taskId, 0, lastStatusDate.AddDays(1));
                            }
                        }
                        else if (differenceDays > 1)
                        {
                            for (int j = 0; j < differenceDays; j++)
                            {
                                if (j == differenceDays - 1 )
                                {
                                    if (IsTaskFinishTimePast(taskId))
                                    {
                                        FinishTask(taskId, 0, lastStatusDate.AddDays(j + 1));
                                    }
                                }
                                else
                                {
                                    FinishTask(taskId, 0, lastStatusDate.AddDays(j + 1));
                                }

                            }
                        }
                    }
                    else
                    {
                        DateTime StartDate = DateTime.Parse(profileTasks[i]["StartDate"].ToString());
                        DateTime deadLine = DateTime.Parse(profileTasks[i]["DeadLine"].ToString());
                        TimeSpan difference;

                        if (DateTime.Now.Subtract(deadLine).Days < 0)
                        {
                            difference = DateTime.Now.Subtract(StartDate);
                        }
                        else
                        {
                            difference = deadLine.Subtract(StartDate);
                        }

                        int differenceDays = Convert.ToInt32(difference.Days+1);
                        if (differenceDays == 1)
                        {
                            if (IsTaskFinishTimePast(taskId))
                            {
                                FinishTask(taskId, 0, DateTime.Now);
                            }
                        }
                        else if (differenceDays > 1)
                        {
                            for (int j = 0; j < differenceDays; j++)
                            {
                                if (j == differenceDays - 1)
                                {
                                    if (IsTaskFinishTimePast(taskId))
                                    {
                                        FinishTask(taskId, 0, StartDate.AddDays(j + 1));
                                    }

                                }
                                else
                                {
                                    FinishTask(taskId, 0, StartDate.AddDays(j + 1));
                                }
                            }
                        }
                    }


                }
            });
        }
        private void FinishPastTasks2()
        {

            Tasktable = new Tables.Tasks().GetTable();
            taskStatusTable = new Tables.TaskStatus().GetTable();

            DataRow[] profileTasks = Tasktable.Select($"ProfileId = {ProfileId}");

            for (int i = 0; i < profileTasks.Length; i++)
            {
                int taskId = Convert.ToInt16(profileTasks[i][0]);

                taskStatusTable.DefaultView.Sort = "date DESC";
                taskStatusTable = taskStatusTable.DefaultView.ToTable();
                DataRow[] taskStatus = taskStatusTable.Select($"task_id = {taskId}");

                if (taskStatus.Length > 0)
                {
                    DateTime lastStatusDate = DateTime.Parse(taskStatus[0]["date"].ToString());
                    DateTime deadLine = DateTime.Parse(profileTasks[i]["DeadLine"].ToString());
                    TimeSpan difference = DateTime.Now.Subtract(lastStatusDate);

                    if (DateTime.Now.Subtract(deadLine).Days < 0) // if now is ealier deadline
                    {
                        difference = DateTime.Now.Subtract(lastStatusDate);
                    }
                    else
                    {
                        difference = deadLine.Subtract(lastStatusDate);
                    }

                    int differenceDays = Convert.ToInt32(difference.Days);

                    if (differenceDays == 1)
                    {
                        if (IsTaskFinishTimePast(taskId))
                        {
                            FinishTask(taskId, 0, lastStatusDate.AddDays(1));
                        }
                    }
                    else if (differenceDays > 1)
                    {
                        for (int j = 0; j < differenceDays; j++)
                        {
                            if (j == differenceDays - 1 && IsTaskFinishTimePast(taskId) == false)
                            {

                            }
                            else
                            {
                                FinishTask(taskId, 0, lastStatusDate.AddDays(j + 1));
                            }

                        }
                    }
                }
                else
                {
                    DateTime StartDate = DateTime.Parse(profileTasks[i]["StartDate"].ToString());
                    DateTime deadLine = DateTime.Parse(profileTasks[i]["DeadLine"].ToString());
                    TimeSpan difference;

                    if (DateTime.Now.Subtract(deadLine).Days < 0)
                    {
                        difference = DateTime.Now.Subtract(StartDate);
                    }
                    else
                    {
                        difference = deadLine.Subtract(StartDate);
                    }
                    int differenceDays = Convert.ToInt32(difference.Days);
                    if (differenceDays == 1)
                    {
                        if (IsTaskFinishTimePast(taskId))
                        {
                            FinishTask(taskId, 0, DateTime.Now);
                        }
                    }
                    else if (differenceDays > 1)
                    {
                        for (int j = 0; j < differenceDays; j++)
                        {
                            if (j == differenceDays - 1)
                            {
                                if (IsTaskFinishTimePast(taskId))
                                {
                                    FinishTask(taskId, 0, StartDate.AddDays(j + 1));
                                }

                            }
                            else
                            {
                                FinishTask(taskId, 0, StartDate.AddDays(j + 1));
                            }
                        }
                    }
                }


            }

        }
        private void LoadTasks(DataTable filteredTable)
        {
            CleanProfilePage();

            YLocationPanel = 170;
            DataTable Tasktable = filteredTable;

            int taskCounts = Tasktable.Rows.Count;
            panelGroups = new Panel[taskCounts];

            for (int i = 0; i < taskCounts; i++)
            {
                int profileNumber = Convert.ToInt32(Tasktable.Rows[i]["ProfileId"]);

                if (profileNumber == ProfileId)
                {
                    int id = Convert.ToInt32(Tasktable.Rows[i][0]);

                    if (IsTaskDeadLinePast(id) == false)
                    {
                        panelGroups[i] = new Panel
                        {
                            Name = Tasktable.Rows[i][0].ToString(),
                            Size = new Size(710, 140),
                            Location = new Point(40, YLocationPanel),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        CheckBox statusChbox = new CheckBox
                        {
                            Name = i.ToString(), // using this to mark the task as finish task
                            Size = new Size(32, 32),
                            Location = new Point(670, 55),
                        };

                        statusChbox.Click += delegate (object sender, EventArgs e)
                        {
                            CheckBox checkBox = (CheckBox)sender;
                            int panelIndex = Convert.ToInt32(checkBox.Name);
                            bool r = FinishTask(id, 1, DateTime.Now);
                            if (r)
                                panelGroups[panelIndex].Enabled = false;
                            else
                                MessageBox.Show("somthing went wrong");
                        };

                        Label taskNameLbl = new Label
                        {
                            Text = Tasktable.Select($"Id = {id}")[0]["TaskName"].ToString(),
                            AutoSize = true,
                            Location = new Point(500, 10),
                            RightToLeft = RightToLeft.Yes,
                            Font = new Font("Segoe UI", 16),

                        };

                        Label categoryLbl = new Label
                        {
                            Text = "Category: " + categoryTable.Select($"Id = {Tasktable.Select($"Id = {id}")[0]["Category"]}")[0]["CategoryName"].ToString(),
                            AutoSize = true,
                            Location = new Point(500, 50),
                            RightToLeft = RightToLeft.Yes,
                            Font = new Font("Segoe UI", 12),

                        };

                        Label periodityLbl = new Label
                        {
                            Text = "Periodity: " + perioTable.Select($"Id = {Tasktable.Select($"Id = {id}")[0]["Periodity"]}")[0]["PeriodityName"],
                            AutoSize = true,
                            Location = new Point(500, 75),
                            RightToLeft = RightToLeft.Yes,
                            Font = new Font("Segoe UI", 12),

                        };

                        Label deadLineLbl = new Label
                        {

                            Text = "Deadline : " + CalculateDeadLine(id),
                            AutoSize = true,
                            Location = new Point(500, 100),
                            RightToLeft = RightToLeft.Yes,
                            Font = new Font("Segoe UI", 10),
                        };

                        Label descLbl = new Label
                        {
                            Text = "Description :",
                            AutoSize = true,
                            Location = new Point(182, 25),
                            RightToLeft = RightToLeft.No,
                            Font = new Font("Segoe UI", 9),

                        };

                        TextBox desc = new TextBox
                        {
                            Text = Tasktable.Select($"Id = {id}")[0]["Description"].ToString(),
                            Multiline = true,
                            Size = new Size(300, 80),
                            Location = new Point(185, 45),
                            ReadOnly = true,
                            Font = new Font("Segoe UI", 9)
                        };

                        bool IsUntilTime = Tasktable.Select($"Id = {id}")[0]["StartTime"] == DBNull.Value ? true : false;

                        if (IsUntilTime)
                        {
                            TimeSpan untilTime = (TimeSpan)Tasktable.Select($"Id = {id}")[0]["UntilTime"];

                            Label untilTimeLbl = new Label
                            {
                                Text = untilTime.ToString("hh':'mm"),
                                AutoSize = true,
                                Location = new Point(65, 45),
                                RightToLeft = RightToLeft.Yes,
                                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                            };

                            panelGroups[i].Controls.Add(untilTimeLbl);
                        }
                        else
                        {
                            TimeSpan starTime = (TimeSpan)Tasktable.Select($"Id = {id}")[0]["StartTime"];

                            Label firstTimeLbl = new Label
                            {
                                Text = starTime.ToString("hh':'mm") + "   \u2009to",
                                AutoSize = true,
                                Location = new Point(25, 45),
                                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                            };

                            TimeSpan untilTime = (TimeSpan)Tasktable.Select($"Id = {id}")[0]["UntilTime"];

                            Label secondTimeLbl = new Label
                            {
                                Text = untilTime.ToString("hh':'mm"),
                                AutoSize = true,
                                Location = new Point(105, 45),
                                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                            };
                            panelGroups[i].Controls.Add(firstTimeLbl);
                            panelGroups[i].Controls.Add(secondTimeLbl);

                        }

                        Button deleteBtn = new Button
                        {
                            Name = id.ToString(),
                            Text = "Delete",
                            Size = new Size(70, 25),
                            Location = new Point(15, 100),
                            BackColor = Color.Crimson,
                            FlatStyle = FlatStyle.Flat,
                            Font = new Font("Segoe UI", 9)
                        };

                        deleteBtn.Click += delegate (object sender, EventArgs arg)
                        {
                            Button btn = (Button)sender;
                            int taskId = Convert.ToInt32(btn.Name);
                            DeleteTask(taskId);
                            MessageBox.Show("Task Deleted Successsfully");
                            LoadTasks(CombinateTables(SortTable(sort), DisplayTable(display)));
                            this.VerticalScroll.Value = 0;
                        };

                        Button editBtn = new Button
                        {
                            Text = "Edit",
                            Name = id.ToString(),
                            Size = new Size(70, 25),
                            Location = new Point(100, 100),
                            BackColor = Color.SteelBlue,
                            FlatStyle = FlatStyle.Flat,
                            Font = new Font("Segoe UI", 9)
                        };

                        editBtn.Click += delegate (object sender, EventArgs arg)
                        {
                            Button btn = (Button)sender;
                            int taskId = Convert.ToInt32(btn.Name);
                            TasksForm profile = new TasksForm(profileNumber, taskId, TasksForm.TaskMode.edit);
                            profile.ShowDialog();
                            LoadTasks(CombinateTables(SortTable(sort), DisplayTable(display)));
                        };

                        panelGroups[i].Controls.Add(taskNameLbl);
                        panelGroups[i].Controls.Add(periodityLbl);
                        panelGroups[i].Controls.Add(categoryLbl);
                        panelGroups[i].Controls.Add(deadLineLbl);
                        panelGroups[i].Controls.Add(desc);
                        panelGroups[i].Controls.Add(descLbl);
                        panelGroups[i].Controls.Add(statusChbox);
                        panelGroups[i].Controls.Add(editBtn);
                        panelGroups[i].Controls.Add(deleteBtn);

                        YLocationPanel += 150;

                        if (IsTaskDoneable(id) == false)
                        {
                            panelGroups[i].Enabled = false;
                        }

                        this.Controls.Add(panelGroups[i]);
                    }

                }
            }


        }

        //Events
        private void addTaskBtn_Click(object sender, EventArgs e)
        {
            TasksForm taskPage = new TasksForm(ProfileId);
            taskPage.Show();
        }
        private async void ProfileForm_Load(object sender, EventArgs e)
        {
            await FinishPastTasks();
            timeLbl.Text = DateTime.Now.ToString("HH:mm");
            dateLbl.Text = DateTime.Now.ToString("yyyy:MM:dd | dddd");

            profileNameLbl.Text = GetProfileRow(ProfileId)["ProfileName"].ToString();
            LoadTasks(CombinateTables(SortTable(sort), DisplayTable(display)));

        }
        private void displayCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tasktable.Rows.Count != 0)
            {
                foreach (Display item in Enum.GetValues(typeof(Display)))
                {
                    int index = Array.IndexOf(Enum.GetValues(typeof(Display)), item);

                    if (index == displayCbox.SelectedIndex)
                    {
                        display = item;
                    }
                }

                LoadTasks(CombinateTables(SortTable(sort), DisplayTable(display)));
            }
            else
            {
                MessageBox.Show("No task to display");
            }

        }
        private void sortCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tasktable.Rows.Count != 0)
            {

                foreach (Sort item in Enum.GetValues(typeof(Sort)))
                {
                    int index = Array.IndexOf(Enum.GetValues(typeof(Sort)), item);

                    if (index == sortCBox.SelectedIndex)
                    {
                        sort = item;

                    }
                }

                LoadTasks(CombinateTables(SortTable(sort), DisplayTable(display)));
            }
            else
            {
                {
                    MessageBox.Show("no task to sort.");
                }
            }

        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            ChartForm form = new ChartForm(ProfileId);
            form.ShowDialog();


        }



    }
}
