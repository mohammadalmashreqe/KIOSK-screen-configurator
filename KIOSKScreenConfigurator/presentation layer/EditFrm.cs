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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessLayer dal = DataAccessLayer.getConInstance();
                dal.Open();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@_id", textBox_id.Text);
                p[1] = new SqlParameter("@_name", textBox_name.Text);

                p[2] = new SqlParameter("@_text", textBox_text.Text);

                p[3] = new SqlParameter("@_order", textBox_order.Text);

                if (dal.myExcute("EditButton", p))
                {
                    MessageBox.Show("button updated ", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("no row effected","wraning",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
                dal.Close();

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
    }
}
