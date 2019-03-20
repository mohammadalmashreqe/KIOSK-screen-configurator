﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using Button = BusinessLayer.Button;

namespace KIOSKScreenConfigurator.presentation_layer
{
    /// <summary>
    /// Defines the <see cref="Form1" />
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            try
            {

                if (!File.Exists(Directory.GetCurrentDirectory() + @"\LogFile.txt"))
                {

                    StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogFile.txt", true);
                    sw.Write("");
                    sw.Close();


                }
                DataAccessLayer.GetConInstance();
                InitializeComponent();
            }
            catch (Exception ex)
            {

                ErrorLogger.ErrorLog((ex));
                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The Form1_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               

                dataGridView_buttonList.DataSource = null;

                dataGridView_buttonList.DataSource = Button.GetButtons();

                dataGridView_buttonList.Columns["name"].HeaderText = "Name";
                dataGridView_buttonList.Columns["order"].HeaderText = "Order";

                listView1.Items.Clear();
                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {

                    Button temp = new Button
                    {
                        Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                        Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString())
                    };
                    temp.Id = temp.GetId();
                    dataGridView_buttonList.Columns[0].Visible = false;
                    int val = temp.Id;

                    foreach (DataRow x in ConfirmationActivity.GetConfirmationActivity(val).Rows)
                    {

                       
                        string[] row = { x["info_msg"].ToString(), x["type"].ToString(),x["ID"].ToString() };
                        ListViewItem l = new ListViewItem(row);
                        listView1.Items.Add(l);
                    }

                    foreach (DataRow x in PrintTicketType.GetPrintActivity(val).Rows)
                    {
                        string[] row = { x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString() };
                        ListViewItem l = new ListViewItem(row);
                        listView1.Items.Add(l);
                    }
                    foreach (DataRow x in RequestIdentification.GetRequestActivity(val).Rows)
                    {
                        
                        string[] row = { x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString() };
                        ListViewItem l = new ListViewItem(row);
                        listView1.Items.Add(l);
                    }






                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        /// <summary>
        /// The groupBox1_Enter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The dataGridView1_UserDeletingRow
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewRowCancelEventArgs"/></param>
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        }

