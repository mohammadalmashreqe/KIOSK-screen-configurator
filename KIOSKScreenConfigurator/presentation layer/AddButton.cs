namespace KIOSKScreenConfigurator.presentation_layer
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="AddButton" />
    /// </summary>
    public partial class AddButton : Form
    {
        /// <summary>
        /// Defines the b to pass it to add activity form 
        /// </summary>
        BusinessLayer.Button b = new BusinessLayer.Button();

        /// <summary>
        /// Initializes a new instance of the <see cref="AddButton"/> class.
        /// </summary>
        public AddButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// choose defualt value and prepare form
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void AddButton_Load(object sender, EventArgs e)
        {
            button_AddActivity.Enabled = false;
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
        }

        
        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        
        private void AddButton_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        /// <summary>
        /// closed from form and check the number of activity
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.myListPrint.Count + Program.myListConfirm.Count + Program.myListrequest.Count == 0)
                {
                    if (MessageBox.Show("please enter 1 activity in minimum or press ok to exit without save  ", "wrong", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        this.Close();
                }
                else
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
        /// The textBox_but_order_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void textBox_but_order_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// validate the entered order value
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void textBox_but_order_Leave(object sender, EventArgs e)
        {

            try
            {
                int x;
                bool r = int.TryParse(textBox_but_order.Text, out x);
                if (r == false)
                {
                    MessageBox.Show("please enter a valid int number ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_but_order.Focus();

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
        /// save activities  
        /// </summary>
        /*
        private void button_addactivity_Click(object sender, EventArgs e)
        {  try
            {
                #region validation 
                if (comboBox_type.SelectedIndex == 0 || comboBox_type.SelectedIndex == 1)
                {

                    if (textBox_Info_msg.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Info_msg.Focus();
                        return;
                    }
                }
                else
                    if (comboBox_type.SelectedIndex == 2)
                {
                    if (textBox_Info_msg.Text == "" || textBox_time_out.Text == "")
                    {
                        MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox_Info_msg.Focus();
                        return;
                    }
                }

                #endregion

                if (isPrint)
                {
                    MessageBox.Show("can not add activity after print tickets ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
         

                #region add activities 

                if (Program.myListPrint.Count + Program.myListConfirm.Count + myListrequest.Count < 5)
                {

                   


                    Identification_type ty;

                    if (comboBox_type.SelectedIndex == 0)

                    {
                        string m = textBox_Info_msg.Text;
                        int n = (int)numericUpDown1.Value;
                        Print_ticket_type a = new Print_ticket_type(m, n);
                        myListPrint.Add(a);
                        isPrint = true;
                        button_addactivity.Text = "add activity" + " ( " + (myListPrint.Count + myListConfirm.Count + myListrequest.Count) + " /5 )";
                        MessageBox.Show("activity added ");
                   

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
                        myListrequest.Add(a);

                        button_addactivity.Text = "add activity" + " ( " + (myListPrint.Count + myListConfirm.Count + myListrequest.Count) + " /5 )";
                        MessageBox.Show("activity added ");



                    }
                    else
                        if (comboBox_type.SelectedIndex == 2)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = int.Parse(textBox_time_out.Text);
                        Confirmation_activity a = new Confirmation_activity(m, n);
                        myListConfirm.Add(a);


                        button_addactivity.Text = "add activity" + " ( " + (myListPrint.Count + myListConfirm.Count + myListrequest.Count) + " /5 )";
                        MessageBox.Show("activity added ");



                    }






                }
                else
                {
                    MessageBox.Show("yo can not add more than 5 activity for button ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataGridView_print.DataSource = null;
                dataGridView_print.DataSource = myListPrint;
                dataGridView_Confirm.DataSource = null;
                dataGridView_Confirm.DataSource = myListConfirm;
                dataGridView_Request.DataSource = null;
                dataGridView_Request.DataSource = myListrequest;
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

        */
        /// <summary>
        ///  save all work to the database
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.Button b1 = new BusinessLayer.Button();


                if (textBox_but_name.Text == "" || textBox_but_order.Text == "" || textBox_but_txt.Text == "")

                {
                    MessageBox.Show("please enter all data field ", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                b1.Text = textBox_but_txt.Text;
                b1.Order = int.Parse(textBox_but_order.Text);
                b1.Name = textBox_but_name.Text;

                if (b1.AddButton())
                {
                    MessageBox.Show("Button added ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }







                int bt_id = b1.GetId();





                for (int i = 0; i < Program.myListConfirm.Count; i++)
                {

                    Program.myListConfirm[i].AddconActivity(bt_id);
                }


                for (int i = 0; i < Program.myListPrint.Count; i++)

                {
                    Program.myListPrint[i].AddPrintActivity(bt_id);
                }




                for (int i = 0; i < Program.myListrequest.Count; i++)
                {
                    Program.myListrequest[i].AddRequestActivity(bt_id);
                }

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
        /// close the form
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button5_Click(object sender, EventArgs e)
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
        /// return choices to th default "clear"
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button2_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The groupBox3_Enter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The dataGridView_Confirm_CellContentClick
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="DataGridViewCellEventArgs"/></param>
        private void dataGridView_Confirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        /// The button1_Click_1
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                AddActivity frm = new AddActivity();
                frm.ShowDialog();
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
        /// The button2_Click_1
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            b.Name = textBox_but_name.Text;
            b.Text = textBox_but_txt.Text;
            b.Order = int.Parse(textBox_but_order.Text);
            button_AddActivity.Enabled = true;
        }
    }
}
