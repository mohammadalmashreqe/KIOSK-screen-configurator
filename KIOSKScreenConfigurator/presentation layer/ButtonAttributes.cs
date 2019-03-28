using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using Button = BusinessLayer.Button;

namespace KIOSKScreenConfigurator.presentation_layer
{
    public partial class ButtonAttributes : Form
    {
        private readonly Button _b2;
        private bool _isPrint;

        public void LoadFromList()
        {
            listView1.Items.Clear();
            foreach (ConfirmationActivity t in Program.MyListConfirm)
            {
                string[] row = {t.InformationMessage, t.Type.ToString(),"0"};
                ListViewItem l = new ListViewItem(row);
                listView1.Items.Add(l);
            }

            foreach (PrintTicketType t in Program.MyListPrint )
            {
                string[] row = { t.InformationMessage, t.Type.ToString(), "0" };
                ListViewItem l = new ListViewItem(row);
                listView1.Items.Add(l);
                _isPrint = true;
            }

            foreach (RequestIdentification t in Program.MyListrequest)
            {
                string[] row = { t.InformationMessage, t.Type.ToString(), "0" };
                ListViewItem l = new ListViewItem(row);
                listView1.Items.Add(l);

            }
        }

        public void LoadData()
        {
            _b2.Activities.Clear();
            listView1.Items.Clear();

            int val = _b2.GetId();
            foreach (DataRow x in ConfirmationActivity.GetConfirmationActivity(val).Rows)
            {



                string[] row = {x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString()};
                ListViewItem l = new ListViewItem(row);
                ConfirmationActivity t =
                    new ConfirmationActivity(x["info_msg"].ToString(), int.Parse(x["timeOutInSec"].ToString()))
                    {
                        Type = "Confirmation Activity", Id = int.Parse(x["ID"].ToString())
                    };

                _b2.Activities.Add(t);
                listView1.Items.Add(l);
            }

            foreach (DataRow x in PrintTicketType.GetPrintActivity(val).Rows)
            {
                PrintTicketType t = new PrintTicketType(x["info_msg"].ToString(),
                    int.Parse(x["num_of_tick"].ToString()))
                {
                    Type = "Print Ticket Type", Id = int.Parse(x["ID"].ToString())
                };
                _b2.Activities.Add(t);
                string[] row = {x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString()};
                ListViewItem l = new ListViewItem(row);
                listView1.Items.Add(l);
                _isPrint = true;

            }

            foreach (DataRow x in RequestIdentification.GetRequestActivity(val).Rows)
            {

                IdentificationType tid = x["Identification_type"].ToString().Equals("card")
                    ? IdentificationType.Card
                    : IdentificationType.Mobile;
                RequestIdentification t = new RequestIdentification(x["info_msg"].ToString(), tid,
                    bool.Parse(x["Is_mandatory"].ToString()))
                {
                    Type = "Request Identification", Id = int.Parse(x["ID"].ToString())
                };
                _b2.Activities.Add(t);
                string[] row = {x["info_msg"].ToString(), x["type"].ToString(), x["ID"].ToString()};

                ListViewItem l = new ListViewItem(row);
                listView1.Items.Add(l);
            }




        }

