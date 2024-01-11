
namespace ToDoApp
{
    partial class ProfileNameForm
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
            this.profileNameTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addProfileBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // profileNameTxtBox
            // 
            this.profileNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profileNameTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileNameTxtBox.Location = new System.Drawing.Point(115, 93);
            this.profileNameTxtBox.MaxLength = 20;
            this.profileNameTxtBox.Name = "profileNameTxtBox";
            this.profileNameTxtBox.Size = new System.Drawing.Size(284, 31);
            this.profileNameTxtBox.TabIndex = 7;
            this.profileNameTxtBox.TextChanged += new System.EventHandler(this.profileNameTxtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose a Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // addProfileBtn
            // 
            this.addProfileBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.addProfileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProfileBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProfileBtn.Location = new System.Drawing.Point(269, 183);
            this.addProfileBtn.Name = "addProfileBtn";
            this.addProfileBtn.Size = new System.Drawing.Size(154, 39);
            this.addProfileBtn.TabIndex = 28;
            this.addProfileBtn.Text = "Add profile";
            this.addProfileBtn.UseVisualStyleBackColor = false;
            this.addProfileBtn.Click += new System.EventHandler(this.addProfileBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Crimson;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(87, 183);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(154, 39);
            this.cancelBtn.TabIndex = 29;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ProfileNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 254);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addProfileBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.profileNameTxtBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileNameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "profileName";
            this.Load += new System.EventHandler(this.ProfileNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox profileNameTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addProfileBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}