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

namespace KIOSKScreenConfigurator
{
    public partial class Form1 : Form
    {
        DataAccessLayer dal = DataAccessLayer.getConInstance();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dal.Open();

           DataTable dt= dal.SelectData("getButtons",null);

            dataGridView_buttonList.DataSource = null; 
            dataGridView_buttonList.DataSource = dt;

            SqlParameter[] p = new SqlParameter[1];
            int val =int .Parse( dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
            p[0] = new SqlParameter("@_id", val);

            dt = dal.SelectData("getActivity", p);

            dataGridView_activity.DataSource = null;

            dataGridView_activity.DataSource = dt;


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

        private void button1_Click(object sender, EventArgs e)
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
            }

        }
    }
}
