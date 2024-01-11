
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ToDoApp
{
    public partial class ChartForm : Form
    {
        public ChartForm(int profileId)
        {
            InitializeComponent();

            ProfileNumber = profileId;
        }


        public int ProfileNumber { get; set; }
        public DataTable TaskTable { get; set; } = new Tables.Tasks().GetTable();
        public DataTable TaskStatusTable { get; set; } = new Tables.TaskStatus().GetTable();

        public Series series1 = null;

        private void GetTaskMonths()
        {
            displayCbox.Items.Add("All");
            (_, DataRow[] statusTable) = GetProfileTasksAndStatus();

            HashSet<int> distinctMonth = new HashSet<int>();

            foreach (DataRow row in statusTable)
            {
                int month = DateTime.Parse(row["date"].ToString()).Month;

                if (!distinctMonth.Contains(month))
                {
                    distinctMonth.Add(month);
                    displayCbox.Items.Add(month.ToString());
                }
            }

        }
        private (DataRow[], DataRow[]) GetProfileTasksAndStatus()
        {
            DataRow[] tasks = TaskTable.Select($"ProfileId = {ProfileNumber}");
            DataRow[] statusRows = new DataRow[0];

            int counter = 1;
            for (int i = 0; i < TaskStatusTable.Rows.Count; i++)
            {
                int taskStatusId = Convert.ToInt32(TaskStatusTable.Rows[i][0]);
                for (int j = 0; j < tasks.Length; j++)
                {
                    int taskId = Convert.ToInt32(tasks[j][0]);
                    if (taskStatusId == taskId)
                    {
                        Array.Resize(ref statusRows, counter);
                        statusRows[counter - 1] = TaskStatusTable.Rows[i];
                        counter++;
                    }
                }

            }

            return (tasks, statusRows);
        }
        private (float, float) CalculatePercent(int month)
        {

            float donePerc = 0f;
            float UnDonePerc = 0f;

            float done = 0;
            float unDone = 0;

            DataRow[] tasks;
            DataRow[] statusRows;

            (tasks, statusRows) = GetProfileTasksAndStatus();

            if (month == 0)
            {
                for (int i = 0; i < statusRows.Length; i++)
                {
                    int taskMonth = DateTime.Parse(statusRows[i]["date"].ToString()).Month;

                    int status = Convert.ToInt32(statusRows[i]["task_status"]);
                    if (status == 0)
                    {
                        unDone += 1;
                    }
                    else
                    {
                        done += 1;
                    }

                }
            }
            else
            {
                for (int i = 0; i < statusRows.Length; i++)
                {
                    int taskMonth = DateTime.Parse(statusRows[i]["date"].ToString()).Month;
                    if (month == taskMonth)
                    {
                        int status = Convert.ToInt32(statusRows[i]["task_status"]);
                        if (status == 0)
                        {
                            unDone += 1;
                        }
                        else
                        {
                            done += 1;
                        }
                    }

                }
            }

           
            float all = unDone + done;
            donePerc = done * 100 / all;
            UnDonePerc = unDone * 100 / all;


            return (donePerc, UnDonePerc);
        }
        private void CreateChart(int month)
        {
            float donePrec, UndonePerc;
            (donePrec, UndonePerc) = CalculatePercent(month);

            if (float.IsNaN(donePrec)|| float.IsNaN(UndonePerc))
            {
                chart1.Titles[0].Text = "no task to report yet.";
            }
            else
            {
                chart1.Titles[0].Text = "Your Task Report";
                double[] values = new double[2] { donePrec, UndonePerc };

                Font font = new Font("segoe ui", 9f);
                List<DataPoint> data = new List<DataPoint>
                {
                   new DataPoint(0,values[0]){Label = $"{Math.Round(donePrec,2)} %",LegendText="Done",Font = font},
                   new DataPoint(0,values[1]){Label = $"{Math.Round(UndonePerc,2)} %",LegendText="Un Done",Font = font},
                };

                if (series1 == null)
                {

                    GetTaskMonths();
                    series1 = new Series();
                    series1.ChartType = SeriesChartType.Pie;
                    series1.Points.Add(data[0]);
                    series1.Points.Add(data[1]);

                    chart1.Series.Add(series1);
                }
                else
                {
                    series1.Points.Clear();
                    series1.Points.Add(data[0]);
                    series1.Points.Add(data[1]);
                }
            }


        }


        private void ChartForm_Load(object sender, EventArgs e)
        {
            CreateChart(0);
        }
        private void displayCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month;
            if (displayCbox.SelectedIndex == 0)
            {
                month = 0;
            }
            else
            {
                month = Convert.ToInt32(displayCbox.SelectedItem);
            }
           

            CreateChart(month);

        }
    }

}
