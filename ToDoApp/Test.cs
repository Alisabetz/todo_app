using DocumentFormat.OpenXml.Office2010.Excel;
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

            DataTable table = new Category().GetTable();
     

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
