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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLanguages = new System.Windows.Forms.ComboBox();
            this.listViewLetters = new System.Windows.Forms.ListView();
            this.textBoxNrLetters = new System.Windows.Forms.TextBox();
            this.chartLetters = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Language";
            // 
            // comboBoxLanguages
            // 
            this.comboBoxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguages.FormattingEnabled = true;
            this.comboBoxLanguages.Location = new System.Drawing.Point(91, 12);
            this.comboBoxLanguages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.Size = new System.Drawing.Size(171, 24);
            this.comboBoxLanguages.TabIndex = 4;
            this.comboBoxLanguages.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguages_SelectedIndexChanged);
            // 
            // listViewLetters
            // 
            this.listViewLetters.Location = new System.Drawing.Point(16, 50);
            this.listViewLetters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewLetters.Name = "listViewLetters";
            this.listViewLetters.Size = new System.Drawing.Size(223, 411);
            this.listViewLetters.TabIndex = 6;
            this.listViewLetters.UseCompatibleStateImageBehavior = false;
            // 
            // textBoxNrLetters
            // 
            this.textBoxNrLetters.Location = new System.Drawing.Point(431, 14);
            this.textBoxNrLetters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNrLetters.Name = "textBoxNrLetters";
            this.textBoxNrLetters.ReadOnly = true;
            this.textBoxNrLetters.Size = new System.Drawing.Size(100, 22);
            this.textBoxNrLetters.TabIndex = 7;
            // 
            // chartLetters
            // 
            chartArea3.Name = "ChartArea1";
            this.chartLetters.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartLetters.Legends.Add(legend3);
            this.chartLetters.Location = new System.Drawing.Point(269, 50);
            this.chartLetters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLetters.Name = "chartLetters";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "f(x)";
            this.chartLetters.Series.Add(series3);
            this.chartLetters.Size = new System.Drawing.Size(1492, 411);
            this.chartLetters.TabIndex = 8;
            this.chartLetters.Text = "chart1";
            title3.Name = "Title1";
            title3.Text = "Letters";
            this.chartLetters.Titles.Add(title3);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nr letters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mode";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Location = new System.Drawing.Point(669, 12);
            this.comboBoxMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(171, 24);
            this.comboBoxMode.TabIndex = 10;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1776, 475);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartLetters);
            this.Controls.Add(this.textBoxNrLetters);
            this.Controls.Add(this.listViewLetters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLanguages);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMode;
    }
}