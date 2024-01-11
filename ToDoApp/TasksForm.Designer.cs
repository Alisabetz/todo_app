
namespace ToDoApp
{
    partial class TasksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.perioChbox = new System.Windows.Forms.ComboBox();
            this.addCategoryBtn = new System.Windows.Forms.Button();
            this.deadLineCombo = new System.Windows.Forms.ComboBox();
            this.untilTimeChBox = new System.Windows.Forms.CheckBox();
            this.timeToTimeChBox = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.desctiptionTxtBox = new System.Windows.Forms.TextBox();
            this.setDayNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.untilTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.timePicker2 = new System.Windows.Forms.DateTimePicker();
            this.timePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryCbox = new System.Windows.Forms.ComboBox();
            this.taskNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setDayNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.perioChbox);
            this.panel1.Controls.Add(this.addCategoryBtn);
            this.panel1.Controls.Add(this.deadLineCombo);
            this.panel1.Controls.Add(this.untilTimeChBox);
            this.panel1.Controls.Add(this.timeToTimeChBox);
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.addTaskBtn);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.desctiptionTxtBox);
            this.panel1.Controls.Add(this.setDayNumeric);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.untilTimePicker);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.timePicker2);
            this.panel1.Controls.Add(this.timePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.categoryCbox);
            this.panel1.Controls.Add(this.taskNameTxtBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 507);
            this.panel1.TabIndex = 1;
            // 
            // perioChbox
            // 
            this.perioChbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.perioChbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perioChbox.FormattingEnabled = true;
            this.perioChbox.ItemHeight = 20;
            this.perioChbox.Items.AddRange(new object[] {
            "Rank 1",
            "Rank 2",
            "Rank 3"});
            this.perioChbox.Location = new System.Drawing.Point(50, 133);
            this.perioChbox.Name = "perioChbox";
            this.perioChbox.Size = new System.Drawing.Size(121, 28);
            this.perioChbox.TabIndex = 33;
            this.perioChbox.Text = "Periodity";
            // 
            // addCategoryBtn
            // 
            this.addCategoryBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.addCategoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCategoryBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCategoryBtn.Location = new System.Drawing.Point(177, 88);
            this.addCategoryBtn.Name = "addCategoryBtn";
            this.addCategoryBtn.Size = new System.Drawing.Size(62, 32);
            this.addCategoryBtn.TabIndex = 32;
            this.addCategoryBtn.Text = "add +";
            this.addCategoryBtn.UseVisualStyleBackColor = false;
            this.addCategoryBtn.Click += new System.EventHandler(this.addCategoryBtn_Click);
            // 
            // deadLineCombo
            // 
            this.deadLineCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deadLineCombo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deadLineCombo.FormattingEnabled = true;
            this.deadLineCombo.ItemHeight = 20;
            this.deadLineCombo.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month"});
            this.deadLineCombo.Location = new System.Drawing.Point(197, 254);
            this.deadLineCombo.Name = "deadLineCombo";
            this.deadLineCombo.Size = new System.Drawing.Size(151, 28);
            this.deadLineCombo.TabIndex = 31;
            this.deadLineCombo.Text = "Choose DeadLine";
            // 
            // untilTimeChBox
            // 
            this.untilTimeChBox.AutoSize = true;
            this.untilTimeChBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.untilTimeChBox.Location = new System.Drawing.Point(660, 177);
            this.untilTimeChBox.Name = "untilTimeChBox";
            this.untilTimeChBox.Size = new System.Drawing.Size(18, 17);
            this.untilTimeChBox.TabIndex = 30;
            this.untilTimeChBox.UseVisualStyleBackColor = true;
            this.untilTimeChBox.CheckedChanged += new System.EventHandler(this.untilTimeChBox_CheckedChanged);
            // 
            // timeToTimeChBox
            // 
            this.timeToTimeChBox.AutoSize = true;
            this.timeToTimeChBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeToTimeChBox.Location = new System.Drawing.Point(660, 104);
            this.timeToTimeChBox.Name = "timeToTimeChBox";
            this.timeToTimeChBox.Size = new System.Drawing.Size(18, 17);
            this.timeToTimeChBox.TabIndex = 29;
            this.timeToTimeChBox.UseVisualStyleBackColor = true;
            this.timeToTimeChBox.CheckedChanged += new System.EventHandler(this.timeToTimeChBox_CheckedChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Crimson;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(240, 453);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(154, 39);
            this.cancelBtn.TabIndex = 28;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.addTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTaskBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTaskBtn.Location = new System.Drawing.Point(409, 453);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(154, 39);
            this.addTaskBtn.TabIndex = 27;
            this.addTaskBtn.Text = "Add Task";
            this.addTaskBtn.UseVisualStyleBackColor = false;
            this.addTaskBtn.Click += new System.EventHandler(this.addTaskBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(46, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "Description :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // desctiptionTxtBox
            // 
            this.desctiptionTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.desctiptionTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desctiptionTxtBox.Location = new System.Drawing.Point(50, 328);
            this.desctiptionTxtBox.Multiline = true;
            this.desctiptionTxtBox.Name = "desctiptionTxtBox";
            this.desctiptionTxtBox.Size = new System.Drawing.Size(726, 106);
            this.desctiptionTxtBox.TabIndex = 25;
            // 
            // setDayNumeric
            // 
            this.setDayNumeric.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.setDayNumeric.Location = new System.Drawing.Point(354, 255);
            this.setDayNumeric.Maximum = new decimal(new int[] {
            364,
            0,
            0,
            0});
            this.setDayNumeric.Name = "setDayNumeric";
            this.setDayNumeric.Size = new System.Drawing.Size(65, 27);
            this.setDayNumeric.TabIndex = 22;
            this.setDayNumeric.ValueChanged += new System.EventHandler(this.setDayNumeric_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 28);
            this.label5.TabIndex = 16;
            this.label5.Text = "DeadLine :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // untilTimePicker
            // 
            this.untilTimePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.untilTimePicker.CustomFormat = "HH:mm";
            this.untilTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.untilTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.untilTimePicker.Location = new System.Drawing.Point(472, 174);
            this.untilTimePicker.Name = "untilTimePicker";
            this.untilTimePicker.ShowUpDown = true;
            this.untilTimePicker.Size = new System.Drawing.Size(76, 27);
            this.untilTimePicker.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.label4.Location = new System.Drawing.Point(404, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Until :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(295, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 10);
            this.panel2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.label3.Location = new System.Drawing.Point(493, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "To :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timePicker2
            // 
            this.timePicker2.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.timePicker2.CustomFormat = "HH:mm";
            this.timePicker2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.timePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker2.Location = new System.Drawing.Point(540, 97);
            this.timePicker2.Name = "timePicker2";
            this.timePicker2.ShowUpDown = true;
            this.timePicker2.Size = new System.Drawing.Size(76, 27);
            this.timePicker2.TabIndex = 11;
            // 
            // timePicker1
            // 
            this.timePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker1.CustomFormat = "HH:mm";
            this.timePicker1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timePicker1.Location = new System.Drawing.Point(409, 97);
            this.timePicker1.Name = "timePicker1";
            this.timePicker1.ShowUpDown = true;
            this.timePicker1.Size = new System.Drawing.Size(76, 27);
            this.timePicker1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "Time :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoryCbox
            // 
            this.categoryCbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryCbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryCbox.FormattingEnabled = true;
            this.categoryCbox.ItemHeight = 20;
            this.categoryCbox.Location = new System.Drawing.Point(50, 89);
            this.categoryCbox.Name = "categoryCbox";
            this.categoryCbox.Size = new System.Drawing.Size(121, 28);
            this.categoryCbox.TabIndex = 6;
            this.categoryCbox.Text = "Category";
            // 
            // taskNameTxtBox
            // 
            this.taskNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskNameTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskNameTxtBox.Location = new System.Drawing.Point(197, 43);
            this.taskNameTxtBox.Name = "taskNameTxtBox";
            this.taskNameTxtBox.Size = new System.Drawing.Size(189, 31);
            this.taskNameTxtBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Task Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 532);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "TasksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TasksForm";
            this.Load += new System.EventHandler(this.TasksForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setDayNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox perioChbox;
        private System.Windows.Forms.Button addCategoryBtn;
        private System.Windows.Forms.ComboBox deadLineCombo;
        private System.Windows.Forms.CheckBox untilTimeChBox;
        private System.Windows.Forms.CheckBox timeToTimeChBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox desctiptionTxtBox;
        private System.Windows.Forms.NumericUpDown setDayNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker untilTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timePicker2;
        private System.Windows.Forms.DateTimePicker timePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryCbox;
        private System.Windows.Forms.TextBox taskNameTxtBox;
        private System.Windows.Forms.Label label1;
    }
}