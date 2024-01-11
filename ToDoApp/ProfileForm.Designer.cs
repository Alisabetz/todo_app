
namespace ToDoApp
{
    partial class ProfileForm
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
            this.finishedLbl = new System.Windows.Forms.Label();
            this.tasksLbl = new System.Windows.Forms.Label();
            this.dateLbl = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.profileNameLbl = new System.Windows.Forms.Label();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.displayCbox = new System.Windows.Forms.ComboBox();
            this.sortCBox = new System.Windows.Forms.ComboBox();
            this.reportsBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.finishedLbl);
            this.panel1.Controls.Add(this.tasksLbl);
            this.panel1.Controls.Add(this.dateLbl);
            this.panel1.Controls.Add(this.timeLbl);
            this.panel1.Controls.Add(this.profileNameLbl);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 127);
            this.panel1.TabIndex = 0;
            // 
            // finishedLbl
            // 
            this.finishedLbl.AutoSize = true;
            this.finishedLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishedLbl.Location = new System.Drawing.Point(858, 41);
            this.finishedLbl.Name = "finishedLbl";
            this.finishedLbl.Size = new System.Drawing.Size(143, 32);
            this.finishedLbl.TabIndex = 6;
            this.finishedLbl.Text = "finished : 10";
            this.finishedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tasksLbl
            // 
            this.tasksLbl.AutoSize = true;
            this.tasksLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksLbl.Location = new System.Drawing.Point(858, 82);
            this.tasksLbl.Name = "tasksLbl";
            this.tasksLbl.Size = new System.Drawing.Size(113, 32);
            this.tasksLbl.TabIndex = 5;
            this.tasksLbl.Text = "tasks : 12";
            this.tasksLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.Location = new System.Drawing.Point(3, 82);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(131, 32);
            this.dateLbl.TabIndex = 4;
            this.dateLbl.Text = "1402/12/01";
            this.dateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLbl.Location = new System.Drawing.Point(3, 41);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(70, 32);
            this.timeLbl.TabIndex = 3;
            this.timeLbl.Text = "12:35";
            this.timeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // profileNameLbl
            // 
            this.profileNameLbl.AutoSize = true;
            this.profileNameLbl.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileNameLbl.Location = new System.Drawing.Point(468, 5);
            this.profileNameLbl.Name = "profileNameLbl";
            this.profileNameLbl.Size = new System.Drawing.Size(104, 38);
            this.profileNameLbl.TabIndex = 2;
            this.profileNameLbl.Text = "Profile";
            this.profileNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.addTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTaskBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTaskBtn.Location = new System.Drawing.Point(12, 152);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(154, 46);
            this.addTaskBtn.TabIndex = 1;
            this.addTaskBtn.Text = "Add Task +";
            this.addTaskBtn.UseVisualStyleBackColor = false;
            this.addTaskBtn.Click += new System.EventHandler(this.addTaskBtn_Click);
            // 
            // displayCbox
            // 
            this.displayCbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayCbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayCbox.FormattingEnabled = true;
            this.displayCbox.ItemHeight = 20;
            this.displayCbox.Items.AddRange(new object[] {
            "Done",
            "unDone",
            "All Tasks"});
            this.displayCbox.Location = new System.Drawing.Point(802, 170);
            this.displayCbox.Name = "displayCbox";
            this.displayCbox.Size = new System.Drawing.Size(121, 28);
            this.displayCbox.TabIndex = 2;
            this.displayCbox.Text = "Display by";
            this.displayCbox.SelectedIndexChanged += new System.EventHandler(this.displayCbox_SelectedIndexChanged);
            // 
            // sortCBox
            // 
            this.sortCBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortCBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortCBox.FormattingEnabled = true;
            this.sortCBox.ItemHeight = 20;
            this.sortCBox.Items.AddRange(new object[] {
            "Time",
            "Date",
            "Periodity"});
            this.sortCBox.Location = new System.Drawing.Point(929, 170);
            this.sortCBox.Name = "sortCBox";
            this.sortCBox.Size = new System.Drawing.Size(121, 28);
            this.sortCBox.TabIndex = 3;
            this.sortCBox.Text = "Sort by";
            this.sortCBox.SelectedIndexChanged += new System.EventHandler(this.sortCBox_SelectedIndexChanged);
            // 
            // reportsBtn
            // 
            this.reportsBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.reportsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsBtn.Location = new System.Drawing.Point(212, 152);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(154, 46);
            this.reportsBtn.TabIndex = 4;
            this.reportsBtn.Text = "Reports";
            this.reportsBtn.UseVisualStyleBackColor = false;
            this.reportsBtn.Click += new System.EventHandler(this.reportsBtn_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1083, 582);
            this.Controls.Add(this.reportsBtn);
            this.Controls.Add(this.sortCBox);
            this.Controls.Add(this.displayCbox);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "profile";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label finishedLbl;
        private System.Windows.Forms.Label tasksLbl;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Label profileNameLbl;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.ComboBox displayCbox;
        private System.Windows.Forms.ComboBox sortCBox;
        private System.Windows.Forms.Button reportsBtn;
    }
}