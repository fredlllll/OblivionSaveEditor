using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OblivionSaveEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                using(FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    SaveFile sf = new SaveFile();
                    sf.Load(fs);
                    button1.Text = "success";
                }
            }
        }
    }
}
