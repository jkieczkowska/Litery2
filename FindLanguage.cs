using System;
using System.Collections.Generic;
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

                polishError += Math.Abs((letterFreq - letterFreqPolish));
                englishError += Math.Abs((letterFreq - letterFreqEnglish));
                germanError += Math.Abs((letterFreq - letterFreqGerman));
            }

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
