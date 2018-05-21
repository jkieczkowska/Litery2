namespace Litery
{
    partial class Statistic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLanguages = new System.Windows.Forms.ComboBox();
            this.listViewLetters = new System.Windows.Forms.ListView();
            this.textBoxNrLetters = new System.Windows.Forms.TextBox();
            this.chartLetters = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Language";
            // 
            // comboBoxLanguages
            // 
            this.comboBoxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguages.FormattingEnabled = true;
            this.comboBoxLanguages.Location = new System.Drawing.Point(68, 10);
            this.comboBoxLanguages.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.Size = new System.Drawing.Size(129, 21);
            this.comboBoxLanguages.TabIndex = 4;
            this.comboBoxLanguages.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguages_SelectedIndexChanged);
            // 
            // listViewLetters
            // 
            this.listViewLetters.Location = new System.Drawing.Point(12, 41);
            this.listViewLetters.Margin = new System.Windows.Forms.Padding(2);
            this.listViewLetters.Name = "listViewLetters";
            this.listViewLetters.Size = new System.Drawing.Size(168, 249);
            this.listViewLetters.TabIndex = 6;
            this.listViewLetters.UseCompatibleStateImageBehavior = false;
            this.listViewLetters.SelectedIndexChanged += new System.EventHandler(this.listViewLetters_SelectedIndexChanged);
            // 
            // textBoxNrLetters
            // 
            this.textBoxNrLetters.Location = new System.Drawing.Point(337, 11);
            this.textBoxNrLetters.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNrLetters.Name = "textBoxNrLetters";
            this.textBoxNrLetters.ReadOnly = true;
            this.textBoxNrLetters.Size = new System.Drawing.Size(76, 20);
            this.textBoxNrLetters.TabIndex = 7;
            // 
            // chartLetters
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLetters.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLetters.Legends.Add(legend1);
            this.chartLetters.Location = new System.Drawing.Point(202, 41);
            this.chartLetters.Margin = new System.Windows.Forms.Padding(2);
            this.chartLetters.Name = "chartLetters";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "f(x)";
            this.chartLetters.Series.Add(series1);
            this.chartLetters.Size = new System.Drawing.Size(1119, 334);
            this.chartLetters.TabIndex = 8;
            this.chartLetters.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Letters";
            this.chartLetters.Titles.Add(title1);
            this.chartLetters.Click += new System.EventHandler(this.chartLetters_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nr letters";
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 386);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartLetters);
            this.Controls.Add(this.textBoxNrLetters);
            this.Controls.Add(this.listViewLetters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLanguages);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Statistic";
            this.Text = "Statistic";
            ((System.ComponentModel.ISupportInitialize)(this.chartLetters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLanguages;
        private System.Windows.Forms.ListView listViewLetters;
        private System.Windows.Forms.TextBox textBoxNrLetters;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLetters;
        private System.Windows.Forms.Label label2;
    }
}