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
        public Statistic()
        {

        }

        public void ShowChart()
        {
            
            chartLetters.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartLetters.Series["f(x)"].SetDefault(true);
            chartLetters.Series["f(x)"].Enabled = true;
            chartLetters.Visible = true;

            
            var selectedLanguage = StatisticList.Find(x => x.Language == comboBoxLanguages.SelectedItem.ToString());
            /*Wyświetl wszystkie:  string[] letters_labels = new string[StatisticList.Max(x => x.letters.Count)];//tu jest na sztywno 0 czyli zadziała tylko dla polskiego dla innych języków się wywali program trzeba obsłużyć
                //przygotowanie osi x aby były literami z pliku
                foreach (var letterStatistic in statistic)
                {
                    for (int i = 0; i < letterStatistic.letters.Count; i++)
                    {
                        letters_labels[i] = letterStatistic.letters[i].Name.ToString();
                    }
                }*/


            string[] letters_labels = new string[selectedLanguage.letters.Count];//tu jest na sztywno 0 czyli zadziała tylko dla polskiego dla innych języków się wywali program trzeba obsłużyć
            for (int i = 0; i < selectedLanguage.letters.Count; i++)
            {
                letters_labels[i] = selectedLanguage.letters[i].Name.ToString();
            }

            int start_offset = 0;
            int end_offset = 10;
            foreach (var letterLabel in letters_labels)
            {
                CustomLabel letter = new CustomLabel(start_offset, end_offset, letterLabel, 0, LabelMarkStyle.None);
                chartLetters.ChartAreas[0].AxisX.CustomLabels.Add(letter);
                start_offset += 10;
                end_offset += 10;
            }
            
            /*Wyświetl wszystkie //wyświetlenie wartości
            foreach (var letterStatistic in statistic)
            {
                for (int i = 0; i < letterStatistic.letters.Count; i++)
                {
                    chartLetters.Series["f(x)"].Points
                        .AddXY(i*10, letterStatistic.letters[i].Nr);
                }
            }  */
            
            
            //wyświetlenie wartości
            for (int i = 0; i < selectedLanguage.letters.Count; i++)
            {
                chartLetters.Series["f(x)"].Points
                    .AddXY(i*10, selectedLanguage.letters[i].Nr);
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

        
           // ShowChart();

        }

        private void comboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLanguage = StatisticList.Find(x => x.Language == comboBoxLanguages.SelectedItem.ToString());
            if (selectedLanguage == null)
            {
                textBoxNrLetters.Clear();
                listViewLetters.Clear();
                //chartLetters.cle
                return;
            }

            textBoxNrLetters.Text = selectedLanguage.NrLetters.ToString();

            listViewLetters.Items.Clear();
            foreach (var letter in selectedLanguage.letters)
                listViewLetters.Items.Add(new ListViewItem(new string[] { letter.Name.ToString(), letter.Nr.ToString() }));
            ShowChart();

        }

        private void listViewLetters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void chartLetters_Click(object sender, EventArgs e)
        {
            
        }
    }
}
