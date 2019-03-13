using System;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;

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
                dataGridView_buttonList.DataSource = BusinessLayer.Button.GetButtons();
                dataGridView_buttonList.Columns["id"].HeaderText = "ID";
                dataGridView_buttonList.Columns["name"].HeaderText = "Name";
                dataGridView_buttonList.Columns["text"].HeaderText = "Text";
                dataGridView_buttonList.Columns["order"].HeaderText = "Order";

                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {

                    int val = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                    dataGridView_print.DataSource = null;
                    dataGridView_Confirm.DataSource = null;
                    dataGridView_Request.DataSource = null;

                    dataGridView_Confirm.DataSource = ConfirmationActivity.GetConfirmationActivity(val);

                    dataGridView_Confirm.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_Confirm.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_Confirm.Columns["type"].HeaderText = "Type";
                    dataGridView_Confirm.Columns["timeOutInSec"].HeaderText = "Time out"; 





                    dataGridView_print.DataSource = PrintTicketType.GetPrintActivity(val);

                    dataGridView_print.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_print.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_print.Columns["type"].HeaderText = "Type";
                    dataGridView_print.Columns["num_of_tick"].HeaderText = "Number of tickets";
                

                    dataGridView_Request.DataSource = RequestIdentification.GetRequestActivity(val);
                    dataGridView_Request.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_Request.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_Request.Columns["type"].HeaderText = "Type";
                    dataGridView_Request.Columns["Identification_type"].HeaderText = "Identification type";
                    dataGridView_Request.Columns["Is_mandatory"].HeaderText = "Is mandatory ";

                }
            }
            catch (Exception ex)
            {
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
                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {

                    int val = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());

                    dataGridView_print.DataSource = null;
                    dataGridView_Confirm.DataSource = null;
                    dataGridView_Request.DataSource = null;

                    dataGridView_Confirm.DataSource = ConfirmationActivity.GetConfirmationActivity(val);
                    dataGridView_Confirm.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_Confirm.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_Confirm.Columns["type"].HeaderText = "Type";
                    dataGridView_Confirm.Columns["timeOutInSec"].HeaderText = "Time out";

                    dataGridView_print.DataSource = PrintTicketType.GetPrintActivity(val);
                    dataGridView_print.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_print.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_print.Columns["type"].HeaderText = "Type";
                    dataGridView_print.Columns["num_of_tick"].HeaderText = "Number of tickets";
                    dataGridView_Request.DataSource = RequestIdentification.GetRequestActivity(val);
                    dataGridView_Request.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_Request.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_Request.Columns["type"].HeaderText = "Type";
                    dataGridView_Request.Columns["Identification_type"].HeaderText = "Identification type";
                    dataGridView_Request.Columns["Is_mandatory"].HeaderText = "Is mandatory ";

                }
            }
            catch (Exception ex)
            {
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
                    BusinessLayer.Button b1 = new BusinessLayer.Button();



                    int val = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());
                    b1.Id = val;
                    if (!b1.DeleteButton())

                        MessageBox.Show("Button not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dataGridView_buttonList.DataSource = null;
                    dataGridView_buttonList.DataSource = BusinessLayer.Button.GetButtons();

                    dataGridView_buttonList.Columns["id"].HeaderText = "ID";
                    dataGridView_buttonList.Columns["name"].HeaderText = "Name";
                    dataGridView_buttonList.Columns["text"].HeaderText = "Text";
                    dataGridView_buttonList.Columns["order"].HeaderText = "Order";
                    
                    if (dataGridView_buttonList.SelectedCells.Count > 0)
                    {


                        int val2 = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());

                        dataGridView_print.DataSource = null;
                        dataGridView_Confirm.DataSource = null;
                        dataGridView_Request.DataSource = null;

                        dataGridView_Confirm.DataSource = ConfirmationActivity.GetConfirmationActivity(val2);
                        dataGridView_Confirm.Columns["info_msg"].HeaderText = "Message";
                        dataGridView_Confirm.Columns["but_id"].HeaderText = "Button ID";
                        dataGridView_Confirm.Columns["type"].HeaderText = "Type";
                        dataGridView_Confirm.Columns["timeOutInSec"].HeaderText = "Time out";

                        dataGridView_print.DataSource = PrintTicketType.GetPrintActivity(val2);
                        dataGridView_print.Columns["info_msg"].HeaderText = "Message";
                        dataGridView_print.Columns["but_id"].HeaderText = "Button ID";
                        dataGridView_print.Columns["type"].HeaderText = "Type";
                        dataGridView_print.Columns["num_of_tick"].HeaderText = "Number of tickets";
                        dataGridView_Request.DataSource = RequestIdentification.GetRequestActivity(val2);
                        dataGridView_Request.Columns["info_msg"].HeaderText = "Message";
                        dataGridView_Request.Columns["but_id"].HeaderText = "Button ID";
                        dataGridView_Request.Columns["type"].HeaderText = "Type";
                        dataGridView_Request.Columns["Identification_type"].HeaderText = "Identification type";
                        dataGridView_Request.Columns["Is_mandatory"].HeaderText = "Is mandatory ";



                    }


                    if (dataGridView_buttonList.SelectedCells.Count == 0)

                    {
                        dataGridView_print.DataSource = null;
                        dataGridView_Confirm.DataSource = null;
                        dataGridView_Request.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
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

                AddButton frm = new AddButton();
                frm.ShowDialog();

                // this code will be execute when addButton frm closed .


                dataGridView_buttonList.DataSource = null;
                dataGridView_buttonList.DataSource = BusinessLayer.Button.GetButtons();

                dataGridView_buttonList.Columns["id"].HeaderText = "ID";
                dataGridView_buttonList.Columns["name"].HeaderText = "Name";
                dataGridView_buttonList.Columns["text"].HeaderText = "Text";
                dataGridView_buttonList.Columns["order"].HeaderText = "Order";


                if (dataGridView_buttonList.SelectedCells.Count > 0)
                {


                    int val2 = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString());

                    dataGridView_print.DataSource = null;
                    dataGridView_Confirm.DataSource = null;
                    dataGridView_Request.DataSource = null;

                    dataGridView_Confirm.DataSource = ConfirmationActivity.GetConfirmationActivity(val2);
                    dataGridView_Confirm.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_Confirm.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_Confirm.Columns["type"].HeaderText = "Type";
                    dataGridView_Confirm.Columns["timeOutInSec"].HeaderText = "Time out";


                    dataGridView_print.DataSource = PrintTicketType.GetPrintActivity(val2);
                    dataGridView_print.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_print.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_print.Columns["type"].HeaderText = "Type";
                    dataGridView_print.Columns["num_of_tick"].HeaderText = "Number of tickets";


                    dataGridView_Request.DataSource = RequestIdentification.GetRequestActivity(val2);
                    dataGridView_Request.Columns["info_msg"].HeaderText = "Message";
                    dataGridView_Request.Columns["but_id"].HeaderText = "Button ID";
                    dataGridView_Request.Columns["type"].HeaderText = "Type";
                    dataGridView_Request.Columns["Identification_type"].HeaderText = "Identification type";
                    dataGridView_Request.Columns["Is_mandatory"].HeaderText = "Is mandatory ";



                }


                if (dataGridView_buttonList.SelectedCells.Count == 0)

                {
                    dataGridView_print.DataSource = null;
                    dataGridView_Confirm.DataSource = null;
                    dataGridView_Request.DataSource = null;
                }


            }
            catch (Exception ex)
            {
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
                    BusinessLayer.Button b = new BusinessLayer.Button
                    {
                        Name = dataGridView_buttonList.CurrentRow.Cells["name"].Value.ToString(),
                        Order = int.Parse(dataGridView_buttonList.CurrentRow.Cells["order"].Value.ToString()),
                        Id = int.Parse(dataGridView_buttonList.CurrentRow.Cells["id"].Value.ToString()),
                        Text = dataGridView_buttonList.CurrentRow.Cells["text"].Value.ToString()
                    };

                    // ReSharper disable once SuggestVarOrType_SimpleTypes
                    EditFrm frm = new EditFrm(b);
                    frm.ShowDialog();
                }

                dataGridView_buttonList.DataSource = null;
                dataGridView_buttonList.DataSource = BusinessLayer.Button.GetButtons();
                dataGridView_buttonList.Columns["id"].HeaderText = "ID";
                dataGridView_buttonList.Columns["name"].HeaderText = "Name";
                dataGridView_buttonList.Columns["text"].HeaderText = "Text";
                dataGridView_buttonList.Columns["order"].HeaderText = "Order";
            }
            catch (Exception ex)
            {
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

                MessageBox.Show("Exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
            }
        }
    }
}
