using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Рапорт
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void SimpleRaport_Click(object sender, EventArgs e)
        {
            SympleRaport raport = new SympleRaport();
            raport.Show();
            Hide();
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
                if(textFile[0] == "firstcommand")
                {
                    SympleRaport raport = new SympleRaport();
                    raport.Initiate(textFile);
                    raport.Show();
                    Hide();
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

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void рапортПоКоманде2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecondRaport raport = new SecondRaport();
            raport.Show();
            Hide();
        }
    }
}