        public ButtonAttributes(Button para)
        {
            InitializeComponent();
            if (para != null)
            {
                _b2 = para;

                Text = "Edit Button";

                listView1.Items.Clear();
                textBox_but_name.Text = _b2.Name;
                textBox_but_order.Text = _b2.Order.ToString();

                LoadData();




            }
            else
            {
                _b2 = new Button();
                Text = "Add Button";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox_but_name.Text == "")
                {
                    label2.Visible = true;
                    return;


                }

                label2.Visible = false;

                if (textBox_but_order.Text == "")
                {
                    label5.Visible = true;
                    return;
                }

                label5.Visible = false;




                if (int.TryParse(textBox_but_order.Text, out _))
                {

                    label5.Visible = false;


                }
                else
                {
                    label5.Text = "enter valid number";
                    label5.Visible = true;
                    return;
                }




                if (Text.Equals("Add Button"))
                {
                    {
                        _b2.Name = textBox_but_name.Text;
                        _b2.Order = int.Parse(textBox_but_order.Text);
                        if (_b2.AddButton())
                            MessageBoxEx.Show(this,"The button has been successfully added ", "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                     

                        foreach (PrintTicketType t in Program.MyListPrint)
                        {
                            t.AddPrintActivity(_b2.GetId());
                        }

                        foreach (ConfirmationActivity t in Program.MyListConfirm)
                        {
                            t.AddConfirmationActivity(_b2.GetId());
                        }

                        foreach (RequestIdentification t in Program.MyListrequest)
                        {
                            t.AddRequestActivity(_b2.GetId());
                        }
                        Program.MyListConfirm.Clear();
                        Program.MyListPrint.Clear();
                        Program.MyListrequest.Clear();
                        textBox_but_name.Text = "";
                        textBox_but_order.Text = "1";
                        Close();
                    }
                }
                else
                {

                    _b2.Id = _b2.GetId();
                    _b2.Name = textBox_but_name.Text;
                    _b2.Order = int.Parse(textBox_but_order.Text);
                    if (_b2.UpdateButton())
                        MessageBoxEx.Show(this,"The button has been successfully updated ", "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    Program.MyListConfirm.Clear();
                    Program.MyListPrint.Clear();
                    Program.MyListrequest.Clear();

                    textBox_but_name.Text = "";
                    textBox_but_order.Text = "1";
                    Close();
                }







            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                MessageBoxEx.Show(this,
                    "exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine +
                    "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ButtonAttributes_Load(object sender, EventArgs e)
        {
            label5.Text = "required";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count <= 5)
                {
                    if (!Text.Equals("Add Button"))
                    {
                        if (_b2.Activities.Count < 5 && !_isPrint)
                        {
                            AddActivity frm = new AddActivity(_b2.Id);
                            frm.ShowDialog();



                            listView1.Items.Clear();



                       
                            LoadData();







                        }
                        else
                        {
                            MessageBoxEx.Show(this,"Can not add activity", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }



                    }
                    else
                    {
                        if (_isPrint || listView1.Items.Count>=5)
                        {
                            MessageBoxEx.Show(this,"Can not add activity", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                           







                        }
                        else
                        {
                            AddActivity frm = new AddActivity(0);
                            frm.ShowDialog();



                            listView1.Items.Clear();


                            LoadFromList();
                        }
                    }
                }
                else

                    MessageBoxEx.Show(this,"Can not add more than 5 activities", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);
                MessageBoxEx.Show(this,
                    "exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine +
                    "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    if (item.SubItems[1].Text == "print_ticket_type")
                    {
                        PrintTicketType o = PrintTicketType.GetInfoById(int.Parse(item.SubItems[2].Text));

                        EditActivity frm = new EditActivity(o);
                        frm.ShowDialog();

                        LoadData();

                    }


                    else if (item.SubItems[1].Text == "Request_identification")

                    {
                        RequestIdentification o = RequestIdentification.GetInfoById(int.Parse(item.SubItems[2].Text));
                        EditActivity frm = new EditActivity(o);
                        frm.ShowDialog();
                        LoadData();

                    }
                    else if (item.SubItems[1].Text == "Confirmation_activity")
                    {
                        ConfirmationActivity o = ConfirmationActivity.GetInfoById(int.Parse(item.SubItems[2].Text));
                        EditActivity frm = new EditActivity(o);
                        frm.ShowDialog();
                        LoadData();


                    }
                }

                else
                {
                    MessageBoxEx.Show(this,"No data selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show(this,
                    "exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine +
                    "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    if (Text== "Add Button")
                    {
                        if (item.SubItems[1].Text.ToUpper()=="printtickettype".ToUpper())
                        {
                            int loc = 0;
                            foreach (PrintTicketType t in Program.MyListPrint)
                            {
                                if (t.InformationMessage == item.SubItems[0].Text)
                                    break;
                                loc++;
                            }
                            Program.MyListPrint.RemoveAt(loc);
                            LoadFromList();
                            _isPrint = false; 

                        }
                        else
                        if(item.SubItems[1].Text.ToUpper() == "RequestIdentification".ToUpper())
                        {
                            int loc = 0;
                            foreach (RequestIdentification t in Program.MyListrequest)
                            {
                                if (t.InformationMessage == item.SubItems[0].Text)
                                    break;
                                loc++;
                            }
                            Program.MyListrequest.RemoveAt(loc);
                            LoadFromList();


                        }
                        else if (item.SubItems[1].Text.ToUpper() == "ConfirmationActivity".ToUpper())
                        {
                            int loc = 0;
                            foreach (ConfirmationActivity t in Program.MyListConfirm)
                            {
                                if (t.InformationMessage == item.SubItems[0].Text)
                                    break;
                                loc++;
                            }
                            Program.MyListConfirm.RemoveAt(loc);
                            LoadFromList();
                        }
                        

                    }
                    else
                    if (item.SubItems[1].Text == "print_ticket_type")
                    {
                        PrintTicketType.DeleteActivity(item.SubItems[2].Text);

                        _isPrint = false;

                        LoadData();

                    }


                    else if (item.SubItems[1].Text == "Request_identification")

                    {
                        RequestIdentification.DeleteActivity(item.SubItems[2].Text);

                        LoadData();

                    }
                    else if (item.SubItems[1].Text == "Confirmation_activity")
                    {
                        ConfirmationActivity.DeleteActivity(item.SubItems[2].Text);

                        LoadData();


                    }

                }
                else
                    MessageBoxEx.Show(this,"No data selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorLog(ex);

                MessageBoxEx.Show(this,
                    "exception : " + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine +
                    "for more info : " + Directory.GetCurrentDirectory() + @"\LogFile.txt", "exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
