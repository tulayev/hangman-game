using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Viselka
{
    public partial class FormViselka : Form
    {
        private string abc = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string word;
        private int errors;
        private Button[] buttonKeys;
        private static Random random = new Random();

        public FormViselka()
        {
            InitializeComponent();
            InitKeys();
            InitGame();
        }

        private void InitKeys()
        {
            buttonKeys = new Button[abc.Length];
            int x, y;
            int buttonWidth = panelKeys.Width / 11;
            int buttonHeight = panelKeys.Height / 3;
            for (int i = 0; i < abc.Length; i++)
            {
                buttonKeys[i] = new Button();
                x = i % 11;
                y = i / 11;
                buttonKeys[i].Location = new Point(x * buttonWidth, y * buttonHeight);
                buttonKeys[i].Size = new Size(buttonWidth - 2, buttonHeight - 4);
                buttonKeys[i].TabIndex = i;
                buttonKeys[i].Tag = i;
                buttonKeys[i].Text = abc.Substring(i, 1);
                buttonKeys[i].Click += new EventHandler(this.button_Click);
                panelKeys.Controls.Add(buttonKeys[i]);
            }
        }

        private void InitGame()
        {
            errors = 0;
            for (int i = 0; i < abc.Length; i++)
            {
                buttonKeys[i].Visible = true;
            }
            ChooseWord();
            labelWord.Text = new String('#', word.Length);
            ShowPicture(0);
        }

        private void ChooseWord()
        {
            string[] nl = { "\n" };
            string[] lines = Properties.Resources.файл_со_словами.Split(nl, StringSplitOptions.RemoveEmptyEntries);
            do
            {
                word = lines[random.Next(0, lines.Length)];
            } while (word.Length < 5);
        }

        private void button_Click(object sender, EventArgs e)
        {
            int letterNumber = (int)((Button)sender).Tag;
            HideLetter(letterNumber);
            if(word.IndexOf(abc[letterNumber]) >= 0)
            {
                // if chosen letter exists
                // show all the letters in a word
                string showWord = "";
                for (int i = 0; i < labelWord.Text.Length; i++)
                {
                    if(labelWord.Text[i] == '#')
                    {
                        if(word[i] == abc[letterNumber])
                        {
                            showWord += abc[letterNumber];
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
                    ShowWin();
                    InitGame();
                }
            }
            else
            {
                // these letters do not exist in a word
                errors++;
                ShowPicture(errors);
                if(errors >= 7)
                {
                    ShowLose();
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
            textList.Text = "";
            int[] used = new int[abc.Length];
            string[] nl = { "\n" };
            string[] words = Properties.Resources.файл_со_словами.Split(nl, StringSplitOptions.RemoveEmptyEntries);
            string m = labelWord.Text;
            StringBuilder sb = new StringBuilder();
            int total = 0;

            foreach (string word in words)
            {
                if(word.Length != m.Length)
                {
                    continue;
                }

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
                {
                    continue;
                }

                for (int i = 0; i < abc.Length; i++)
                {
                    if (word.Contains(abc[i].ToString()))
                    {
                        used[i]++;
                    }
                }

                sb.AppendLine(word);
                total++;
            }

            int max = 0;
            int maxi = -1;
            for (int i = 0; i < abc.Length; i++)
            {
                if (IsLetterFree(abc[i]))
                {
                    if(used[i] > max)
                    {
                        max = used[i];
                        maxi = i;
                    }
                }
            }
            sb.AppendLine("Назовите букву " + abc[maxi]); 

            textList.Text = "Найдено слов: " + total.ToString() + Environment.NewLine +
                "Лучшая буква: " + abc[maxi] + Environment.NewLine +
                "Использована: " +  used[maxi] + Environment.NewLine + 
                sb.ToString();
        }

        private bool IsLetterFree(char v)
        {
            int i = abc.IndexOf(v);
            return buttonKeys[i].Visible;
        }

        private void ShowLose()
        {
            MessageBox.Show("К сожалению вас повесили!\nЭто было слово " + word, "Вы проиграли");
        }

        private void ShowWin()
        {
            MessageBox.Show("Поздравляю! Вы угадали слово", "Вы выиграли");
        }

        private void ShowPicture(int number)
        {
            switch (number)
            {
                case 0: pictureStep.Image = Properties.Resources.step0; break;
                case 1: pictureStep.Image = Properties.Resources.step1; break;
                case 2: pictureStep.Image = Properties.Resources.step2; break;
                case 3: pictureStep.Image = Properties.Resources.step3; break;
                case 4: pictureStep.Image = Properties.Resources.step4; break;
                case 5: pictureStep.Image = Properties.Resources.step5; break;
                case 6: pictureStep.Image = Properties.Resources.step6; break;
                case 7: pictureStep.Image = Properties.Resources.step7; break;
                default: pictureStep.Image = null; break;
            }
        }

        private void HideLetter(int number)
        {
            // to make buttons disappear
            buttonKeys[number].Visible = false;
        }

        private void labelWord_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                textList.Visible = !textList.Visible;
            }
        }
    }
}
