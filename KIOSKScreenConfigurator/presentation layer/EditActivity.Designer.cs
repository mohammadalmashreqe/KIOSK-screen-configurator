namespace KIOSKScreenConfigurator.presentation_layer
{
    partial class EditActivity
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Info_msg = new System.Windows.Forms.TextBox();
            this.groupBox_confirm = new System.Windows.Forms.GroupBox();
            this.textBox_Timout = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_time_out = new System.Windows.Forms.TextBox();
            this.groupBox_requestident = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_idtype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox_printtickType = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox_confirm.SuspendLayout();
            this.groupBox_requestident.SuspendLayout();
            this.groupBox_printtickType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_Info_msg);
            this.groupBox1.Controls.Add(this.groupBox_requestident);
            this.groupBox1.Controls.Add(this.groupBox_printtickType);
            this.groupBox1.Controls.Add(this.groupBox_confirm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 163);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Information message : ";
            // 
            // textBox_Info_msg
            // 
            this.textBox_Info_msg.Location = new System.Drawing.Point(125, 8);
            this.textBox_Info_msg.Name = "textBox_Info_msg";
            this.textBox_Info_msg.Size = new System.Drawing.Size(187, 20);
            this.textBox_Info_msg.TabIndex = 8;
            // 
            // groupBox_confirm
            // 
            this.groupBox_confirm.Controls.Add(this.textBox_Timout);
            this.groupBox_confirm.Controls.Add(this.label10);
            this.groupBox_confirm.Controls.Add(this.textBox_time_out);
            this.groupBox_confirm.Location = new System.Drawing.Point(5, 36);
            this.groupBox_confirm.Name = "groupBox_confirm";
            this.groupBox_confirm.Size = new System.Drawing.Size(354, 85);
            this.groupBox_confirm.TabIndex = 14;
            this.groupBox_confirm.TabStop = false;
            // 
            // textBox_Timout
            // 
            this.textBox_Timout.Location = new System.Drawing.Point(120, 28);
            this.textBox_Timout.Name = "textBox_Timout";
            this.textBox_Timout.Size = new System.Drawing.Size(187, 20);
            this.textBox_Timout.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Time out : ";
            // 
            // textBox_time_out
            // 
            this.textBox_time_out.Location = new System.Drawing.Point(117, -54);
            this.textBox_time_out.Name = "textBox_time_out";
            this.textBox_time_out.Size = new System.Drawing.Size(200, 20);
            this.textBox_time_out.TabIndex = 15;
            // 
            // groupBox_requestident
            // 
            this.groupBox_requestident.Controls.Add(this.checkBox1);
            this.groupBox_requestident.Controls.Add(this.label9);
            this.groupBox_requestident.Controls.Add(this.comboBox_idtype);
            this.groupBox_requestident.Controls.Add(this.label8);
            this.groupBox_requestident.Location = new System.Drawing.Point(5, 56);
            this.groupBox_requestident.Name = "groupBox_requestident";
            this.groupBox_requestident.Size = new System.Drawing.Size(336, 90);
            this.groupBox_requestident.TabIndex = 4;
            this.groupBox_requestident.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = " Is mandatory";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 6;
            // 
            // comboBox_idtype
            // 
            this.comboBox_idtype.FormattingEnabled = true;
            this.comboBox_idtype.Items.AddRange(new object[] {
            "Card",
            "Mobile"});
            this.comboBox_idtype.Location = new System.Drawing.Point(120, 12);
            this.comboBox_idtype.Name = "comboBox_idtype";
            this.comboBox_idtype.Size = new System.Drawing.Size(187, 21);
            this.comboBox_idtype.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Identification type :";
            // 
            // groupBox_printtickType
            // 
            this.groupBox_printtickType.Controls.Add(this.numericUpDown1);
            this.groupBox_printtickType.Controls.Add(this.label7);
            this.groupBox_printtickType.Location = new System.Drawing.Point(5, 43);
            this.groupBox_printtickType.Name = "groupBox_printtickType";
            this.groupBox_printtickType.Size = new System.Drawing.Size(355, 84);
            this.groupBox_printtickType.TabIndex = 13;
            this.groupBox_printtickType.TabStop = false;
            this.groupBox_printtickType.Text = " ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(120, 25);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(187, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Number of  tickets:";
            // 
            // EditActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 218);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(410, 257);
            this.MinimumSize = new System.Drawing.Size(410, 257);
            this.Name = "EditActivity";
            this.Text = "Edit Activity";
            this.Load += new System.EventHandler(this.EditActivity_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_confirm.ResumeLayout(false);
            this.groupBox_confirm.PerformLayout();
            this.groupBox_requestident.ResumeLayout(false);
            this.groupBox_requestident.PerformLayout();
            this.groupBox_printtickType.ResumeLayout(false);
            this.groupBox_printtickType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Info_msg;
        private System.Windows.Forms.GroupBox groupBox_confirm;
        private System.Windows.Forms.TextBox textBox_Timout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_time_out;
        private System.Windows.Forms.GroupBox groupBox_requestident;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_idtype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox_printtickType;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
    }
}