
namespace ToDoApp
{
    partial class CategoryNameForm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addProfileBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryNameTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Crimson;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(81, 184);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(154, 39);
            this.cancelBtn.TabIndex = 33;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // addProfileBtn
            // 
            this.addProfileBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.addProfileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProfileBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProfileBtn.Location = new System.Drawing.Point(263, 184);
            this.addProfileBtn.Name = "addProfileBtn";
            this.addProfileBtn.Size = new System.Drawing.Size(154, 39);
            this.addProfileBtn.TabIndex = 32;
            this.addProfileBtn.Text = "Add profile";
            this.addProfileBtn.UseVisualStyleBackColor = false;
            this.addProfileBtn.Click += new System.EventHandler(this.addProfileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 32);
            this.label2.TabIndex = 31;
            this.label2.Text = "Create a Category";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoryNameTxtBox
            // 
            this.categoryNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoryNameTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryNameTxtBox.Location = new System.Drawing.Point(109, 94);
            this.categoryNameTxtBox.MaxLength = 20;
            this.categoryNameTxtBox.Name = "categoryNameTxtBox";
            this.categoryNameTxtBox.Size = new System.Drawing.Size(284, 31);
            this.categoryNameTxtBox.TabIndex = 30;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 287);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addProfileBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryNameTxtBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addProfileBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox categoryNameTxtBox;
    }
}