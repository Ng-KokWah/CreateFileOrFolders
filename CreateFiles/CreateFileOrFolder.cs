using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateFiles
{
    public partial class CreateFileOrFolder : Form
    {
        private static String temp;
        private static int clicks = 0;
        public CreateFileOrFolder()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label5.Text = "Content";
                textBox2.Enabled = true;
                textBox2.Visible = true;
                textBox3.Enabled = false;
                textBox3.Visible = false;

                label6.Visible = true;
                textBox4.Enabled = true;
                textBox4.Visible = true;
                label7.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label5.Text = "Name";
                textBox2.Enabled = false;
                textBox2.Visible = false;
                textBox3.Enabled = true;
                textBox3.Visible = true;

                label6.Visible = false;
                textBox4.Enabled = false;
                textBox4.Visible = false;
                label7.Visible = false;
            }
        }

        private void CreateFileOrFolder_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox3.Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (clicks == 0)
            {
                
                if (textBox1.Text.Equals(null) || textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Please fill in all fields to continue!");
                }
                else
                {
                    temp = textBox1.Text;
                    
                    progressBar1.Increment(50);
                    label1.Text = "50%";
                    if (comboBox1.SelectedIndex == 0)
                    {
                        if (textBox2.Text.Equals(null) || textBox2.Text.Equals("") || textBox4.Text.Equals(null) || textBox4.Text.Equals(""))
                        {
                            MessageBox.Show("Please fill in all the fields to continue!");
                        }
                        else
                        {
                            if(textBox4.Text.Contains(".txt"))
                            {
                                RunCommands.runCmd("echo " + textBox2.Text + " > " + textBox4.Text, temp);
                                progressBar1.Increment(50);
                                label1.Text = "100%";
                                textBox1.Enabled = false;
                                comboBox1.Enabled = false;
                                textBox2.Enabled = false;
                                textBox4.Enabled = false;
                                btnSelectFile.Enabled = false;
                                btnCreate.Text = "Re-Create";
                                clicks++;
                            }
                            else
                            {
                                RunCommands.runCmd("echo " + textBox2.Text + " > " + textBox4.Text + ".txt", temp);
                                progressBar1.Increment(50);
                                label1.Text = "100%";
                                textBox1.Enabled = false;
                                comboBox1.Enabled = false;
                                textBox2.Enabled = false;
                                textBox4.Enabled = false;
                                btnSelectFile.Enabled = false;
                                btnCreate.Text = "Re-Create";
                                clicks++;
                            }
                        }

                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        if (textBox3.Text.Equals(null) || textBox3.Text.Equals(""))
                        {
                            MessageBox.Show("Please fill in all the fields to continue!");
                        }
                        else
                        {
                            RunCommands.runCmd("mkdir " + textBox3.Text, temp);
                            progressBar1.Increment(50);
                            label1.Text = "100%";
                            textBox1.Enabled = false;
                            comboBox1.Enabled = false;
                            textBox3.Enabled = false;
                            btnSelectFile.Enabled = false;
                            btnCreate.Text = "Re-Create";
                            clicks++;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please select a valid type!");
                    }
                }
            }
            else
            {
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                btnSelectFile.Enabled = true;
                if (comboBox1.SelectedIndex == 0)
                {
                    textBox2.Enabled = true;
                    textBox4.Enabled = true;
                }
                else
                {
                    textBox3.Enabled = true;
                }
                progressBar1.Increment(-100);
                btnCreate.Text = "Create";
                clicks--;
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            RunCommands.runCmd("start .", temp);
        }
    }
}
