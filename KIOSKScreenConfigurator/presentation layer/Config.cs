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

        /// <summary>
        /// test the connection string by calling TestCon from DataAccessLayer .
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            #region get and prepare connection string 
            string con = string.Format("Data Source = {0};Initial Catalog={1};;Integrated Security=True", textBox_server.Text, textBox_DBName.Text);
            #endregion

            #region test a connection 
            try
            {
                if (DAL.DataAccessLayer.TestCon(con))
                {
                    MessageBox.Show(" test connection succeeded", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// change the connection string by calling changeConnectioString from DataAccessLayer .
        /// </summary>

        private void button2_Click(object sender, EventArgs e)
        {
            #region get and prepare connection string
            string con = string.Format("Data Source = {0};Initial Catalog={1};;Integrated Security=True", textBox_server.Text, textBox_DBName.Text);
            #endregion
            #region change a connection 
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
    }
}
