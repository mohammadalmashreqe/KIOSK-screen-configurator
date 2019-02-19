using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KIOSKScreenConfigurator.DAL;
using System.Data.SqlClient;
using System.IO;


namespace KIOSKScreenConfigurator.presentation_layer
{
    public partial class AddButton : Form
    {
        Button b = new Button();
        public AddButton()
        {
            InitializeComponent();
            button_addactivity.Enabled = false; 
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
                button_addactivity.Text = "add activity" + " ( " + b.getactivityCount() + " /5 )";
                radioButton_yes.Checked = true;
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

            #region AddButton 
            try
            { 
                if (textBox_but_name.Text == "" || textBox_but_order.Text == "" || textBox_but_txt.Text == "")
                    MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    b.Text = textBox_but_txt.Text;
                    b.Order = int.Parse(textBox_but_order.Text);
                    b.ButtonName = textBox_but_name.Text;
                    MessageBox.Show("button added click save to save it in database   ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_addactivity.Enabled = true; 
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
                if (b.getactivityCount() == 0)
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



                #region add activities 
                List<Activity> temp = b.getList();
                if (b.getactivityCount() <= 5)
                {

                    if (temp.Count >0 && temp[temp.Count-1].getType()==activityType.print_ticket_type )

                    {
                        MessageBox.Show("yo can not add  activity after print teckits ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Identification_type ty;

                        if (comboBox_type.SelectedIndex == 0)

                        {
                            string m = textBox_Info_msg.Text;
                            int n = (int)numericUpDown1.Value;
                            Activity a = new Print_ticket_type(m, n);
                            if (b.addActivity(a))
                            {
                                button_addactivity.Text = "add activity" + " ( " + b.getactivityCount() + " /5 )";
                                MessageBox.Show("activity added ");
                            }
                            else
                                MessageBox.Show("activity not added ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if (radioButton_no.Checked)
                                ismand = false;

                            else
                                ismand = true;

                            Activity a = new Request_identification(m, ty, ismand);
                            if (b.addActivity(a))
                            {
                                button_addactivity.Text = "add activity" + " ( " + b.getactivityCount() + " /5 )";
                                MessageBox.Show("activity added ");
                            }
                            else
                                MessageBox.Show("activity not added ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                        else 
                            if(comboBox_type.SelectedIndex == 2)
                        {
                            string m = textBox_Info_msg.Text;
                            int n = int .Parse(textBox_time_out.Text);
                            Activity a = new Confirmation_activity(m, n);
                            if (b.addActivity(a))
                            {
                                button_addactivity.Text = "add activity" + " ( " + b.getactivityCount() + " /5 )";
                                MessageBox.Show("activity added ");
                            }
                            else
                                MessageBox.Show("activity not added ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }





                    }
                }
                else
                {
                    MessageBox.Show("yo can not add more than 5 activity for button ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///  save all work to the database   
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                #region open database 
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();
                #endregion
                #region put the stored procedure paramters 
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@_name", b.ButtonName);
                p[1] = new SqlParameter("@_text", b.Text);
                p[2] = new SqlParameter("@_order", b.Order);
                #endregion

                #region add button to database 

                if (dal.myExcute("AddButton", p))
                    MessageBox.Show("button saved to database");

                #endregion

                #region Get id for current button to add activity to it 

                SqlParameter[] p5 = new SqlParameter[3];
                p5[0] = new SqlParameter("@_name", b.ButtonName);
                p5[1] = new SqlParameter("@_text", b.Text);
                p5[2] = new SqlParameter("@_order", b.Order);
                DataTable dt = dal.SelectData("GetId", p5);
                int bt_id = dt.Rows[0].Field<int>(0);
               
                

                List<Activity> temp = b.getList();
                SqlParameter[] p2 = new SqlParameter[4];
                SqlParameter[] p4 = new SqlParameter[4];

                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].getType() == activityType.print_ticket_type)
                    {
                        p2[0] = new SqlParameter("@_but_id", bt_id);
                        p2[1] = new SqlParameter("@_type", "print_ticket_type");
                        p2[2] = new SqlParameter("@_info_msg", temp[i].Information_message);
                        p2[3] = new SqlParameter("@_numofprintedTick", temp[i].getnumberOfprintedTick());
                        dal.myExcute("AddPrint_ticket_type", p2);
                        
                       
                    }
                    else
                        if (temp[i].getType() == activityType.Confirmation_activity)
                    {
                        p4[0] = new SqlParameter("@_but_id", bt_id);
                        p4[1] = new SqlParameter("@_type", "Confirmation_activity");
                        p4[2] = new SqlParameter("@_info_msg", temp[i].Information_message);
                        p4[3] = new SqlParameter("@_timeOutInSec", temp[i].getTimeOutInSecond());
                        dal.myExcute("addConfirmationactivity", p4);
                        



                    }
                    else
                    {
                        SqlParameter[] p3 = new SqlParameter[5];

                        p3[0] = new SqlParameter("@_but_id", bt_id);
                        p3[1] = new SqlParameter("@_type", "Request_identification");
                        p3[2] = new SqlParameter("@_info_msg", temp[i].Information_message);
                        p3[3] = new SqlParameter("@_IdentificationType", temp[i].getIdentificationType());

                        p3[4] = new SqlParameter("@_ismandatory", temp[i].getIsmandatory());
                        dal.myExcute("Request_identification", p3);
                            


                    }

                }
                #endregion
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
    }
}
