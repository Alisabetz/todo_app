
namespace ToDoApp
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.displayCbox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 134);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(903, 395);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Your Profile Chart";
            this.chart1.Titles.Add(title2);
            // 
            // displayCbox
            // 
            this.displayCbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.displayCbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayCbox.FormattingEnabled = true;
            this.displayCbox.ItemHeight = 20;
            this.displayCbox.Location = new System.Drawing.Point(785, 61);
            this.displayCbox.Name = "displayCbox";
            this.displayCbox.Size = new System.Drawing.Size(121, 28);
            this.displayCbox.TabIndex = 3;
            this.displayCbox.Text = "Month";
            this.displayCbox.SelectedIndexChanged += new System.EventHandler(this.displayCbox_SelectedIndexChanged);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 541);
            this.Controls.Add(this.displayCbox);
            this.Controls.Add(this.chart1);
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartForm";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox displayCbox;
    }
}