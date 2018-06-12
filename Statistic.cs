using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Litery
{
    public partial class Statistic : Form
    {
        private List<LetterStatistic> StatisticList;

        public void ShowChart()
        {
            chartLetters.Series["f(x)"].SetDefault(true);
            chartLetters.Series["f(x)"].Enabled = true;
            chartLetters.Visible = true;
            
            chartLetters.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartLetters.Series["f(x)"].Points.Clear();
            
            var selectedLanguage = StatisticList.Find(x => x.Language == comboBoxLanguages.SelectedItem.ToString());

            var orderLetters = GetLetters(selectedLanguage);
            string[] letters_labels = new string[orderLetters.Count];
            for (int i = 0; i < orderLetters.Count; i++)
                letters_labels[i] = orderLetters[i].Name.ToString();

            int start_offset = -5;
            int end_offset = 5;
            foreach (var letterLabel in letters_labels)
            {
                CustomLabel letter = new CustomLabel(start_offset, end_offset, letterLabel, 0, LabelMarkStyle.None);
                chartLetters.ChartAreas[0].AxisX.CustomLabels.Add(letter);
                start_offset += 10;
                end_offset += 10;
            }
                                                
            //wyświetlenie wartości
            for (int i = 0; i < orderLetters.Count; i++)
            {
                chartLetters.Series["f(x)"].Points
                    .AddXY(i * 10, orderLetters[i].Nr);
                chartLetters.Series["f(x)"].ChartType = SeriesChartType.FastLine;
            }
            

            
            chartLetters.Show();

            Controls.Add(chartLetters);
            chartLetters.Show();

        }

        public Statistic(List<LetterStatistic> statistic)
        {
            InitializeComponent();

            StatisticList = statistic;

            listViewLetters.View = View.Details;
            listViewLetters.GridLines = true;

            ColumnHeader header1, header2;
            header1 = new ColumnHeader();
            header1.Text = "Name";
            header2 = new ColumnHeader();
            header2.Text = "Nr";
            header1.Width = listViewLetters.Width / 2;
            header2.Width = listViewLetters.Width / 2;

            listViewLetters.Columns.Add(header1);
            listViewLetters.Columns.Add(header2);

            foreach (var lang in statistic)
                comboBoxLanguages.Items.Add(lang.Language);
            comboBoxLanguages.SelectedIndex = 0;

            comboBoxMode.Items.Add("All letters");
            comboBoxMode.Items.Add("First letters");
            comboBoxMode.Items.Add("Last letters");
            comboBoxMode.SelectedIndex = 0;

        }

        private void comboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItems();            
        }

        private void RefreshItems()
        {
            var selectedLanguage = StatisticList.Find(x => x.Language == comboBoxLanguages.SelectedItem.ToString());
            if (selectedLanguage == null)
            {
                textBoxNrLetters.Clear();
                listViewLetters.Clear();
                return;
            }

            textBoxNrLetters.Text = selectedLanguage.NrLetters.ToString();

            listViewLetters.Items.Clear();
            foreach (var letter in GetLetters(selectedLanguage))
                listViewLetters.Items.Add(new ListViewItem(new string[] { letter.Name.ToString(), letter.Nr.ToString() }));
            ShowChart();
        }

        private List<LetterNr> GetLetters(LetterStatistic selectedLanguage)
        {
            if (comboBoxMode.Items.Count > 0)
            {
                var mode = comboBoxMode.SelectedItem.ToString();
                if (mode == "All letters")
                    return selectedLanguage.AllOrderLetters();
                if (mode == "First letters")
                    return selectedLanguage.FirstOrderLetters();
                if (mode == "Last letters")
                    return selectedLanguage.LastOrderLetters();
            }                      
            return new List<LetterNr>();
        }

    }
}
