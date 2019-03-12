using BusinessLayer;
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

namespace KIOSKScreenConfigurator.presentation_layer
{
    public partial class AddActivity : Form
    {
        bool isPrint = false;
        public AddActivity()
        {
            InitializeComponent();
        }

        private void button_addactivity_Click(object sender, EventArgs e)
        {
            try
            {
                #region validation 
                if (comboBox_type.SelectedIndex == 0 || comboBox_type.SelectedIndex == 1)
                {

                    if (textBox_Info_msg.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Info_msg.Focus();
                        return;
                    }
                }
                else
                    if (comboBox_type.SelectedIndex == 2)
                {
                    if (textBox_Info_msg.Text == "" || textBox_time_out.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox_Info_msg.Focus();
                        return;
                    }
                }

                #endregion

                if (isPrint)
                {
                    MessageBox.Show("can not add activity after print tickets ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                #region add activities 

                if (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count < 5)
                {




                    Identification_type ty;

                    if (comboBox_type.SelectedIndex == 0)

                    {
                        string m = textBox_Info_msg.Text;
                        int n = (int)numericUpDown1.Value;
                        Print_ticket_type a = new Print_ticket_type(m, n);
                        Program.myListPrint.Add(a);
                        isPrint = true;
                        button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";


                    }
                    else
                        if (comboBox_type.SelectedIndex == 1)
                    {
                        string m = textBox_Info_msg.Text;
                        if (comboBox_idtype.SelectedIndex == 0)
                            ty = Identification_type.card;
                        else
                            ty = Identification_type.mobile;

                        bool ismand;
                        if (checkBox1.Checked)
                            ismand = true;

                        else
                            ismand = true;

                        Request_identification a = new Request_identification(m, ty, ismand);
                        Program.myListrequest.Add(a);

                        button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";



                    }
                    else
                        if (comboBox_type.SelectedIndex == 2)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = int.Parse(textBox_time_out.Text);
                        Confirmation_activity a = new Confirmation_activity(m, n);
                        Program.myListConfirm.Add(a);


                        button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";



                    }






                }
                else
                {
                    MessageBox.Show("yo can not add more than 5 activity for button ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataGridView_print.DataSource = null;
                dataGridView_print.DataSource =Program. myListPrint;
                dataGridView_Confirm.DataSource = null;
                dataGridView_Confirm.DataSource = Program.myListConfirm;
                dataGridView_Request.DataSource = null;
                dataGridView_Request.DataSource = Program.myListrequest;
                textBox_Info_msg.Text = "";
                textBox_time_out.Text = "";
                numericUpDown1.Value = 1;
                
            }
            catch (Exception ex)
            {
                #region Format excepton and write details to the log file 
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                #endregion


            }
            #endregion
        }

        private void AddActivity_Load(object sender, EventArgs e)
        {
            try
            {
                Program.myListConfirm.Clear();
                Program.myListPrint.Clear();
                Program.myListrequest.Clear();
                comboBox_idtype.SelectedIndex = 0;
                comboBox_type.SelectedIndex = 0;
                numericUpDown1.Value = 1;
                button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";

            }
            catch (Exception ex)
            {
                #region Format excepton and write details to the log file 
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                #endregion

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Program.myListConfirm.Clear();
                Program.myListPrint.Clear();
                Program.myListrequest.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                #region Format excepton and write details to the log file 
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                #endregion
            }
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region check selected item 
            try
            {
                if (comboBox_type.SelectedIndex == 0)
                {
                    groupBox_printtickType.Visible = true;
                    groupBox_requestident.Visible = false;
                    groupBox_confirm.Visible = false;
                }


                else
                    if (comboBox_type.SelectedIndex == 1)
                {
                    groupBox_requestident.Visible = true;
                    groupBox_printtickType.Visible = false;
                    groupBox_confirm.Visible = false;

                }
                else
                {
                    groupBox_confirm.Visible = true;
                    groupBox_printtickType.Visible = false;
                    groupBox_requestident.Visible = false;
                }
            }
            catch (Exception ex)
            {
                #region Format excepton and write details to the log file 
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                #endregion


            }
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox_type.SelectedIndex = 0;
                textBox_Info_msg.Text = "";
                textBox_time_out.Text = "";
                comboBox_idtype.SelectedIndex = 0;
                numericUpDown1.Value = 1;
            }
            catch (Exception ex)
            {
                #region Format excepton and write details to the log file 
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : ");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.Message);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("stack trace :");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------------------------------");
                sw.WriteLine("");
                sw.WriteLine("");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                #endregion
            }
        }

        private void AddActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}
