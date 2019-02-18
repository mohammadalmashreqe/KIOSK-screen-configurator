using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIOSKScreenConfigurator.presentation_layer
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = string.Format("Data Source = {0};Initial Catalog={1};;Integrated Security=True", textBox_server.Text, textBox_DBName.Text);
            try
            {
                if (DAL.DataAccessLayer.TestCon(con))
                {
                    MessageBox.Show(" test connection succeeded", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string con = string.Format("Data Source = {0};Initial Catalog={1};;Integrated Security=True", textBox_server.Text, textBox_DBName.Text);
            try
            {
                if (DAL.DataAccessLayer.changeConnectioString(con))
                {
                    MessageBox.Show(" test connection succeeded", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\FIrstTimeCheck.txt");
                    sw.Write("F");
                    sw.Close();
                    
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.Show();
                    DAL.DataAccessLayer.getConInstance();
                       
                }

            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


            }
        }
    }
}
