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
using KIOSKScreenConfigurator.presentation_layer;
using System.IO;

namespace KIOSKScreenConfigurator
{
    public partial class Form1 : Form
    {
      DataAccessLayer dal;
        public Form1()
        {
            
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\LogFile.txt"))
            {
               
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt",true);
                sw.Write("");
                sw.Close();

              
            }
             dal = DataAccessLayer.getConInstance();
           InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dal.Open();
                DataTable dt = dal.SelectData("getButtons", null);

                dataGridView_buttonList.DataSource = null;
                dataGridView_buttonList.DataSource = dt;
                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {
                    SqlParameter[] p = new SqlParameter[1];
                    int val = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                    p[0] = new SqlParameter("@_id", val);

                    dt = dal.SelectData("getActivity", p);

                    dataGridView_activity.DataSource = null;

                    dataGridView_activity.DataSource = dt;
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


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        



               
            

        }

        private void dataGridView_buttonList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_buttonList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {


                    SqlParameter[] p = new SqlParameter[1];
                    int val = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                    p[0] = new SqlParameter("@_id", val);
                    DataTable dt = dal.SelectData("getActivity", p);

                    dataGridView_activity.DataSource = null;

                    dataGridView_activity.DataSource = dt;


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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult response = MessageBox.Show("Are you sure?", "Delete row?",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button2);

                if (response != DialogResult.No)


                {

                    SqlParameter[] p = new SqlParameter[1];
                    int val = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                    p[0] = new SqlParameter("@_id", val);
                    dal.myExcute("deleteButton", p);

                    DataTable dt = dal.SelectData("getButtons", null);
                    dataGridView_buttonList.DataSource = null;

                    dataGridView_buttonList.DataSource = dt;
                    dataGridView_buttonList.Refresh();
                    if (dataGridView_buttonList.SelectedCells.Count > 0)
                    {
                        SqlParameter[] p2 = new SqlParameter[1];
                        int val2 = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                        p2[0] = new SqlParameter("@_id", val2);
                        DataTable dt2 = dal.SelectData("getActivity", p2);

                        dataGridView_activity.DataSource = null;

                        dataGridView_activity.DataSource = dt2;
                    }


                    if (dataGridView_buttonList.SelectedCells.Count == 0)

                        dataGridView_activity.DataSource = null;
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

        }
        /// <summary>
        ///  open add button form 
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            #region open form 
            try
            {

                AddButton frm = new AddButton();
                frm.ShowDialog();
                #endregion

                #region updae List in main form 
                // this code will be execute when addButton frm closed .


                DataTable dt = dal.SelectData("getButtons", null);

                dataGridView_buttonList.DataSource = null;
                dataGridView_buttonList.DataSource = dt;

                SqlParameter[] p = new SqlParameter[1];
                int val = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                p[0] = new SqlParameter("@_id", val);

                dt = dal.SelectData("getActivity", p);

                dataGridView_activity.DataSource = null;

                dataGridView_activity.DataSource = dt;
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
        ///  open Edit button form  and passed the selected button to the form constructer as a parameter 
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                #region create a selected button 
                Button b = new Button();
                b.ButtonName = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString();
                b.Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString());
                b.ID1 = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                b.Text = dataGridView_buttonList.CurrentRow.Cells["text"].Value.ToString();
                #endregion

                #region create object from form Edit form , display it and passed selected obejct as a paramter  
                EditFrm frm = new EditFrm(b);
                frm.ShowDialog();
                #endregion

                #region update list in main Form 
                DataTable dt = dal.SelectData("getButtons", null);

                dataGridView_buttonList.DataSource = null;
                dataGridView_buttonList.DataSource = dt;
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
        ///  close all forms and end all proccess 
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// display configration form to modfiy connection string ana test connection 
        /// </summary>
        private void changeConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Config frm = new Config();
            frm.Show();
        }
        /// <summary>
        /// close all forms and end all proccess 
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
