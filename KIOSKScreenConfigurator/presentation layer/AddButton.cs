using BusinessLayer;

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
       readonly BusinessLayer.Button _b = new BusinessLayer.Button();

        /// <summary>
        /// Initializes a new instance of the <see cref="AddButton"/> class.
        /// </summary>
        public AddButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// choose default value and prepare form
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void AddButton_Load(object sender, EventArgs e)
        {
            button_AddActivity.Enabled = false;
        }


        private void AddButton_FormClosed(object sender, FormClosedEventArgs e)
        {
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
                bool r = int.TryParse(textBox_but_order.Text, out int _ );
                if (r) return;
                MessageBox.Show("please enter a valid int number ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_but_order.Focus();
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







                int btId = b1.GetId();





                foreach (ConfirmationActivity t in Program.MyListConfirm)
                {
                    t.AddConfirmationActivity(btId);
                }


                foreach (PrintTicketType t in Program.MyListPrint)
                {
                    t.AddPrintActivity(btId);
                }




                foreach (RequestIdentification t in Program.MyListrequest)
                {
                    t.AddRequestActivity(btId);
                }

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
        /// close the form
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button5_Click(object sender, EventArgs e)
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
        /// The groupBox3_Enter
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void groupBox3_Enter(object sender, EventArgs e)
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
            _b.Name = textBox_but_name.Text;
            _b.Text = textBox_but_txt.Text;
            _b.Order = int.Parse(textBox_but_order.Text);
            button_AddActivity.Enabled = true;
        }
    }
}
