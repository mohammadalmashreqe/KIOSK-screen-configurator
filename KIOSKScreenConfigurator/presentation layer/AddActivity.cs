namespace KIOSKScreenConfigurator.presentation_layer
{
    using BusinessLayer;
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="AddActivity" />
    /// </summary>
    public partial class AddActivity : Form
    {
        /// <summary>
        /// Defines the isPrint
        /// </summary>
        private bool _isPrint;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:KIOSKScreenConfigurator.presentation_layer.AddActivity" /> class.
        /// </summary>
        public AddActivity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// add activity to the list 
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button_addactivity_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox_type.SelectedIndex)
                {
                    case 0:
                    case 1:
                    {
                        if (textBox_Info_msg.Text == "")
                        {
                            MessageBox.Show(@"please enter all data field ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox_Info_msg.Focus();
                            return;
                        }

                        break;
                    }
                    case 2 when textBox_Info_msg.Text == "" || textBox_time_out.Text == "":
                        MessageBox.Show(@"please enter all data field ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox_Info_msg.Focus();
                        return;
                }


                if (_isPrint)
                {
                    MessageBox.Show(@"can not add activity after print tickets ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (Program.MyListPrint.Count + Program.MyListConfirm.Count + Program.MyListrequest.Count < 5)
                {
                    if (comboBox_type.SelectedIndex == 0)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = (int) numericUpDown1.Value;
                        PrintTicketType a = new PrintTicketType(m, n);
                        Program.MyListPrint.Add(a);
                        _isPrint = true;
                        button_addactivity.Text = "add activity" + " ( " +
                                                  (Program.MyListPrint.Count + Program.MyListConfirm.Count +
                                                   Program.MyListrequest.Count) + " /5 )";
                    }
                    else if (comboBox_type.SelectedIndex == 1)
                    {
                        string m = textBox_Info_msg.Text;
                        IdentificationType ty = comboBox_idtype.SelectedIndex == 0
                            ? IdentificationType.Card
                            : IdentificationType.Mobile;

                        var ismand = checkBox1.Checked;

                        RequestIdentification a = new RequestIdentification(m, ty, ismand);
                        Program.MyListrequest.Add(a);

                        button_addactivity.Text = "add activity" + " ( " +
                                                  (Program.MyListPrint.Count + Program.MyListConfirm.Count +
                                                   Program.MyListrequest.Count) + " /5 )";
                    }
                    else if (comboBox_type.SelectedIndex == 2)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = int.Parse(textBox_time_out.Text);
                        ConfirmationActivity a = new ConfirmationActivity(m, n);
                        Program.MyListConfirm.Add(a);


                        button_addactivity.Text = "add activity" + " ( " +
                                                  (Program.MyListPrint.Count + Program.MyListConfirm.Count +
                                                   Program.MyListrequest.Count) + " /5 )";
                    }
                }
                else
                {
                    MessageBox.Show("yo can not add more than 5 activity for button ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

              
                    dataGridView_print.DataSource = null;
                    dataGridView_print.DataSource = Program.MyListPrint;
                    dataGridView_print.Columns["InformationMessage"].HeaderText = "Information message";
                    dataGridView_print.Columns["NumOfPrintedTickets"].HeaderText = "Number of tickets";
                

                dataGridView_Confirm.DataSource = null;
                dataGridView_Confirm.DataSource = Program.MyListConfirm;
                dataGridView_Confirm.Columns["InformationMessage"].HeaderText = "Information message";
                //--------------------------------
                dataGridView_Request.DataSource = null;
                dataGridView_Request.DataSource = Program.MyListrequest;
                dataGridView_Request.Columns["InformationMessage"].HeaderText = "Information message";
                dataGridView_Request.Columns["IsMandatory"].HeaderText = "Is mandatory";
                dataGridView_Request.Columns["type"].HeaderText = "Type";
                textBox_Info_msg.Text = "";
                textBox_time_out.Text = "";
                numericUpDown1.Value = 1;

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
        /// Load form and give control initial state 
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void AddActivity_Load(object sender, EventArgs e)
        {
            try
            {
                Program.MyListConfirm.Clear();
                Program.MyListPrint.Clear();
                Program.MyListrequest.Clear();
                comboBox_idtype.SelectedIndex = 0;
                comboBox_type.SelectedIndex = 0;
                numericUpDown1.Value = 1;
                button_addactivity.Text = "add activity" + " ( " + (Program.MyListPrint.Count + Program.MyListConfirm.Count + Program.MyListrequest.Count) + " /5 )";

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
        /// The button3_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button3_Click(object sender, EventArgs e)
        {

            Close();
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
                Program.MyListConfirm.Clear();
                Program.MyListPrint.Clear();
                Program.MyListrequest.Clear();
               Close();
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
        /// The comboBox_type_SelectedIndexChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_type.SelectedIndex == 0)
                {
                    groupBox_printtickType.Visible = true;
                    groupBox_requestident.Visible = false;
                    groupBox_confirm.Visible = false;
                }


                else
                    if (comboBox_type.SelectedIndex == 1)
                {
                    groupBox_requestident.Visible = true;
                    groupBox_printtickType.Visible = false;
                    groupBox_confirm.Visible = false;

                }
                else
                {
                    groupBox_confirm.Visible = true;
                    groupBox_printtickType.Visible = false;
                    groupBox_requestident.Visible = false;
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
        /// The button2_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox_type.SelectedIndex = 0;
                textBox_Info_msg.Text = "";
                textBox_time_out.Text = "";
                comboBox_idtype.SelectedIndex = 0;
                numericUpDown1.Value = 1;
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
        /// The AddActivity_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void AddActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
