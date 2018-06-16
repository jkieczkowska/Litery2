namespace Litery
{
    partial class FindLanguage
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartLetters = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLetters
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLetters.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLetters.Legends.Add(legend1);
            this.chartLetters.Location = new System.Drawing.Point(9, 62);
            this.chartLetters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartLetters.Name = "chartLetters";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Searched";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "EN";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "DE";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "PL";
            this.chartLetters.Series.Add(series1);
            this.chartLetters.Series.Add(series2);
            this.chartLetters.Series.Add(series3);
            this.chartLetters.Series.Add(series4);
            this.chartLetters.Size = new System.Drawing.Size(893, 263);
            this.chartLetters.TabIndex = 9;
            this.chartLetters.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Letters";
            this.chartLetters.Titles.Add(title1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mode";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Location = new System.Drawing.Point(190, 11);
            this.comboBoxMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(129, 21);
            this.comboBoxMode.TabIndex = 12;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 22);
            this.button1.TabIndex = 14;
            this.button1.Text = "Load text";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(344, 11);
            this.textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(532, 39);
            this.textBox.TabIndex = 16;
            // 
            // FindLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 353);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.chartLetters);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FindLanguage";
            this.Text = "FindLanguage";
            ((System.ComponentModel.ISupportInitialize)(this.chartLetters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLetters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
    }
}