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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
  //          memset(_trigramWeights, 0, sizeof(_trigramWeights));
  //          memset(_totalWeight, 0, sizeof(_totalWeight));
  //          wxString inputText = _txtInput->GetValue();
  //          int numWords = _spnNumWords->GetValue();

  //          if (!inputText.Len())
  //          {
  //              wxMessageBox("Nothing to base output on.");
  //              return;
  //          }

  //          const char* input = inputText.mb_str();
  //          int length = (int)strlen(input);
  //          int count;
  //          int num = 0;

  //          // Set first letter to space.
  //          _previousPreviousLetter = 0;
  //          _previousLetter = GetLetterNumber(input[0]);

  //          // We start at one because we set the initial letter above.
  //          for (count = 1; count < length; count++)
  //          {
  //              num = GetLetterNumber(input[count]);
  //              if (num != -1)
  //              {
  //                  _trigramWeights[_previousPreviousLetter][_previousLetter][num]++;
  //                  _totalWeight[_previousPreviousLetter][_previousLetter]++;
  //                  _previousPreviousLetter = _previousLetter;
  //                  _previousLetter = num;
  //              }
  //          }

  //          // When generating, start with the previous letter as a space so we get realistic word beginnings.
  //          _previousLetter = 0;

  //          // TODO: Set _previousLetter to a digram generation from chart.
  //          _previousLetter = GetLetterNumber(input[0]);
  //          _previousPreviousLetter = 0;

  //          wxString outputText = input[0];
  //          outputText += GenerateRandomLetter(false);

  //          int words = 0;
  //          int letters = 0;
  //          while (words < numWords)
  //          {
  //              char newletter = GenerateRandomLetter(true);
  //              if (newletter == 32)
  //              {
  //                  words++;
  //                  outputText += "\n";
  //              }
  //              else
  //              {
  //                  outputText += newletter;
  //              }
  //              letters++;
  //              _previousPreviousLetter = _previousLetter;
  //              _previousLetter = GetLetterNumber(newletter);
  //              if (letters > 12000)
  //              {
  //                  _txtOutput->SetValue("Generated output invalid.  Are you sure you have enough input text?");

  //          event.Skip();
		//	return;
		//}
  //  }

  //  char outputExamine[4096];
  //  memset(outputExamine, 0, 4096 );
  //  memcpy(outputExamine, outputText.mb_str(), outputText.Len() );
  //  _txtOutput->SetValue(outputText);

  //  event.Skip();
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
    }
}


// Case insensitive, gets array position of a particular letter.
//int MainDlg::GetLetterNumber(char letter)
//{
//    // Convert newlines to spaces.
//    if (letter == 10)
//    {
//        return 0;
//    }
//    if (letter < 32 || letter > 126)
//    {
//        return -1;
//    }
//    return (letter - 32);
//}

//char MainDlg::GenerateRandomLetter(bool trigram)
//{
//    int numOptions = _totalWeight[_previousPreviousLetter][_previousLetter];

//    // This should NEVER happen.
//    if (numOptions == 0)
//    {
//        return '@';
//    }

//    int selection = rand() % numOptions;
//    int count;
//    int total = 0;

//    if (trigram)
//    {
//        for (count = 0; count < 95; count++)
//        {
//            total += _trigramWeights[_previousPreviousLetter][_previousLetter][count];
//            if (selection < total)
//            {
//                return GetLetter(count);
//            }
//        }
//    }
//    else
//    {
//        for (count = 0; count < 95; count++)
//        {
//            //total += _trigramWeights[_previousLetter][count][0];
//            total += _trigramWeights[0][_previousLetter][count];
//            if (selection < total)
//            {
//                return GetLetter(count);
//            }
//        }
//    }
//    // PANIC!  No match, our logic is broken.
//    return '*';
//}
//char MainDlg::GetLetter(int number)
//{
//    if (number > 0 || number < 95)
//    {
//        return (number + 32);
//    }
//    else
//    {
//        return 0;
//    }
//}
