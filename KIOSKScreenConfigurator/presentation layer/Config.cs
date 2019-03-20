namespace KIOSKScreenConfigurator.presentation_layer
{
    using BusinessLayer;
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Config" />
    /// </summary>
    public partial class Config : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        public Config()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Config_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Config_Load(object sender, EventArgs e)
        {
            textBox_DBName.Text = Myconfig.DatabaseName;
            textBox_server.Text = Myconfig.ServerName;
        }

        /// <summary>
        /// test the connection string by calling TestCon from DataAccessLayer .
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string con =
                    $"Data Source = {textBox_server.Text};Initial Catalog={textBox_DBName.Text};;Integrated Security=True";

                if (Myconfig.TestCon(con))
                {
                    MessageBox.Show(" Test connection succeeded", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    {
                        Myconfig.DatabaseName = textBox_DBName.Text;
                        Myconfig.ServerName = textBox_server.Text;
                    }
                }
                else
                {
                    MessageBox.Show(" Invalid connection String  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        /// change the connection string by calling change Connection String from DataAccessLayer .
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // ReSharper disable once SuggestVarOrType_BuiltInTypes
                string con =
                    $"Data Source = {textBox_server.Text};Initial Catalog={textBox_DBName.Text};;Integrated Security=True";
                if (Myconfig.ChangeCon(con))
                {
                    Myconfig.DatabaseName = textBox_DBName.Text;
                    Myconfig.ServerName = textBox_server.Text;
                    Hide();
                    Form1 frm = new Form1();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(" Invalid connection String  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
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
                Close();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBox.Show("exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
