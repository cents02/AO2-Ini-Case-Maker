using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CC_Case_Maker
{
    public partial class add_thing : Form
    {
        public string piccpath1 { get; set; } = "";
        public string piccpath2 { get; set; } = "";
        public string description { get; set; } = "";
        public string titlee { get; set; } = "";

     
        public add_thing(string titlee, string description, string picpath1, string picpath2)
        {
            try
            {
                InitializeComponent();
                textBox1.Text = titlee;
                richTextBox1.Text = description;
                pictureBox1.Image = Image.FromFile(picpath2);
                piccpath1 = picpath2;
                piccpath2 = picpath1;
            }
            catch(Exception ex)
            {
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string orpat = Application.StartupPath;
            string thing = "base\\evidence";
            string prr = System.IO.Path.Combine(orpat, thing);
            if (System.IO.Directory.Exists(prr))
            {
                openFileDialog1.InitialDirectory = prr;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    string picpath = openFileDialog1.FileName;
                    blop(picpath);

                }
            }
            else
            {


                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    string picpath = openFileDialog1.FileName;
                    blop(picpath);

                }
            }
        }
        private void blop(string picpath)
        {
            pictureBox1.Image = Image.FromFile(picpath);
            string[] extract = Regex.Split(picpath, "evidence");
            string pipath2 = Regex.Replace(extract[1], "evidence", "");
            pipath2 = pipath2.Substring(1);
            pipath2 = pipath2.Replace("\\", "/");
            piccpath1 = picpath;
            piccpath2 = pipath2;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            description = richTextBox1.Text;
            titlee = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
