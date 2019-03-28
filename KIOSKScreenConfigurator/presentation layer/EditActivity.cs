using System;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;

namespace KIOSKScreenConfigurator.presentation_layer
{
    public partial class EditActivity : Form
    {
        private readonly Activity _current;
        private int ActivityID; 
        public EditActivity( Activity o)
        {
            InitializeComponent();
            try
            {
                _current = o;
                if (o.Type == "Confirmation Activity")
                {
                    groupBox_confirm.Visible = true;
                    groupBox_printtickType.Visible = false;
                    groupBox_requestident.Visible = false;

                    ConfirmationActivity x = (ConfirmationActivity) o;
                    textBox_Info_msg.Text = o.InformationMessage;
                    textBox_Timout.Text = x.Timeout.ToString();
                    ActivityID =int.Parse(x.Id.ToString());


                }
                else if (o.Type == "Request Identification")
                {
                    groupBox_confirm.Visible = false;
                    groupBox_printtickType.Visible = false;
                    groupBox_requestident.Visible = true;

                    RequestIdentification x = (RequestIdentification) o;
                    textBox_Info_msg.Text = o.InformationMessage;
                    comboBox_idtype.SelectedIndex = x.IdType == IdentificationType.Card ? 0 : 1;
                    checkBox1.Checked = x.IsMandatory;
                    ActivityID = int.Parse(x.Id.ToString());


                }
                else
                {
                    groupBox_confirm.Visible = false;
                    groupBox_printtickType.Visible = true;
                    groupBox_requestident.Visible = false;
                    PrintTicketType x = (PrintTicketType) o;
                    textBox_Info_msg.Text = o.InformationMessage;
                    numericUpDown1.Value = x.NumOfPrintedTickets;
                    ActivityID = int.Parse(x.Id.ToString());
                }

                
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBoxEx.Show(this,"Exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditActivity_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ActivityID;

                if (_current.Type == "Print Ticket Type")
                {
                    PrintTicketType x = (PrintTicketType) _current;

                    x.NumOfPrintedTickets = Convert.ToInt16(numericUpDown1.Value);
                    x.InformationMessage = textBox_Info_msg.Text;
                    x.Id = id;
                    x.UpdateActivity();


                }

                if (_current.Type == "Confirmation Activity")
                {
                    ConfirmationActivity x = (ConfirmationActivity) _current;
                    x.Timeout = int.Parse(textBox_Timout.Text);
                    x.Id = id;
                    x.InformationMessage = textBox_Info_msg.Text;
                    x.UpdateActivity();
                }

                if (_current.Type == "Request Identification") 
                {
                    RequestIdentification x = (RequestIdentification) _current;
                    x.InformationMessage = textBox_Info_msg.Text;
                    x.IsMandatory = checkBox1.Checked;
                    x.IdType = comboBox_idtype.SelectedIndex == 0 ? IdentificationType.Card : IdentificationType.Mobile;
                    x.UpdateActivity();
                }
                Close();
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);


                MessageBoxEx.Show(this,"Exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
