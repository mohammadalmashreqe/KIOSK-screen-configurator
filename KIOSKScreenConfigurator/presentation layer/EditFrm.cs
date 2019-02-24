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
    public partial class EditFrm : Form
    {
        Button current;
       
        
     
        public EditFrm(Button b)
        {
             current =b;

            InitializeComponent();
        }

        private void EditFrm_Load(object sender, EventArgs e)
        {
            textBox_id.Text = current.ID1+"";
            textBox_name.Text = current.ButtonName;
            textBox_order.Text = current.Order+"";
            textBox_text.Text = current.Text;
            int val = int.Parse(textBox_id.Text);
            tabControl1.SelectedIndex = 0;
            loadDataGrid(val);

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                if (current.updatButton())
                {
                    MessageBox.Show("button updated ", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("no row effected", "wraning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
         

        }

        private void textBox_name_Leave(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length == 0)
            {
                MessageBox.Show("please fill all fields ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_name.Focus();
                

            }
           
        }

        private void textBox_text_Leave(object sender, EventArgs e)
        {
            if (textBox_text.Text.Length == 0)
            {
                MessageBox.Show("please fill all fields ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_text.Focus();
            }
            
        }

        private void textBox_order_Leave(object sender, EventArgs e)
        {
            int IntOrder;
            if (textBox_order.Text.Length == 0)
            {
                MessageBox.Show("please fill all fields ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_order.Focus();

            }
            else if (!int.TryParse(textBox_order.Text, out IntOrder))
            {
                MessageBox.Show("please enter a valid int order ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_order.Focus();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {



           // Edit_Activity frm;
            
           //if (tabControl1.SelectedIndex == 0)
           // {
           //     if (dataGridView_print.Rows.Count > 0)
           //     {
           //     int n=  int.Parse(  dataGridView_print.CurrentRow.Cells["num_of_tick"].Value.ToString());
           //       string m=  dataGridView_print.CurrentRow.Cells["info_msg"].Value.ToString();
           //        int i=  int .Parse(dataGridView_print.CurrentRow.Cells["ID"].Value.ToString());
           //         Print_ticket_type a = new Print_ticket_type(m, n);
           //         frm = new Edit_Activity(a, i);
           //         frm.ShowDialog();
           //         loadDataGrid(i);


           //     }
           // }
           //else 
           //     if (tabControl1.SelectedIndex==1)
           // {
           //     if(dataGridView_Request.Rows.Count>0)
           //     {
           //         Identification_type idt2;
           //       string idt=  dataGridView_Request.CurrentRow.Cells["Identification_type"].Value.ToString();
           //         if (idt == "card")
           //         {  idt2 = Identification_type.card;
           //         }

           //         else
           //         {  idt2 = Identification_type.mobile;
           //         }
           //         bool ismandotory = bool.Parse(dataGridView_Request.CurrentRow.Cells["Is_mandatory"].Value.ToString());
           //         string m = dataGridView_Request.CurrentRow.Cells["info_msg"].Value.ToString();
           //         Request_identification a = new Request_identification(m, idt2, ismandotory);
           //         int i = int.Parse(dataGridView_Request.CurrentRow.Cells["ID"].Value.ToString());
           //         frm = new Edit_Activity(a, i);
           //         frm.ShowDialog();
           //         loadDataGrid(i);

           //     }
           // }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex==0 )
            {
                
                string act_id = dataGridView_print.CurrentRow.Cells["ID"].Value.ToString();
                string i = textBox_id.Text;
                if (Print_ticket_type.deleteActivity(act_id))
                    MessageBox.Show("Activity Deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error cant delete thae activity try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



                loadDataGrid(int.Parse(i));

            }
            else
                if(tabControl1.SelectedIndex==1)
            {
                string act_id = dataGridView_Request.CurrentRow.Cells["ID"].Value.ToString();
                string i = textBox_id.Text;
                if(Request_identification.deleteActivity(act_id))
                    MessageBox.Show("Activity Deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error cant delete thae activity try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                loadDataGrid(int.Parse(i));



            }
            else
            {
                string act_id = dataGridView_Confirm.CurrentRow.Cells["ID"].Value.ToString();
                string i = textBox_id.Text;
                if (Request_identification.deleteActivity(act_id))
                    MessageBox.Show("Activity Deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error cant delete thae activity try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                loadDataGrid(int.Parse(i));
            }


        }



        public void loadDataGrid ( int i )
        {
            dataGridView_print.DataSource = null;
            dataGridView_Confirm.DataSource = null;
            dataGridView_Request.DataSource = null;

            dataGridView_Confirm.DataSource = Confirmation_activity.getConActivity(i);
            dataGridView_print.DataSource = Print_ticket_type.getPrintActivity(i);
            dataGridView_Request.DataSource = Request_identification.getRequestActivity(i);
        }
    }
}
