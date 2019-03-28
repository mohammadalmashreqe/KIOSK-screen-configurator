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
        

        private readonly int _id; 
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:KIOSKScreenConfigurator.presentation_layer.AddActivity" /> class.
        /// </summary>
        public AddActivity(int i)
        {
            InitializeComponent();
            _id = i; 
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
             
                comboBox_idtype.SelectedIndex = 0;
                comboBox_type.SelectedIndex = 0;
                numericUpDown1.Value = 1;

            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show(this,"exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        /// <summary>
        /// The button3_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button3_Click(object sender, EventArgs e)
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
                                MessageBoxEx.Show(this,@"please enter all data field ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox_Info_msg.Focus();
                                return;
                            }

                            break;
                        }
                    case 2 when textBox_Info_msg.Text == "" || textBox_Timout.Text == "":
                        MessageBoxEx.Show(this,@"please enter all data field ", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        textBox_Info_msg.Focus();
                        return;
                }


             



             
                    if (comboBox_type.SelectedIndex == 0)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = (int)numericUpDown1.Value;
                        PrintTicketType a = new PrintTicketType(m, n);
                        a.Type = "Print Ticket Type";
                        if(_id>0)
                       
                        a.AddPrintActivity(_id);
                        else
                          Program.MyListPrint.Add(a);
                        Close();
                       
                    }
                    else if (comboBox_type.SelectedIndex == 1)
                    {
                        string m = textBox_Info_msg.Text;
                        IdentificationType ty = comboBox_idtype.SelectedIndex == 0
                            ? IdentificationType.Card
                            : IdentificationType.Mobile;

                        var ismand = checkBox1.Checked;

                        RequestIdentification a = new RequestIdentification(m, ty, ismand);
                        a.Type = "Request Identification";
                        if(_id>0)
                         a.AddRequestActivity(_id);
                         else
                          Program.MyListrequest.Add(a);

                        
                        Close();


                    }
                    else if (comboBox_type.SelectedIndex == 2)
                    {
                        string m = textBox_Info_msg.Text;
                        int n = int.Parse(textBox_Timout.Text);
                        ConfirmationActivity a = new ConfirmationActivity(m, n);
                        a.Type = "Confirmation Activity";
                    if(_id>0)
                        a.AddConfirmationActivity(_id);
                    else
                    {
                                                Program.MyListConfirm.Add(a);

                    }
                        Close();


                        
                    }
                
             





                //--------------------------------
   
                textBox_Info_msg.Text = "";
                textBox_Timout.Text = "";
                numericUpDown1.Value = 1;

            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                

                MessageBoxEx.Show(this,"exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        


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
               
               Close();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show(this,"exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
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
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show(this,"exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
               

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox_requestident_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