        /// <summary>
        /// The dataGridView_buttonList_CellContentClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void dataGridView_buttonList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// The dataGridView_buttonList_SelectionChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void dataGridView_buttonList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {
                    Button temp = new Button
                    {
                        Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                        Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString())
                    };
                    temp.Id = temp.GetId();

                    int val = temp.Id;

                    foreach (DataRow x in ConfirmationActivity.GetConfirmationActivity(val).Rows)
                    {




                        string[] row = { x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString() };
                        ListViewItem l = new ListViewItem(row);
                        listView1.Items.Add(l);
                    }

                    foreach (DataRow x in PrintTicketType.GetPrintActivity(val).Rows)
                    {


                        string[] row = { x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString() };
                        ListViewItem l = new ListViewItem(row);
                        listView1.Items.Add(l);
                    }

                    foreach (DataRow x in RequestIdentification.GetRequestActivity(val).Rows)
                    {



                        string[] row = { x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString() };
                        ListViewItem l = new ListViewItem(row);
                        listView1.Items.Add(l);
                    }

                }





            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        /// <summary>
        /// The button1_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult response = MessageBox.Show("Are you sure delete selected button ?", "Delete Button",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button2);

                if (response != DialogResult.No)


                {
                    Button b1 = new Button
                    {
                        Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                        Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString())
                    };



                    b1.Id = b1.GetId();
                    if (!b1.DeleteButton())

                        MessageBox.Show("Button not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dataGridView_buttonList.DataSource = null;
                    dataGridView_buttonList.DataSource = Button.GetButtons();

                    dataGridView_buttonList.Columns["name"].HeaderText = "Name";
                    dataGridView_buttonList.Columns["order"].HeaderText = "Order";

                    if (dataGridView_buttonList.SelectedCells.Count > 0)
                    {
                        Button temp = new Button
                        {
                            Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                            Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString())
                        };
                        temp.Id = temp.GetId();
                        dataGridView_buttonList.Columns["id"].Visible = false;

                        int val = temp.Id;
                        listView1.Items.Clear();
                        foreach (DataRow x in ConfirmationActivity.GetConfirmationActivity(val).Rows)
                        {



                            string[] row = { x["info_msg"].ToString(), x["type"].ToString() };
                            ListViewItem l = new ListViewItem(row);
                            listView1.Items.Add(l);
                        }

                        foreach (DataRow x in PrintTicketType.GetPrintActivity(val).Rows)
                        {

                            string[] row = { x["info_msg"].ToString(), x["type"].ToString() };
                            ListViewItem l = new ListViewItem(row);
                            listView1.Items.Add(l);
                        }

                        foreach (DataRow x in RequestIdentification.GetRequestActivity(val).Rows)
                        {


                            string[] row = { x["info_msg"].ToString(), x["type"].ToString() };
                            ListViewItem l = new ListViewItem(row);
                            listView1.Items.Add(l);
                        }



                    }


                    if (dataGridView_buttonList.SelectedCells.Count == 0)

                    {
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        /// <summary>
        /// open add button form
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                ButtonAttributes frm = new ButtonAttributes(null) {Text = "Add Button"};
                frm.ShowDialog();

                // this code will be execute when addButton frm closed .


                dataGridView_buttonList.DataSource = null;
                dataGridView_buttonList.DataSource = Button.GetButtons();


                dataGridView_buttonList.Columns["name"].HeaderText = "Name";

                dataGridView_buttonList.Columns["order"].HeaderText = "Order";


                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {
                    listView1.Items.Clear();


                    {
                        Button temp = new Button
                        {
                            Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                            Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString())
                        };
                        temp.Id = temp.GetId();
                        dataGridView_buttonList.Columns["id"].Visible = false;

                        int val = temp.Id;
                        listView1.Items.Clear();
                        foreach (DataRow x in ConfirmationActivity.GetConfirmationActivity(val).Rows)
                        {



                            string[] row = { x["info_msg"].ToString(), x["type"].ToString() };
                            ListViewItem l = new ListViewItem(row);
                            listView1.Items.Add(l);
                        }

                        foreach (DataRow x in PrintTicketType.GetPrintActivity(val).Rows)
                        {

                            string[] row = { x["info_msg"].ToString(), x["type"].ToString() };
                            ListViewItem l = new ListViewItem(row);
                            listView1.Items.Add(l);
                        }

                        foreach (DataRow x in RequestIdentification.GetRequestActivity(val).Rows)
                        {


                            string[] row = { x["info_msg"].ToString(), x["type"].ToString() };
                            ListViewItem l = new ListViewItem(row);
                            listView1.Items.Add(l);
                        }



                    }




                }


                if (dataGridView_buttonList.SelectedCells.Count == 0)

                {
                }


            }
            catch (Exception ex)
            {

                ErrorLogger.ErrorLog(ex);

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        /// <summary>
        /// open Edit button form  and passed the selected button to the form constructor as a parameter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_buttonList.CurrentRow != null)
                {


                    Button b = new Button
                    {
                        Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                        Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString())
                        


                    };
                    b.Id = b.GetId();

                    ButtonAttributes frm = new ButtonAttributes(b) {Text = "Edit Button"};
                    frm.ShowDialog();

                    if (dataGridView_buttonList.SelectedCells.Count > 0)
                    {
                        listView1.Items.Clear();


                        {
                            Button temp = new Button
                            {
                                Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                                Order = int.Parse(
                                    dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString())
                            };
                            temp.Id = temp.GetId();
                            dataGridView_buttonList.Columns["id"].Visible = false;

                            int val = temp.Id;
                            listView1.Items.Clear();
                            foreach (DataRow x in ConfirmationActivity.GetConfirmationActivity(val).Rows)
                            {



                                string[] row = {x["info_msg"].ToString(), x["type"].ToString()};
                                ListViewItem l = new ListViewItem(row);
                                listView1.Items.Add(l);
                            }

                            foreach (DataRow x in PrintTicketType.GetPrintActivity(val).Rows)
                            {

                                string[] row = {x["info_msg"].ToString(), x["type"].ToString()};
                                ListViewItem l = new ListViewItem(row);
                                listView1.Items.Add(l);
                            }

                            foreach (DataRow x in RequestIdentification.GetRequestActivity(val).Rows)
                            {


                                string[] row = {x["info_msg"].ToString(), x["type"].ToString()};
                                ListViewItem l = new ListViewItem(row);
                                listView1.Items.Add(l);
                            }



                        }




                    }


                }
                else
                    MessageBox.Show("Please select item from list", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);


                #region MyRegion



                dataGridView_buttonList.DataSource = null;
                dataGridView_buttonList.DataSource = Button.GetButtons();
                dataGridView_buttonList.Columns["id"].Visible = false;
                dataGridView_buttonList.Columns["name"].HeaderText = "Name";
                dataGridView_buttonList.Columns["order"].HeaderText = "Order";
                #endregion
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// close all forms and end all process
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once UnusedParameter.Local
        private void button4_Click(object sender)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// display configuration form to modify connection string ana test connection
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void changeConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                Config frm = new Config();
                frm.Show();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// close all forms and end all process
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The button4_Click_1
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("Exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView_buttonList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {

        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }
    }
}
