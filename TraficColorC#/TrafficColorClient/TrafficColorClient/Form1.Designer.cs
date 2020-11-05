namespace TrafficColorClient
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
            this.btnKuningHidup = new System.Windows.Forms.RadioButton();
            this.btnKuningMati = new System.Windows.Forms.RadioButton();
            this.btnMerahHidup = new System.Windows.Forms.RadioButton();
            this.btnMerahMati = new System.Windows.Forms.RadioButton();
            this.btnHijauHidup = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHijauMati = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKuningHidup
            // 
            this.btnKuningHidup.AutoSize = true;
            this.btnKuningHidup.Location = new System.Drawing.Point(6, 32);
            this.btnKuningHidup.Name = "btnKuningHidup";
            this.btnKuningHidup.Size = new System.Drawing.Size(53, 17);
            this.btnKuningHidup.TabIndex = 0;
            this.btnKuningHidup.Text = "Hidup";
            this.btnKuningHidup.UseVisualStyleBackColor = true;
            this.btnKuningHidup.CheckedChanged += new System.EventHandler(this.btnKuningHidup_CheckedChanged);
            // 
            // btnKuningMati
            // 
            this.btnKuningMati.AutoSize = true;
            this.btnKuningMati.Location = new System.Drawing.Point(6, 73);
            this.btnKuningMati.Name = "btnKuningMati";
            this.btnKuningMati.Size = new System.Drawing.Size(45, 17);
            this.btnKuningMati.TabIndex = 1;
            this.btnKuningMati.Text = "Mati";
            this.btnKuningMati.UseVisualStyleBackColor = true;
            this.btnKuningMati.CheckedChanged += new System.EventHandler(this.btnKuningMati_CheckedChanged);
            // 
            // btnMerahHidup
            // 
            this.btnMerahHidup.AutoSize = true;
            this.btnMerahHidup.Location = new System.Drawing.Point(6, 32);
            this.btnMerahHidup.Name = "btnMerahHidup";
            this.btnMerahHidup.Size = new System.Drawing.Size(53, 17);
            this.btnMerahHidup.TabIndex = 2;
            this.btnMerahHidup.Text = "Hidup";
            this.btnMerahHidup.UseVisualStyleBackColor = true;
            this.btnMerahHidup.CheckedChanged += new System.EventHandler(this.btnMerahHidup_CheckedChanged);
            // 
            // btnMerahMati
            // 
            this.btnMerahMati.AutoSize = true;
            this.btnMerahMati.Location = new System.Drawing.Point(6, 73);
            this.btnMerahMati.Name = "btnMerahMati";
            this.btnMerahMati.Size = new System.Drawing.Size(45, 17);
            this.btnMerahMati.TabIndex = 3;
            this.btnMerahMati.Text = "Mati";
            this.btnMerahMati.UseVisualStyleBackColor = true;
            this.btnMerahMati.CheckedChanged += new System.EventHandler(this.btnMerahMati_CheckedChanged);
            // 
            // btnHijauHidup
            // 
            this.btnHijauHidup.AutoSize = true;
            this.btnHijauHidup.Location = new System.Drawing.Point(6, 32);
            this.btnHijauHidup.Name = "btnHijauHidup";
            this.btnHijauHidup.Size = new System.Drawing.Size(53, 17);
            this.btnHijauHidup.TabIndex = 5;
            this.btnHijauHidup.Text = "Hidup";
            this.btnHijauHidup.UseVisualStyleBackColor = true;
            this.btnHijauHidup.CheckedChanged += new System.EventHandler(this.btnHijauHidup_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKuningHidup);
            this.groupBox1.Controls.Add(this.btnKuningMati);
            this.groupBox1.Location = new System.Drawing.Point(96, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(81, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kunig";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHijauMati);
            this.groupBox2.Controls.Add(this.btnHijauHidup);
            this.groupBox2.Location = new System.Drawing.Point(183, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hijau";
            // 
            // btnHijauMati
            // 
            this.btnHijauMati.AutoSize = true;
            this.btnHijauMati.Location = new System.Drawing.Point(6, 73);
            this.btnHijauMati.Name = "btnHijauMati";
            this.btnHijauMati.Size = new System.Drawing.Size(45, 17);
            this.btnHijauMati.TabIndex = 6;
            this.btnHijauMati.Text = "Mati";
            this.btnHijauMati.UseVisualStyleBackColor = true;
            this.btnHijauMati.CheckedChanged += new System.EventHandler(this.btnHijauMati_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnMerahHidup);
            this.groupBox3.Controls.Add(this.btnMerahMati);
            this.groupBox3.Location = new System.Drawing.Point(12, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(78, 99);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Merah";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(83, 35);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(129, 20);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "16375";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(83, 69);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(189, 20);
            this.txtIPAddress.TabIndex = 9;
            this.txtIPAddress.Text = "192.168.1.10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 298);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnKuningHidup;
        private System.Windows.Forms.RadioButton btnKuningMati;
        private System.Windows.Forms.RadioButton btnMerahHidup;
        private System.Windows.Forms.RadioButton btnMerahMati;
        private System.Windows.Forms.RadioButton btnHijauHidup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton btnHijauMati;
    }
}

