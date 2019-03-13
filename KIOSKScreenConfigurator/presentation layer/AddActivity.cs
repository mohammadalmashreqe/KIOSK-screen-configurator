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
        bool isPrint = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddActivity"/> class.
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
                if (comboBox_type.SelectedIndex == 0 || comboBox_type.SelectedIndex == 1)
                {

                    if (textBox_Info_msg.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Info_msg.Focus();
                        return;
                    }
                }
                else
    if (comboBox_type.SelectedIndex == 2)
                {
                    if (textBox_Info_msg.Text == "" || textBox_time_out.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox_Info_msg.Focus();
                        return;
                    }
                }


                if (isPrint)
                {
                    MessageBox.Show("can not add activity after print tickets ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count < 5)
                {




                    Identification_type ty;

                    if (comboBox_type.SelectedIndex == 0)

                    {
                        string m = textBox_Info_msg.Text;
                        int n = (int)numericUpDown1.Value;
                        Print_ticket_type a = new Print_ticket_type(m, n);
                        Program.myListPrint.Add(a);
                        isPrint = true;
                        button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";


                    }
                    else
                        if (comboBox_type.SelectedIndex == 1)
                    {
                        string m = textBox_Info_msg.Text;
                        if (comboBox_idtype.SelectedIndex == 0)
                            ty = Identification_type.card;
                        else
                            ty = Identification_type.mobile;

                        bool ismand;
                        if (checkBox1.Checked)
                            ismand = true;

                        else
                            ismand = true;

                        Request_identification a = new Request_identification(m, ty, ismand);
                        Program.myListrequest.Add(a);

                        button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";



                    }
                    else
                        if (comboBox_type.SelectedIndex == 2)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = int.Parse(textBox_time_out.Text);
                        Confirmation_activity a = new Confirmation_activity(m, n);
                        Program.myListConfirm.Add(a);


                        button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";



                    }






                }
                else
                {
                    MessageBox.Show("yo can not add more than 5 activity for button ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataGridView_print.DataSource = null;
                dataGridView_print.DataSource = Program.myListPrint;
                dataGridView_print.Columns["Information_message"].HeaderText = "Information message";
                dataGridView_print.Columns["Num_of_printed_tickets"].HeaderText = "Number of tickets"; 
                //hooooooooooooooooooooooooooooon
                dataGridView_Confirm.DataSource = null;
                dataGridView_Confirm.DataSource = Program.myListConfirm;
                dataGridView_Confirm.Columns["Information_message"].HeaderText = "Information message";
                //--------------------------------
                dataGridView_Request.DataSource = null;
                dataGridView_Request.DataSource = Program.myListrequest;
                dataGridView_Request.Columns["Information_message"].HeaderText = "Information message";
                dataGridView_Request.Columns["is_mandatory"].HeaderText = "Is mandatory";
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
                Program.myListConfirm.Clear();
                Program.myListPrint.Clear();
                Program.myListrequest.Clear();
                comboBox_idtype.SelectedIndex = 0;
                comboBox_type.SelectedIndex = 0;
                numericUpDown1.Value = 1;
                button_addactivity.Text = "add activity" + " ( " + (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count) + " /5 )";

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

            this.Close();
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
                Program.myListConfirm.Clear();
                Program.myListPrint.Clear();
                Program.myListrequest.Clear();
                this.Close();
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
