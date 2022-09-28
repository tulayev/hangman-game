using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hangman
{
    public partial class MainForm : Form
    {
        private const string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        
        private string _word;
        private int _errors;
        private Button[] _buttons;
        private static readonly Random _random = new Random();

        public MainForm()
        {
            InitializeComponent();
            InitKeys();
            InitGame();
        }

        private void InitKeys()
        {
            _buttons = new Button[Alphabet.Length];
            int x, y;
            int buttonWidth = panelKeys.Width / 11;
            int buttonHeight = panelKeys.Height / 3;

            for (int i = 0; i < Alphabet.Length; i++)
            {
                _buttons[i] = new Button();
                x = i % 11;
                y = i / 11;
                _buttons[i].Location = new Point(x * buttonWidth, y * buttonHeight);
                _buttons[i].Size = new Size(buttonWidth - 2, buttonHeight - 4);
                _buttons[i].TabIndex = i;
                _buttons[i].Tag = i;
                _buttons[i].Text = Alphabet.Substring(i, 1);
                _buttons[i].Click += new EventHandler(this.button_Click);
                panelKeys.Controls.Add(_buttons[i]);
            }
        }

        private void InitGame()
        {
            _errors = 0;
            
            for (int i = 0; i < Alphabet.Length; i++)
            {
                _buttons[i].Visible = true;
            }

            ChooseWord();
            labelWord.Text = new String('#', _word.Length);
            ShowPicture(0);
        }

        private void ChooseWord()
        {
            string[] nl = { "\n" };
            string[] lines = Properties.Resources.файл_со_словами.Split(nl, StringSplitOptions.RemoveEmptyEntries);

            do
            {
                _word = lines[_random.Next(0, lines.Length)];
            } while (_word.Length < 5);
        }

        private void button_Click(object sender, EventArgs e)
        {
            int letterNumber = (int)((Button)sender).Tag;
            HideLetter(letterNumber);

            if(_word.IndexOf(Alphabet[letterNumber]) >= 0)
            {
                string showWord = String.Empty;

                for (int i = 0; i < labelWord.Text.Length; i++)
                {
                    if(labelWord.Text[i] == '#')
                    {
                        if(_word[i] == Alphabet[letterNumber])
                        {
                            showWord += Alphabet[letterNumber];
                        }
                        else
                        {
                            showWord += "#";
                        }
                    }
                    else
                    {
                        showWord += labelWord.Text[i];
                    }
                }

                labelWord.Text = showWord;

                if(showWord.IndexOf('#') == -1)
                {
                    ShowWinMsg();
                    InitGame();
                }
            }
            else
            {
                _errors++;
                ShowPicture(_errors);

                if(_errors >= 7)
                {
                    ShowLoseMsg();
                    InitGame();
                }
            }

            if (textList.Visible)
            {
                RunViselkaHelper();
            }
        }

        private void RunViselkaHelper()
        {
            textList.Text = String.Empty;
            var used = new int[Alphabet.Length];
            string[] nl = { "\n" };
            string[] words = Properties.Resources.файл_со_словами.Split(nl, StringSplitOptions.RemoveEmptyEntries);
            string m = labelWord.Text;
            var sb = new StringBuilder();
            int total = 0;

            foreach (string word in words)
            {
                if(word.Length != m.Length)
                    continue;

                bool ok = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if(m[i] == '#')
                    {
                        if (IsLetterFree(word[i]))
                        {
                            continue;
                        }
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                    else
                    {
                        if(word[i] == m[i])
                        {
                            continue; 
                        }
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                }

                if (!ok)
                    continue;

                for (int i = 0; i < Alphabet.Length; i++)
                {
                    if (word.Contains(Alphabet[i].ToString()))
                        used[i]++;
                }

                sb.AppendLine(word);
                total++;
            }

            int max = 0;
            int maxi = -1;

            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (IsLetterFree(Alphabet[i]))
                {
                    if(used[i] > max)
                    {
                        max = used[i];
                        maxi = i;
                    }
                }
            }

            sb.AppendLine($"Назовите букву {Alphabet[maxi]}"); 

            textList.Text = $"Найдено слов: {total}\r\n" +
                $"Лучшая буква: {Alphabet[maxi]}\r\n" +
                $"Использована: {used[maxi]}\r\n" + 
                $"{sb}";
        }

        private bool IsLetterFree(char c)
        {
            int i = Alphabet.IndexOf(c);
            return _buttons[i].Visible;
        }

        private void ShowLoseMsg() =>
            MessageBox.Show("К сожалению вас повесили!\nЭто было слово " + _word, "Вы проиграли");

        private void ShowWinMsg() =>
            MessageBox.Show("Поздравляю! Вы угадали слово", "Вы выиграли");

        private void ShowPicture(int number)
        {
            switch (number)
            {
                case 0: pictureStep.Image = Properties.Resources.step0; 
                    break;
                case 1: pictureStep.Image = Properties.Resources.step1; 
                    break;
                case 2: pictureStep.Image = Properties.Resources.step2; 
                    break;
                case 3: pictureStep.Image = Properties.Resources.step3; 
                    break;
                case 4: pictureStep.Image = Properties.Resources.step4; 
                    break;
                case 5: pictureStep.Image = Properties.Resources.step5; 
                    break;
                case 6: pictureStep.Image = Properties.Resources.step6; 
                    break;
                case 7: pictureStep.Image = Properties.Resources.step7; 
                    break;
                default: pictureStep.Image = null; 
                    break;
            }
        }

        private void HideLetter(int number) => _buttons[number].Visible = false;

        private void labelWord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                textList.Visible = !textList.Visible;
        }
    }
}
