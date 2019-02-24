using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Data.SqlClient;
using System.IO;
using BusinessLayer;

namespace KIOSKScreenConfigurator.presentation_layer
{
    public partial class AddButton : Form
    {
        BusinessLayer.Button b  = new BusinessLayer.Button();
        List<Print_ticket_type> myListPrint = new List<Print_ticket_type>();
        List<Confirmation_activity> myListConfirm = new List<Confirmation_activity>();
        List<Request_identification> myListrequest = new List<Request_identification>();

        bool isPrint = false; 

        public AddButton()
        {
            InitializeComponent();
            button_addactivity.Enabled = true;
        }
        /// <summary>
        /// choose defualt value and prepare form 
        /// </summary>
        private void AddButton_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox_idtype.SelectedIndex = 0;
                comboBox_type.SelectedIndex = 0;
                numericUpDown1.Value = 1;
                button_addactivity.Text = "add activity" + " ( " + (myListPrint.Count + myListConfirm.Count + myListrequest.Count)+ " /5 )";
            
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
        /// <summary>
        ///  AddButton as a object to save it later in database 
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {    

          

        }



        /// <summary>
        ///  check selected item 
        /// </summary>
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

        private void AddButton_FormClosed(object sender, FormClosedEventArgs e)
        {
            
             
                

        }
        /// <summary>
        ///  closed from form and check the number of activity 
        /// </summary>

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (myListPrint.Count + myListConfirm.Count + myListrequest.Count == 0)
                {
                    if (MessageBox.Show("please enter 1 activity in minimum or press ok to exit without save  ", "wrong", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        this.Close();
                }
                else
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

        private void textBox_but_order_TextChanged(object sender, EventArgs e)
        {
          
        }
        /// <summary>
        ///  validate the entered order value 
        /// </summary>

        private void textBox_but_order_Leave(object sender, EventArgs e)
        {
            #region input (order text box ) valiadtion 

            try
            {
                int x;
                bool r = int.TryParse(textBox_but_order.Text, out x);
                if (r == false)
                {
                    MessageBox.Show("please enter a valid int number ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_but_order.Focus();

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

        /// <summary>
        ///  save activities  
        /// </summary>

        private void button_addactivity_Click(object sender, EventArgs e)
        {  try
            {
                #region validation 
                if (comboBox_type.SelectedIndex == 0 || comboBox_type.SelectedIndex == 1)
                {

                    if (textBox_Info_msg.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Info_msg.Focus();
                        return;
                    }
                }
                else
                    if (comboBox_type.SelectedIndex == 2)
                {
                    if (textBox_Info_msg.Text == "" || textBox_time_out.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox_Info_msg.Focus();
                        return;
                    }
                }

                #endregion

                if (isPrint)
                {
                    MessageBox.Show("can not add activity after print tickets ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
         

                #region add activities 

                if (myListPrint.Count + myListConfirm.Count + myListrequest.Count < 5)
                {

                   


                    Identification_type ty;

                    if (comboBox_type.SelectedIndex == 0)

                    {
                        string m = textBox_Info_msg.Text;
                        int n = (int)numericUpDown1.Value;
                        Print_ticket_type a = new Print_ticket_type(m, n);
                        myListPrint.Add(a);
                        isPrint = true;
                        button_addactivity.Text = "add activity" + " ( " + (myListPrint.Count + myListConfirm.Count + myListrequest.Count) + " /5 )";
                        MessageBox.Show("activity added ");
                   

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
                        myListrequest.Add(a);

                        button_addactivity.Text = "add activity" + " ( " + (myListPrint.Count + myListConfirm.Count + myListrequest.Count) + " /5 )";
                        MessageBox.Show("activity added ");



                    }
                    else
                        if (comboBox_type.SelectedIndex == 2)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = int.Parse(textBox_time_out.Text);
                        Confirmation_activity a = new Confirmation_activity(m, n);
                        myListConfirm.Add(a);


                        button_addactivity.Text = "add activity" + " ( " + (myListPrint.Count + myListConfirm.Count + myListrequest.Count) + " /5 )";
                        MessageBox.Show("activity added ");



                    }






                }
                else
                {
                    MessageBox.Show("yo can not add more than 5 activity for button ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataGridView_print.DataSource = null;
                dataGridView_print.DataSource = myListPrint;
                dataGridView_Confirm.DataSource = null;
                dataGridView_Confirm.DataSource = myListConfirm;
                dataGridView_Request.DataSource = null;
                dataGridView_Request.DataSource = myListrequest;
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
        /// <summary>
        ///  save all work to the database   
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                #region AddButton 
                BusinessLayer.Button b1 = new BusinessLayer.Button();
                

                if (textBox_but_name.Text == "" || textBox_but_order.Text == "" || textBox_but_txt.Text == "")

                {
                    MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 

                }
              
                    b1.Text = textBox_but_txt.Text;
                    b1.Order = int.Parse(textBox_but_order.Text);
                    b1.ButtonName = textBox_but_name.Text;

               if( b1.AddButton())
                {
                    MessageBox.Show("Button added ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                #endregion

                //HOOOOOOOOON


                #region Get id for current button to add activity to it 

               int bt_id= b1.GetId();


                


                for (int i = 0; i < myListConfirm.Count; i++)
                {

                    myListConfirm[i].AddconActivity(bt_id);
                }


                for(int i=0;i<myListPrint.Count;i++)

                {
                    myListPrint[i].AddPrintActivity(bt_id);
                }
                        
        

                    
                   for (int i=0;i<myListrequest.Count;i++)
                {
                    myListrequest[i].AddRequestActivity(bt_id);
                }

                }
                #endregion
            
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
        /// <summary>
        ///  close the form 
        /// </summary>

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        ///  return choices to th default "clear" 
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox_type.SelectedIndex = 0;
            textBox_Info_msg.Text = "";
            textBox_time_out.Text = "";
            comboBox_idtype.SelectedIndex = 0;
            numericUpDown1.Value = 1;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView_Confirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
