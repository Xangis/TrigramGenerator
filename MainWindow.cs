using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrigramGenerator
{
    public partial class MainWindow : Form
    {
        private char[, ,] _trigramWeights = new char[95, 95, 95];
        private char[,] _totalWeight = new char[95, 95];
        private int _previousLetter;
        private int _previousPreviousLetter;
        private Random _random;
        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            String inputText = txtInput.Text;
            int numWords = Decimal.ToInt32(numericUpDown1.Value);

            if (String.IsNullOrEmpty(inputText) || inputText.Length < 2)
            {
                MessageBox.Show("Nothing to base output on. Please add some input text.");
                return;
            }

            int length = inputText.Length;

            int count;
            int num = 0;

            // Set first letter to space.
            _previousPreviousLetter = 0;
            _previousLetter = GetLetterNumber(inputText[0]);

            // We start at one because we set the initial letter above.
            for (count = 1; count < length; count++)
            {
                num = GetLetterNumber(inputText[count]);
                if (num != -1)
                {
                    _trigramWeights[_previousPreviousLetter, _previousLetter, num]++;
                    _totalWeight[_previousPreviousLetter,_previousLetter]++;
                    _previousPreviousLetter = _previousLetter;
                    _previousLetter = num;
                }
            }

            // When generating, start with the previous letter as a space so we get realistic word beginnings.
            _previousLetter = 0;

            // TODO: Set _previousLetter to a digram generation from chart.
            _previousLetter = GetLetterNumber(inputText[0]);
            _previousPreviousLetter = 0;

            String outputText = inputText[0].ToString();
            outputText += Convert.ToChar(GenerateRandomLetter(false));

            int words = 0;
            int letters = 0;
            int wordLength = 0;
            while (words < numWords)
            {
                int newletter = GenerateRandomLetter(true);
                if (newletter == 32)
                {
                    if (wordLength > 0)
                    {
                        words++;
                        outputText += Environment.NewLine;
                        wordLength = 0;
                    }
                }
                else
                {
                    outputText += Convert.ToChar(newletter);
                    wordLength += 1;
                }
                letters++;
                _previousPreviousLetter = _previousLetter;
                _previousLetter = GetLetterNumber(newletter);
                if (letters > 12000)
                {
                    txtOutput.Text = "Generated output invalid.  Are you sure you have enough input text?";
                    return;
                }
            }

            txtOutput.Text = outputText;
        }

        private void txtInput_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            MessageBox.Show("dragenter");
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtInput_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            txtInput.Text = e.Data.GetData(DataFormats.Text).ToString();
            MessageBox.Show("dragdrop");
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = System.IO.File.ReadAllText(dialog.FileName);
            }
        }

        public int GetLetter(int number)
        {
            if (number > 0 || number < 95)
            {
                return (number + 32);
            }
            else
            {
                return 0;
            }
        }

        // Case insensitive, gets array position of a particular letter.
        public int GetLetterNumber(int letter)
        {
            // Convert newlines to spaces.
            if (letter == 10)
            {
                return 0;
            }
            if (letter < 32 || letter > 126)
            {
                return -1;
            }
            return (letter - 32);
        }
        private int GenerateRandomLetter(bool trigram)
        {
            int numOptions = _totalWeight[_previousPreviousLetter,_previousLetter];

            // This should NEVER happen.
            if (numOptions == 0)
            {
                return '@';
            }

            int selection =_random.Next(numOptions);
            int count;
            int total = 0;

            if (trigram)
            {
                for (count = 0; count < 95; count++)
                {
                    total += _trigramWeights[_previousPreviousLetter, _previousLetter, count];
                    if (selection < total)
                    {
                        return GetLetter(count);
                    }
                }
            }
            else
            {
                for (count = 0; count < 95; count++)
                {
                    total += _trigramWeights[0, _previousLetter, count];
                    if (selection < total)
                    {
                        return GetLetter(count);
                    }
                }
            }
            // PANIC!  No match, our logic is broken.
            return '*';
        }
    }
}

