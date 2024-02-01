using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txtEditor
{
    public class MenuItems
    {
        string path = "";
        public void openToolStripMenuItem_Click(object sender, EventArgs e, object richTxt)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "TextDocument | *.txt",
                ValidateNames = true,
                Multiselect = false
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        path = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        richTxt = text.Result;
                    }
                }
            }
        }
    }
}
