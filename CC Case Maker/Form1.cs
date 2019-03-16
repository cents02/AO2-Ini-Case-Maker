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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox4.Enabled = false;
            checkBox2.Checked = true;
            ToolTip auth  = new ToolTip();
            auth.SetToolTip(label3, "Sets the author of the case, it appears when the case is loaded in OCC");
            ToolTip cmd = new ToolTip();
            cmd.SetToolTip(label5, "Sets the doc which will appear to the CM upon loading the case");
            ToolTip doc = new ToolTip();
            doc.SetToolTip(label4, "Sets the doc which can be seen by anybody if they do /doc");
            ToolTip stat = new ToolTip();
            stat.SetToolTip(label6, "Sets the status of the courtroom upon loading the case");
            ToolTip name = new ToolTip();
            name.SetToolTip(label8, "Sets the name of the case, and with this name the case can be loaded with");
            ToolTip Ezexp = new ToolTip();
            Ezexp.SetToolTip(checkBox1, "If it finds the cases folder, it automatically exports the ini file there.");
            ToolTip smde = new ToolTip();
            smde.SetToolTip(checkBox2, "It asks confirmation before deleting stuff for extra protection");
            ToolTip slf = new ToolTip();
            slf.SetToolTip(checkBox3, "Determines whther the program should be self aware or not.");
            ToolTip load = new ToolTip();
            load.SetToolTip(button2, "Loads a case ini");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "other")
            {
                textBox4.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
            }
        }
        List<Button> buttons = new List<Button>();
        int x = 0;
        int ze = 0;
        string[] titlee = new string[1000];
        string[] desce = new string[1000];
        string[] pathh = new string[1000];
        string[] paaath = new string[1000];
        private void addevid_Click(object sender, EventArgs e)
        {

            
            add_thing frm = new add_thing("", "", "", "");
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //do things while using the input
                Console.WriteLine(frm.piccpath1); //for debugging reasons
                btnadd(frm.titlee, frm.description,  frm.piccpath1, frm.piccpath2);
                
            }

        }
       
        

        private void btnadd(string title,  string desc, string picpath, string picpath2)
        {
           
            titlee[x] = title;
            desce[x] = desc;
            pathh[x] = picpath2;
            paaath[x] = picpath;
            Button newButton = new Button();
            if(ze == 0 )
            {
                newButton.Location = new Point(addevid.Left + 80, addevid.Top);
            }
            else
            {
              if (buttons[x - 1].Left >= 240)
                {                  
                    newButton.Location = new Point(addevid.Left , buttons[x - 1].Top + 70);                   
                }
                else
                {
                    newButton.Location = new Point(buttons[x - 1].Left + 80, buttons[x - 1].Top);
                }               
            }
            x++;
            ze++;
            //creates button
            buttons.Add(newButton);
            newButton.Name = x.ToString();
            newButton.Click += new EventHandler(newbut_click);
            newButton.MouseDown += new MouseEventHandler(newbut_rclick);
            try
            {               
                newButton.BackgroundImage = Image.FromFile(picpath);
                newButton.Size = newButton.BackgroundImage.Size;
                ToolTip ToolTip1 = new ToolTip();
                ToolTip1.SetToolTip(newButton, title);
            }
            catch(Exception ex)
            {
         
            }
            panel1.Controls.Add(newButton);
        }
        Int64 tmpname;
        Control tmpcntrl;
        private void newbut_rclick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip Menu = new ContextMenuStrip();
            ToolStripMenuItem MenuOpenPO = new ToolStripMenuItem("Delete");
            MenuOpenPO.MouseDown += new MouseEventHandler(dltbtn_Click);
            Menu.Items.AddRange(new ToolStripItem[] { MenuOpenPO });
            //Assign created context menu strip to the DataGridView
            ((Button)sender).ContextMenuStrip = Menu;
            tmpname = Int64.Parse(((Button)sender).Name) - 1;
            tmpcntrl = ((Button)sender);
        }
        private void dltbtn_Click(object sender, MouseEventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                string message = "Confirm to delete evidence?";
                string caption = "Confirm";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    tmpcntrl.ContextMenuStrip.Hide();
                    titlee[tmpname] = "-";
                    tmpcntrl.Hide();
                    btnmoveback(tmpcntrl.Name);
                }
                else
                {
                    tmpcntrl.Hide();
                }

            }
            else
            {
                tmpcntrl.ContextMenuStrip.Hide();
                titlee[tmpname] = "-";
                tmpcntrl.Hide();
                btnmoveback(tmpcntrl.Name);
            }

        }
        private void btnmoveback(string id)
        {
            
            for (int z = int.Parse(id); z < x; z++)
            {
                
                if (buttons[z].Top == addevid.Top)
                {
                    if (buttons[z].Left != addevid.Left - 80)
                    {
                        buttons[z].Location = new Point(buttons[z].Left - 80, addevid.Top);
                    }
                }
                else
                {
                    if (buttons[z].Left == addevid.Left)
                    {
                        buttons[z].Location = new Point(buttons[z - 1].Left + 80, buttons[z - 1].Top);
                    }
                    else
                    {
                        buttons[z].Location = new Point(buttons[z].Left - 80, buttons[z].Top);
                    }
                }
            }
            ze -= 1;
         // x = x - 1;
        }
        private void newbut_click(object sender, EventArgs e)
        {
            //Add button Editor Here, every buttons name is the same with the index for the info.
            string id = ((Button)sender).Name;
            int id2 = Int32.Parse(id) - 1;
            add_thing frm = new add_thing(titlee[id2 ], desce[id2 ], pathh[id2 ], paaath[id2 ]);



            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                titlee[id2] = frm.titlee;
                desce[id2] = frm.description;
                pathh[id2] = frm.piccpath2;
                paaath[id2] = frm.piccpath1;
                try
                {
                    ((Button)sender).BackgroundImage = Image.FromFile(frm.piccpath1);
                }
                catch(Exception ex)
                {

                }
           }
        }

        private void exportbtn_Click(object sender, EventArgs e)
        {
            //This button is for the creation of ini 
            if (checkBox1.Checked == true)
            {
                string origpath = Application.StartupPath;
                string tmp1 = "base\\cases";

                string papth = System.IO.Path.Combine(origpath, tmp1);
                string paapth = System.IO.Path.Combine(papth, textBox5.Text);
                if(System.IO.Directory.Exists(papth))
                {
                    write(paapth);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("I can't acces the cases directory! Make sure the exe next to the CC client or turn off EasyExport!!", "ERROR");
                }
            }
            else
            {
                saveFileDialog1.FileName = textBox5.Text;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string outpath = saveFileDialog1.FileName;
                    write(outpath);
                }

            }
        }
        private void write(string path)
        {
            if (checkBox3.Checked == true)
            {
                System.Windows.Forms.MessageBox.Show("What is this place? Where am I?", "Hello?");
                System.Windows.Forms.MessageBox.Show("So I am supposed to write you this..." + textBox5.Text, "Should I?");
                System.Media.SystemSounds.Hand.Play();

                System.Windows.Forms.MessageBox.Show("You know what. No. Goodbye", "Screw this");
                this.Close();
            }
            else
            {
                string[] outppuut = new string[1000];
                outppuut[0] = "[General]";
                outppuut[1] = "author = \"" + textBox1.Text + "\"";
                outppuut[2] = "doc = \"" + textBox2.Text + "\"";
                outppuut[3] = "cmdoc = \"" + textBox3.Text + "\"";
                if (textBox4.Enabled == true)
                {
                    outppuut[4] = "status = \"" + textBox4.Text + "\"";
                }
                else
                {

                    try
                    {
                        outppuut[4] = "status = \"" + comboBox1.SelectedItem.ToString() + " \"";
                    }
                    catch (Exception ex)
                    {
                        outppuut[4] = "";
                    }

                }

                int o = 5;

                for (int i = 0; i < x; i++)
                {
                    if (titlee[i] != "-" && titlee[i] != "")
                    {
                        outppuut[o] = "[" + i + "]";
                        o++;
                        outppuut[o] = "name = \"" + titlee[i] + "\"";
                        o++;
                        outppuut[o] = "description = \"" + desce[i] + "\"";
                        o++;
                        outppuut[o] = "image = \"" + pathh[i] + "\"";
                        o++;
                    }

                }
                System.IO.File.WriteAllLines(path + ".ini", outppuut);
                System.Windows.Forms.MessageBox.Show("The file has succesfully exported!", "Succes");
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //load button
            string orpat = Application.StartupPath;
            string thing = "base\\cases";
            string prr = System.IO.Path.Combine(orpat, thing);
            string picpath = "";
            if (System.IO.Directory.Exists(prr))
            {
                openFileDialog1.InitialDirectory = prr;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                     picpath = openFileDialog1.FileName;
                    

                }
            }
            else
            {


                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    picpath = openFileDialog1.FileName;
                    

                }
            }
            string[] tmpread = System.IO.File.ReadAllLines(picpath);
            tmpread[1] = tmpread[1].Substring(tmpread[1].IndexOf('"') + 1);
            textBox1.Text = tmpread[1].TrimEnd('"');
            tmpread[2] = tmpread[2].Substring(tmpread[2].IndexOf('"') + 1);
            textBox2.Text = tmpread[2].TrimEnd('"');
            tmpread[3] = tmpread[3].Substring(tmpread[3].IndexOf('"') + 1);
            textBox3.Text = tmpread[3].TrimEnd('"');
            if (comboBox1.Items.Contains(tmpread[3]))
            {
                comboBox1.SelectedItem = tmpread[3];
            }
           
            
            tmpread[4] = tmpread[4].Substring(tmpread[4].IndexOf('"') + 1);
            tmpread[4] = tmpread[4].TrimEnd('"');
            if (comboBox1.Items.Contains(tmpread[4]) && tmpread[4] != "")
            {
                comboBox1.SelectedItem = tmpread[4];
            }
            else
            {
                comboBox1.SelectedItem = "other";
                textBox4.Text = tmpread[4];
            }
            string nm;
            string des;
            string im;
            
            
            string im2;
            string im3;
            var im21 = System.IO.Path.GetDirectoryName(picpath);
            string im22 = System.IO.Directory.GetParent(im21).FullName;
            string[] tmpim2 = {im22 , "evidence" };
            im2 = System.IO.Path.Combine(tmpim2);
            if (System.IO.Directory.Exists(im2))
            {
                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("I can't find the client. Please navigate to the client folder on the next dialog!", "Help!");
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        tmpim2[0] = fbd.SelectedPath;
                        im2 = System.IO.Path.Combine(tmpim2);
                        while (System.IO.Directory.Exists(im2) != true)
                        {
                            MessageBox.Show("Wrong Folder!", "ERROR");
                            using (var fdb = new FolderBrowserDialog())
                            {
                                DialogResult resultt = fbd.ShowDialog();
                                if (resultt == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                                {
                                    tmpim2[0] = fbd.SelectedPath;
                                    im2 = System.IO.Path.Combine(tmpim2);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong!", "ERROR");
                        goto A;
                    }
                }
            }
            for (int x = 5; x < tmpread.Length;  x++)
            {
                if(tmpread[x].Contains("["))
                {
                    x++;
                    tmpread[x] = tmpread[x].Substring(tmpread[x].IndexOf('"') + 1);
                    nm = tmpread[x].TrimEnd('"');
                    x++;
                    tmpread[x] = tmpread[x].Substring(tmpread[x].IndexOf('"') + 1);
                    des = tmpread[x].TrimEnd('"');
                    
                    x++;
                    tmpread[x] = tmpread[x].Substring(tmpread[x].IndexOf('"') + 1);
                    im = tmpread[x].TrimEnd('"');
                    im3 = System.IO.Path.Combine(im2, im);
                    btnadd(nm, des, im3, im);
                    
                }


            }
        A:;
        }
        
    }
}

