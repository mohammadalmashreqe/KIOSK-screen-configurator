namespace KIOSKScreenConfigurator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_buttonList = new System.Windows.Forms.DataGridView();
            this.dataGridView_activity = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kIOSK_screen_configuratorDataSet = new KIOSKScreenConfigurator.KIOSK_screen_configuratorDataSet();
            this.kIOSKscreenconfiguratorDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_buttonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kIOSK_screen_configuratorDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kIOSKscreenconfiguratorDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView_buttonList);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 327);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridView_buttonList
            // 
            this.dataGridView_buttonList.AllowUserToAddRows = false;
            this.dataGridView_buttonList.AllowUserToDeleteRows = false;
            this.dataGridView_buttonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_buttonList.Location = new System.Drawing.Point(18, 19);
            this.dataGridView_buttonList.Name = "dataGridView_buttonList";
            this.dataGridView_buttonList.ReadOnly = true;
            this.dataGridView_buttonList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_buttonList.Size = new System.Drawing.Size(445, 231);
            this.dataGridView_buttonList.TabIndex = 0;
            this.dataGridView_buttonList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_buttonList_CellContentClick);
            this.dataGridView_buttonList.SelectionChanged += new System.EventHandler(this.dataGridView_buttonList_SelectionChanged);
            this.dataGridView_buttonList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // dataGridView_activity
            // 
            this.dataGridView_activity.AllowUserToAddRows = false;
            this.dataGridView_activity.AllowUserToDeleteRows = false;
            this.dataGridView_activity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_activity.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_activity.Name = "dataGridView_activity";
            this.dataGridView_activity.ReadOnly = true;
            this.dataGridView_activity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_activity.Size = new System.Drawing.Size(247, 231);
            this.dataGridView_activity.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_activity);
            this.groupBox2.Location = new System.Drawing.Point(538, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 293);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activity ";
            // 
            // kIOSK_screen_configuratorDataSet
            // 
            this.kIOSK_screen_configuratorDataSet.DataSetName = "KIOSK_screen_configuratorDataSet";
            this.kIOSK_screen_configuratorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kIOSKscreenconfiguratorDataSetBindingSource
            // 
            this.kIOSKscreenconfiguratorDataSetBindingSource.DataSource = this.kIOSK_screen_configuratorDataSet;
            this.kIOSKscreenconfiguratorDataSetBindingSource.Position = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_buttonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kIOSK_screen_configuratorDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kIOSKscreenconfiguratorDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_buttonList;
        private System.Windows.Forms.DataGridView dataGridView_activity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource kIOSKscreenconfiguratorDataSetBindingSource;
        private KIOSK_screen_configuratorDataSet kIOSK_screen_configuratorDataSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

