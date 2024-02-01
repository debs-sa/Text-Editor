using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace txtEditor
{
    public partial class MainForm : Form
    {
        string path;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        int fileNumber = 1;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewWindow newWindow = new NewWindow("File " + fileNumber++);
            newWindow.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "TextDocument | *.txt", ValidateNames = true, Multiselect = false
            })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    using(StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        path = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        richTxt.Text = text.Result;
                    }
                }
            }

        }

        private void richTxt_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
