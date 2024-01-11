using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Models;
using ToDoApp.Tables;

namespace ToDoApp
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
{
            DateTime start1 = DateTime.Now.AddDays(10);
            DateTime start2 = DateTime.Parse(DateTime.Now.ToString("dd/MM/yy"));

            TimeSpan t1 = DateTime.Now.TimeOfDay;
            TimeSpan t2 = TimeSpan.Parse("17:00:00");
            TimeSpan t = start1.Subtract(start1.AddDays(5));
            MessageBox.Show(t.Days.ToString());

        }

        private void deadLineCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(deadLineCombo.SelectedItem.ToString());

        }

        private void untilTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TasksModel model = new TasksModel
            {

            };

        }
    }
}
