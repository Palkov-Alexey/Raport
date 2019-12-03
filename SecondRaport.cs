using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using SecondRaportCr;

namespace Рапорт
{
    public partial class SecondRaport : Form
    {
        public SecondRaport()
        {
            InitializeComponent();
        }

        public void Initiate(string[] text)
        {
            Whom1.Text = text[1];
            TextRaport1.Text = text[2];
            Position1.Text = text[3];
            Rank1.Text = text[4];
            Name_1.Text = text[5];
            Whom_2.Text = text[6];
            TextRaport_2.Text = text[7];
            Position_2.Text = text[8];
            Rank_2.Text = text[9];
            Name_2.Text = text[10];
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string[] textRaport1 = TextRaport1.Text.Split('\n');
            string[] textRaport2 = TextRaport_2.Text.Split('\n');
            string[] txt = monthCalendar1.SelectionStart.ToString().Split(' '); //Извлечение данных из календаря
            SecondRaportCreate.Create(
                Whom1.Text, 
                LRaport.Text, 
                textRaport1, txt[0], 
                Position1.Text, 
                Rank1.Text, 
                Name_1.Text, 
                Whom_2.Text, 
                textRaport2, 
                Position_2.Text,
                Rank_2.Text, 
                Name_2.Text);
        }

        private void SecondRaport_FormClosed(object sender, FormClosedEventArgs e)
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
                File.WriteAllText(
                    fileName,
                    "secondcommand&" +
                    Whom1.Text + "&" +
                    TextRaport1.Text + "&" +
                    Position1.Text + "&" +
                    Rank1.Text + "&" +
                    Name_1.Text + "&" +
                    Whom_2.Text + "&" +
                    TextRaport_2.Text + "&" +
                    Position_2.Text + "&" +
                    Rank_2.Text + "&" +
                    Name_2.Text);
            }
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
                if (textFile[0] == "secondcommand")
                {
                    Whom1.Text = textFile[1];
                    TextRaport1.Text = textFile[2];
                    Position1.Text = textFile[3];
                    Rank1.Text = textFile[4];
                    Name_1.Text = textFile[5];
                    Whom_2.Text = textFile[6];
                    TextRaport_2.Text = textFile[7];
                    Position_2.Text = textFile[8];
                    Rank_2.Text = textFile[9];
                    Name_2.Text = textFile[10];
                }
                else if (textFile[0] == "firstcommand")
                {
                    SympleRaport raport = new SympleRaport();
                    raport.Initiate(textFile);
                    raport.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Error");
            }
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}