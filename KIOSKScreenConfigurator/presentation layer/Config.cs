﻿using KIOSKScreenConfigurator.business_Layer;
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
            textBox_DBName.Text = Myconfig.Database_name;
            textBox_server.Text = Myconfig.Server_name;
        }

        /// <summary>
        /// test the connection string by calling TestCon from DataAccessLayer .
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            #region get and prepare connection string 
            string con = string.Format("Data Source = {0};Initial Catalog={1};;Integrated Security=True", textBox_server.Text, textBox_DBName.Text);
            #endregion

            if(Myconfig.TestCon(con))
                {
                 MessageBox.Show(" Test connection succeeded", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                {
                    Myconfig.Database_name = textBox_DBName.Text;
                    Myconfig.Server_name = textBox_server.Text;
                }
                 }
            else
            {
                MessageBox.Show(" Invalid connection String  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

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
        if(Myconfig.changeCon(con))
            {
                Myconfig.Database_name = textBox_DBName.Text;
                Myconfig.Server_name = textBox_server.Text;
                this.Hide();
                Form1 frm = new Form1();
                frm.Show();
            }
        else
            {
                MessageBox.Show(" Invalid connection String  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
