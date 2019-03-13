namespace KIOSKScreenConfigurator.presentation_layer
{
    using BusinessLayer;
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="EditFrm" />
    /// </summary>
    public partial class EditFrm : Form
    {
        /// <summary>
        /// Defines the current
        /// </summary>
      readonly  BusinessLayer.Button _current;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditFrm"/> class.
        /// </summary>
        /// <param name="b">The b<see cref="BusinessLayer.Button"/></param>
        public EditFrm(BusinessLayer.Button b)
        {
            try
            {
                _current = b;

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
        /// The EditFrm_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void EditFrm_Load(object sender, EventArgs e)
        {
            try
            {
                textBox_id.Text = _current.Id + "";
                textBox_name.Text = _current.Name;
                textBox_order.Text = _current.Order + "";
                textBox_text.Text = _current.Text;
                int val = int.Parse(textBox_id.Text);
                tabControl1.SelectedIndex = 0;
                LoadDataGrid(val);
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
                if (_current.UpdateButton())
                {
                    MessageBox.Show("button updated ", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("no row effected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// The textBox_name_Leave
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void textBox_name_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox_name.Text.Length == 0)
                {
                    MessageBox.Show("please fill all fields ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_name.Focus();


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
        /// The textBox_text_Leave
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void textBox_text_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox_text.Text.Length == 0)
                {
                    MessageBox.Show("please fill all fields ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_text.Focus();
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
        /// The textBox_order_Leave
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void textBox_order_Leave(object sender, EventArgs e)
        {
            if (textBox_order.Text.Length == 0)
            {
                MessageBox.Show("please fill all fields ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_order.Focus();

            }
            else if (!int.TryParse(textBox_order.Text, out int _))
            {
                MessageBox.Show("please enter a valid int order ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_order.Focus();
            }
        }

        /// <summary>
        /// The button2_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// The label2_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void label2_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The groupBox2_Enter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The button5_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0 when dataGridView_print.CurrentRow == null:
                        return;
                    case 0:
                    {
                        string actId = dataGridView_print.CurrentRow.Cells["ID"].Value.ToString();
                        string i = textBox_id.Text;
                        if (MessageBox.Show("are you sure want delete selected activity", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            PrintTicketType.DeleteActivity(actId);





                        LoadDataGrid(int.Parse(i));
                        break;
                    }
                    case 1:
                    {
                        string actId = dataGridView_Request.CurrentRow.Cells["ID"].Value.ToString();
                        string i = textBox_id.Text;
                        if (MessageBox.Show("are you sure want delete selected activity", "Warning",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                        {
                        }
                        else
                            RequestIdentification.DeleteActivity(actId);


                        LoadDataGrid(int.Parse(i));
                        break;
                    }
                    default:
                    {
                        string actId = dataGridView_Confirm.CurrentRow.Cells["ID"].Value.ToString();
                        string i = textBox_id.Text;
                        if (MessageBox.Show("are you sure want delete selected activity", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

                            ConfirmationActivity.DeleteActivity(actId);



                        LoadDataGrid(int.Parse(i));
                        break;
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
        /// The loadDataGrid
        /// </summary>
        /// <param name="i">The i<see cref="int"/></param>
        public void LoadDataGrid(int i)
        {
            try
            {
                dataGridView_print.DataSource = null;
                dataGridView_Confirm.DataSource = null;
                dataGridView_Request.DataSource = null;

                dataGridView_Confirm.DataSource = ConfirmationActivity.GetConfirmationActivity(i);
                dataGridView_Confirm.Columns["info_msg"].HeaderText = "Message";
                dataGridView_Confirm.Columns["but_id"].HeaderText = "Button ID";
                dataGridView_Confirm.Columns["type"].HeaderText = "Type";
                dataGridView_Confirm.Columns["timeOutInSec"].HeaderText = "Time out";

                dataGridView_print.DataSource = PrintTicketType.GetPrintActivity(i);
                dataGridView_print.Columns["info_msg"].HeaderText = "Message";
                dataGridView_print.Columns["but_id"].HeaderText = "Button ID";
                dataGridView_print.Columns["type"].HeaderText = "Type";
                dataGridView_print.Columns["num_of_tick"].HeaderText = "Number of tickets";

                dataGridView_Request.DataSource = RequestIdentification.GetRequestActivity(i);
                dataGridView_Request.Columns["info_msg"].HeaderText = "Message";
                dataGridView_Request.Columns["but_id"].HeaderText = "Button ID";
                dataGridView_Request.Columns["type"].HeaderText = "Type";
                dataGridView_Request.Columns["Identification_type"].HeaderText = "Identification type";
                dataGridView_Request.Columns["Is_mandatory"].HeaderText = "Is mandatory ";
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
    }
}
