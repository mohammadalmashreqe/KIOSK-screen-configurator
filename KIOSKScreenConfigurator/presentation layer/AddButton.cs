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

        }

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
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(ex.StackTrace);
                sw.Close();


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_but_name.Text == "" || textBox_but_order.Text == "" || textBox_but_txt.Text == "")
                    MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    b.Text = textBox_but_txt.Text;
                    b.Order = int.Parse(textBox_but_order.Text);
                    b.ButtonName = textBox_but_name.Text;
                    MessageBox.Show("button added ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(ex.StackTrace);
                sw.Close();


            }

        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(ex.StackTrace);
                sw.Close();


            }

        }

        private void AddButton_FormClosed(object sender, FormClosedEventArgs e)
        {
            
             
                

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (b.getactivityCount() == 0)
                    if (MessageBox.Show("please enter 1 activity in minimum or press ok to exit without save  ", "wrong", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        this.Close();
            }
            catch(Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(ex.StackTrace);
                sw.Close();
            }
        }

        private void textBox_but_order_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox_but_order_Leave(object sender, EventArgs e)
        {
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
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(ex.StackTrace);
                sw.Close();


            }
        }

        private void button_addactivity_Click(object sender, EventArgs e)
        {  try
            {
                if (comboBox_type.SelectedIndex == 0 || comboBox_type.SelectedIndex == 1)
                {

                    if (textBox_Info_msg.Text == "")
                        MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (comboBox_type.SelectedIndex == 2)

                    if (textBox_Info_msg.Text == "" || textBox_time_out.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                if (b.getactivityCount() <= 5)
                {

                    Identification_type ty;

                    if (comboBox_type.SelectedIndex == 0)

                    {
                        string m = textBox_Info_msg.Text;
                        int n = (int)numericUpDown1.Value;
                        Activity a = new Print_ticket_type(m, n);
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
                        b.addActivity(a);
                        button_addactivity.Text = "add activity" + " ( " + b.getactivityCount() + " /5 )";
                    }
                }
                else
                {
                    MessageBox.Show("yo can not add more than 5 activity for button ");
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(ex.StackTrace);
                sw.Close();


            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.getConInstance();

                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@_name", b.ButtonName);
                p[1] = new SqlParameter("@_text", b.Text);
                p[2] = new SqlParameter("@_order", b.Order);

                dal.myExcute("AddButton", p);

                DataTable dt = dal.SelectData("GetId", p);
                int bt_id = int.Parse(dt.Rows[0][0].ToString());

                // انا هوووون 
                List<Activity> temp = b.getList();
                SqlParameter[] p2 = new SqlParameter[4];


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
                        p2[0] = new SqlParameter("@_but_id", bt_id);
                        p2[1] = new SqlParameter("@_type", "Confirmation_activity");
                        p2[2] = new SqlParameter("@_info_msg", temp[i].Information_message);
                        p2[3] = new SqlParameter("@_timeOutInSec", temp[i].getTimeOutInSecond());
                        dal.myExcute("addConfirmationactivity", p2);

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
            }
            catch(Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt",true);
                sw.WriteLine(ex.StackTrace);
                sw.Close();
                

            }

        }
    }
}
