using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Litery
{
    public partial class FindLanguage : Form
    {
        private List<LetterStatistic> StatisticList;
        private LetterStatistic textToFindStatistic;

        private void ClearChart()
        {
            chartLetters.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartLetters.Series["EN"].Points.Clear();
            chartLetters.Series["DE"].Points.Clear();
            chartLetters.Series["PL"].Points.Clear();

        }

        public void ShowChart(Dictionary<LetterNr, List<double>> freqMap)
        {

            chartLetters.Series["Searched"].SetDefault(true);
            chartLetters.Series["EN"].SetDefault(true);
            chartLetters.Series["DE"].SetDefault(true);
            chartLetters.Series["PL"].SetDefault(true);

            chartLetters.Series["Searched"].Enabled = true;
            chartLetters.Series["EN"].Enabled = true;
            chartLetters.Series["DE"].Enabled = true;
            chartLetters.Series["PL"].Enabled = true;

            chartLetters.Visible = true;

            string[] letters_labels = new string[freqMap.Count];
            int i = 0;
            foreach (var pair in freqMap)
            {
                letters_labels[i] = pair.Key.Name.ToString();
                i++;
            }

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

            i = 0;
            foreach (var pair in freqMap)
            {
                foreach(var lang in pair.Value)
                {
                    switch(pair.Value.IndexOf(lang))
                    {
                        case 0: chartLetters.Series["Searched"].Points.AddXY(i * 10, lang); break;
                        case 1: chartLetters.Series["EN"].Points.AddXY(i * 10, lang); break;
                        case 2: chartLetters.Series["DE"].Points.AddXY(i * 10, lang); break;
                        case 3: chartLetters.Series["PL"].Points.AddXY(i * 10, lang); break;
                    }
                  
                }
                i++;
            }


            chartLetters.Series["Searched"].ChartType = SeriesChartType.Line;
            chartLetters.Series["EN"].ChartType = SeriesChartType.Line;
            chartLetters.Series["DE"].ChartType = SeriesChartType.Line;
            chartLetters.Series["PL"].ChartType = SeriesChartType.Line;


            chartLetters.Series["Searched"].MarkerSize = 8;
            chartLetters.Series["EN"].MarkerSize = 8;
            chartLetters.Series["DE"].MarkerSize = 8;
            chartLetters.Series["PL"].MarkerSize = 8;


            chartLetters.Series["Searched"].MarkerStyle = MarkerStyle.Circle;
            chartLetters.Series["EN"].MarkerStyle = MarkerStyle.Circle;
            chartLetters.Series["DE"].MarkerStyle = MarkerStyle.Circle;
            chartLetters.Series["PL"].MarkerStyle = MarkerStyle.Circle;

            chartLetters.Show();

            Controls.Add(chartLetters);
            chartLetters.Show();

        }

        public FindLanguage(List<LetterStatistic> statistic)
        {
            InitializeComponent();

            StatisticList = statistic;

            comboBoxMode.Items.Add("All letters");
            comboBoxMode.Items.Add("First letters");
            comboBoxMode.Items.Add("Last letters");
            comboBoxMode.SelectedIndex = 0;

            textToFindStatistic = new LetterStatistic("Language to find");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader myStream = null;
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textToFindStatistic = new LetterStatistic("Language to find");

                try
                {
                    myStream = new StreamReader(openFileDialog2.FileName, Encoding.Default);
                    char previousLetter = ' ';
                    do
                    {
                        var ch = (char)myStream.Read();
                        textToFindStatistic.Count(ch, previousLetter);
                        previousLetter = ch;
                    }
                    while (!myStream.EndOfStream);

                    CompareLanguage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
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

        private long GetNrLetters(LetterStatistic selectedLanguage)
        {
            if (comboBoxMode.Items.Count > 0)
            {
                var mode = comboBoxMode.SelectedItem.ToString();
                if (mode == "All letters")
                    return selectedLanguage.NrLetters;
                if (mode == "First letters")
                    return selectedLanguage.NrFirstLetters;
                if (mode == "Last letters")
                    return selectedLanguage.NrLastLetters;
            }
            return 0;
        }


        private void CompareLanguage()
        {
            var polishStatistic = StatisticList.Find(x => x.Language == "Polish");
            var englishStatistic = StatisticList.Find(x => x.Language == "English");
            var germanStatistic = StatisticList.Find(x => x.Language == "German");

            var polishLetters = GetLetters(polishStatistic);
            var englishLetters = GetLetters(englishStatistic);
            var germanLetters = GetLetters(germanStatistic);

            double polishError = 0.0, englishError = 0.0, germanError = 0.0;

            if (textToFindStatistic == null)
                return;

            Dictionary<LetterNr, List<double>> freqMap = new Dictionary<LetterNr, List<double>>();
            foreach (var letter in GetLetters(textToFindStatistic))
            {
                double letterFreq = (double)letter.Nr / (double)textToFindStatistic.NrLetters * 100;
                
                double letterFreqPolish = 0.0, letterFreqEnglish = 0.0, letterFreqGerman = 0.0;

                var foundPolishLetter = polishLetters.Find(x => x.Name == letter.Name);
                if (foundPolishLetter != null)
                    letterFreqPolish = (double)foundPolishLetter.Nr / (double)GetNrLetters(polishStatistic) * 100;

                var foundEnglishLetter = englishLetters.Find(x => x.Name == letter.Name);
                if (foundEnglishLetter != null)
                    letterFreqEnglish = (double)foundEnglishLetter.Nr / (double)GetNrLetters(englishStatistic) * 100;

                var foundGermanLetter = germanLetters.Find(x => x.Name == letter.Name);
                if (foundGermanLetter != null)
                    letterFreqGerman = (double)foundGermanLetter.Nr / (double)GetNrLetters(germanStatistic) * 100;

                freqMap.Add(letter, new List<double>()
                                            {
                                                letterFreq,
                                                letterFreqEnglish,
                                                letterFreqGerman,
                                                letterFreqPolish
                                            });
                
                polishError += Math.Abs((letterFreq - letterFreqPolish));
                englishError += Math.Abs((letterFreq - letterFreqEnglish));
                germanError += Math.Abs((letterFreq - letterFreqGerman));
            }

            ClearChart();
            ShowChart(freqMap);
            
            string sumOfFreq = "Polish " + polishError.ToString() +
                " English " + englishError.ToString() +
                " German " + germanError.ToString();

            string text = "";

            if(polishError < englishError && polishError < germanError)
                text = "Detected Polish. Sum of difference in frequence " + sumOfFreq;
            if (englishError < polishError && englishError < germanError)
                text = "Detected English. Sum of difference in frequence " + sumOfFreq;
            if (germanError < englishError && germanError < polishError)
               text = "Detected German. Sum of difference in frequence " + sumOfFreq;

            MessageBox.Show(text);
            textBox.Text = text;
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompareLanguage();
        }


    }
}
