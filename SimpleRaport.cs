using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SimpleRaportCr;

namespace Рапорт
{
    public partial class SympleRaport : Form
    {
        public SympleRaport()
        {
            InitializeComponent();
        }

        public void Initiate(string[] t)
        {
            Whom.Text = t[1];
            TextRaport.Text = t[2];
            Position.Text = t[3];
            Rank.Text = t[4];
            TextName.Text = t[5];
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "text files (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string[] textFile = File.ReadAllText(fileName).Split('&');
                if (textFile[0] == "firstcommand")
                {
                    Whom.Text = textFile[1];
                    TextRaport.Text = textFile[2];
                    Position.Text = textFile[3];
                    Rank.Text = textFile[4];
                    TextName.Text = textFile[5];
                }
                else if (textFile[0] == "secondcommand")
                {
                    SecondRaport raport = new SecondRaport();
                    raport.Initiate(textFile);
                    raport.Show();
                    Hide();
                }
            }
        }

        private void SimpleRaport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "text files (*.txt)|*.txt"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                File.WriteAllText(fileName,
                    "firstcommand&" +
                    Whom.Text + "&" +
                    TextRaport.Text + "&" +
                    Position.Text + "&" +
                    Rank.Text + "&" +
                    TextName.Text);
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string[] txt = monthCalendar1.SelectionStart.ToString().Split(' '); //Извлечение данных из календаря
            string[] raportText = TextRaport.Text.Split('\n'); //Перевод текста из RichTextBox в текстовый массив
            SimpleRaportCreate.Create(Whom.Text, LRaport.Text, raportText, txt[0], Position.Text, Rank.Text, TextName.Text); //Передача данных во внешнюю библиотеку классов
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Hide();
        }
    }
}
