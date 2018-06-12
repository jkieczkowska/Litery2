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
    public partial class Form1 : Form
    {
        public List<LetterStatistic> statistic;

        public Form1()
        {
            InitializeComponent();

            statistic = new List<LetterStatistic>();
            statistic.Add(new LetterStatistic("Polish"));
            statistic.Add(new LetterStatistic("English"));
            statistic.Add(new LetterStatistic("German"));

            foreach (var lang in statistic)
                comboBoxLanguages.Items.Add(lang.Language);
            comboBoxLanguages.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedLanguage = statistic.Find(x => x.Language == comboBoxLanguages.SelectedItem.ToString());

            StreamReader myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "C:\Users\Justyna\Desktop";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myStream = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    char previousLetter = ' ';
                    do
                    {
                        var ch = (char)myStream.Read();
                        selectedLanguage.Count(ch, previousLetter);
                        previousLetter = ch;
                    }
                    while (!myStream.EndOfStream);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var statisticDialog = new Statistic(statistic);
            statisticDialog.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonFindLanguage_Click(object sender, EventArgs e)
        {
            var findDialog = new FindLanguage(statistic);
            findDialog.ShowDialog();
        }
    }
}
