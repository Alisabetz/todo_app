
namespace ToDoApp
{
    partial class Test
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
            this.timeToTimeChBox = new System.Windows.Forms.CheckBox();
            this.setDayNumeric = new System.Windows.Forms.NumericUpDown();
            this.deadLineCombo = new System.Windows.Forms.ComboBox();
            this.untilTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.endTimeLbl = new System.Windows.Forms.Label();
            this.startTimeLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.TaskStatusChbox = new System.Windows.Forms.Button();
            this.categoryLbl = new System.Windows.Forms.Label();
            this.periodityLbl = new System.Windows.Forms.Label();
            this.descTextbox = new System.Windows.Forms.TextBox();
            this.TaskNameLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.setDayNumeric)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeToTimeChBox
            // 
            this.timeToTimeChBox.AutoSize = true;
            this.timeToTimeChBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeToTimeChBox.Location = new System.Drawing.Point(370, 136);
            this.timeToTimeChBox.Name = "timeToTimeChBox";
            this.timeToTimeChBox.Size = new System.Drawing.Size(18, 17);
            this.timeToTimeChBox.TabIndex = 30;
            this.timeToTimeChBox.UseVisualStyleBackColor = true;
            // 
            // setDayNumeric
            // 
            this.setDayNumeric.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.setDayNumeric.Location = new System.Drawing.Point(227, 117);
            this.setDayNumeric.Name = "setDayNumeric";
            this.setDayNumeric.Size = new System.Drawing.Size(65, 27);
            this.setDayNumeric.TabIndex = 32;
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
            this.deadLineCombo.Location = new System.Drawing.Point(70, 116);
            this.deadLineCombo.Name = "deadLineCombo";
            this.deadLineCombo.Size = new System.Drawing.Size(151, 28);
            this.deadLineCombo.TabIndex = 33;
            this.deadLineCombo.Text = "Choose DeadLine";
            this.deadLineCombo.SelectedIndexChanged += new System.EventHandler(this.deadLineCombo_SelectedIndexChanged);
            // 
            // untilTimePicker
            // 
            this.untilTimePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.untilTimePicker.CustomFormat = "HH:mm";
            this.untilTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.untilTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.untilTimePicker.Location = new System.Drawing.Point(475, 98);
            this.untilTimePicker.Name = "untilTimePicker";
            this.untilTimePicker.ShowUpDown = true;
            this.untilTimePicker.Size = new System.Drawing.Size(76, 27);
            this.untilTimePicker.TabIndex = 34;
            this.untilTimePicker.ValueChanged += new System.EventHandler(this.untilTimePicker_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.endTimeLbl);
            this.panel2.Controls.Add(this.startTimeLbl);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.editBtn);
            this.panel2.Controls.Add(this.deleteBtn);
            this.panel2.Controls.Add(this.TaskStatusChbox);
            this.panel2.Controls.Add(this.categoryLbl);
            this.panel2.Controls.Add(this.periodityLbl);
            this.panel2.Controls.Add(this.descTextbox);
            this.panel2.Controls.Add(this.TaskNameLbl);
            this.panel2.Location = new System.Drawing.Point(86, 375);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 172);
            this.panel2.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(686, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "periodity : 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endTimeLbl
            // 
            this.endTimeLbl.AutoSize = true;
            this.endTimeLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimeLbl.Location = new System.Drawing.Point(155, 34);
            this.endTimeLbl.Name = "endTimeLbl";
            this.endTimeLbl.Size = new System.Drawing.Size(55, 25);
            this.endTimeLbl.TabIndex = 19;
            this.endTimeLbl.Text = "12:31";
            this.endTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startTimeLbl
            // 
            this.startTimeLbl.AutoSize = true;
            this.startTimeLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimeLbl.Location = new System.Drawing.Point(47, 34);
            this.startTimeLbl.Name = "startTimeLbl";
            this.startTimeLbl.Size = new System.Drawing.Size(58, 25);
            this.startTimeLbl.TabIndex = 18;
            this.startTimeLbl.Text = "10:00";
            this.startTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripton :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.Crimson;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(139, 92);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(99, 32);
            this.editBtn.TabIndex = 16;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = false;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(21, 92);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(99, 32);
            this.deleteBtn.TabIndex = 8;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            // 
            // TaskStatusChbox
            // 
            this.TaskStatusChbox.Location = new System.Drawing.Point(884, 71);
            this.TaskStatusChbox.Name = "TaskStatusChbox";
            this.TaskStatusChbox.Size = new System.Drawing.Size(32, 32);
            this.TaskStatusChbox.TabIndex = 11;
            this.TaskStatusChbox.UseVisualStyleBackColor = true;
            // 
            // categoryLbl
            // 
            this.categoryLbl.AutoSize = true;
            this.categoryLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLbl.Location = new System.Drawing.Point(686, 71);
            this.categoryLbl.Name = "categoryLbl";
            this.categoryLbl.Size = new System.Drawing.Size(148, 25);
            this.categoryLbl.TabIndex = 15;
            this.categoryLbl.Text = "category : sport";
            this.categoryLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // periodityLbl
            // 
            this.periodityLbl.AutoSize = true;
            this.periodityLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodityLbl.Location = new System.Drawing.Point(686, 102);
            this.periodityLbl.Name = "periodityLbl";
            this.periodityLbl.Size = new System.Drawing.Size(112, 25);
            this.periodityLbl.TabIndex = 14;
            this.periodityLbl.Text = "periodity : 1";
            this.periodityLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descTextbox
            // 
            this.descTextbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descTextbox.Location = new System.Drawing.Point(267, 34);
            this.descTextbox.Multiline = true;
            this.descTextbox.Name = "descTextbox";
            this.descTextbox.Size = new System.Drawing.Size(393, 93);
            this.descTextbox.TabIndex = 12;
            // 
            // TaskNameLbl
            // 
            this.TaskNameLbl.AutoSize = true;
            this.TaskNameLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskNameLbl.Location = new System.Drawing.Point(685, 12);
            this.TaskNameLbl.Name = "TaskNameLbl";
            this.TaskNameLbl.Size = new System.Drawing.Size(175, 32);
            this.TaskNameLbl.TabIndex = 7;
            this.TaskNameLbl.Text = "cleaning home";
            this.TaskNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 584);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.untilTimePicker);
            this.Controls.Add(this.deadLineCombo);
            this.Controls.Add(this.setDayNumeric);
            this.Controls.Add(this.timeToTimeChBox);
            this.Name = "Test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setDayNumeric)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox timeToTimeChBox;
        private System.Windows.Forms.NumericUpDown setDayNumeric;
        private System.Windows.Forms.ComboBox deadLineCombo;
        private System.Windows.Forms.DateTimePicker untilTimePicker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label endTimeLbl;
        private System.Windows.Forms.Label startTimeLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button TaskStatusChbox;
        private System.Windows.Forms.Label categoryLbl;
        private System.Windows.Forms.Label periodityLbl;
        private System.Windows.Forms.TextBox descTextbox;
        private System.Windows.Forms.Label TaskNameLbl;
        private System.Windows.Forms.Label label2;
    }
}