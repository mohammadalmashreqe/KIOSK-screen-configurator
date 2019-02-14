using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIOSKScreenConfigurator.presentation_layer
{
    public partial class AddButton : Form
    {
        int id; 
        public AddButton( int id )
        {
            InitializeComponent();
            this.id = id; 
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_type.SelectedIndex==0)
            {

            }
            else 
                if(comboBox_type.SelectedIndex==1)

            {

            }
            else
            {

            }

        }

        private void AddButton_Load(object sender, EventArgs e)
        {

        }
    }
}
