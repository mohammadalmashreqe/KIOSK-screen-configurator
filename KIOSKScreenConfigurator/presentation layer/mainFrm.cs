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
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


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
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                AddButton frm = new AddButton();
                frm.ShowDialog();

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
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("message : \n\n" + ex.Message);
                sw.WriteLine("------------------------------------\n\n");
                sw.WriteLine("stack trace : \n\n" + ex.StackTrace + "\n\n");

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for mor info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt");
                sw.Close();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Button b = new Button();
            b.ButtonName =dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString();
            b.Order=int .Parse( dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString());
            b.ID1= int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
            b.Text = dataGridView_buttonList.CurrentRow.Cells["text"].Value.ToString();
            EditFrm frm = new EditFrm(b);
            frm.ShowDialog();
            DataTable dt = dal.SelectData("getButtons", null);

            dataGridView_buttonList.DataSource = null;
            dataGridView_buttonList.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config frm = new Config();
            frm.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
