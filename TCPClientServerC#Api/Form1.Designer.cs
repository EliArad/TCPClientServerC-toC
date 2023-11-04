namespace TCPClientServerC_Api
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDiconnect = new System.Windows.Forms.Button();
            this.txtPositionX = new System.Windows.Forms.TextBox();
            this.btnSendTrackVersion1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPositionY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPositionZ = new System.Windows.Forms.TextBox();
            this.txtServerMessages = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(64, 68);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(116, 44);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDiconnect
            // 
            this.btnDiconnect.Location = new System.Drawing.Point(249, 68);
            this.btnDiconnect.Name = "btnDiconnect";
            this.btnDiconnect.Size = new System.Drawing.Size(116, 44);
            this.btnDiconnect.TabIndex = 1;
            this.btnDiconnect.Text = "Diconnect";
            this.btnDiconnect.UseVisualStyleBackColor = true;
            this.btnDiconnect.Click += new System.EventHandler(this.btnDiconnect_Click);
            // 
            // txtPositionX
            // 
            this.txtPositionX.Location = new System.Drawing.Point(117, 53);
            this.txtPositionX.Name = "txtPositionX";
            this.txtPositionX.Size = new System.Drawing.Size(144, 26);
            this.txtPositionX.TabIndex = 2;
            // 
            // btnSendTrackVersion1
            // 
            this.btnSendTrackVersion1.Location = new System.Drawing.Point(744, 651);
            this.btnSendTrackVersion1.Name = "btnSendTrackVersion1";
            this.btnSendTrackVersion1.Size = new System.Drawing.Size(464, 44);
            this.btnSendTrackVersion1.TabIndex = 3;
            this.btnSendTrackVersion1.Text = "Send Track";
            this.btnSendTrackVersion1.UseVisualStyleBackColor = true;
            this.btnSendTrackVersion1.Click += new System.EventHandler(this.btnSendTrackVersion1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPositionZ);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPositionY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPositionX);
            this.groupBox1.Location = new System.Drawing.Point(744, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 559);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track vesion 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Position X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Position Y";
            // 
            // txtPositionY
            // 
            this.txtPositionY.Location = new System.Drawing.Point(117, 101);
            this.txtPositionY.Name = "txtPositionY";
            this.txtPositionY.Size = new System.Drawing.Size(144, 26);
            this.txtPositionY.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Position Z";
            // 
            // txtPositionZ
            // 
            this.txtPositionZ.Location = new System.Drawing.Point(117, 153);
            this.txtPositionZ.Name = "txtPositionZ";
            this.txtPositionZ.Size = new System.Drawing.Size(144, 26);
            this.txtPositionZ.TabIndex = 6;
            // 
            // txtServerMessages
            // 
            this.txtServerMessages.Location = new System.Drawing.Point(43, 179);
            this.txtServerMessages.Multiline = true;
            this.txtServerMessages.Name = "txtServerMessages";
            this.txtServerMessages.Size = new System.Drawing.Size(366, 504);
            this.txtServerMessages.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 793);
            this.Controls.Add(this.txtServerMessages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSendTrackVersion1);
            this.Controls.Add(this.btnDiconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "TCP Client Server Host Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDiconnect;
        private System.Windows.Forms.TextBox txtPositionX;
        private System.Windows.Forms.Button btnSendTrackVersion1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPositionY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPositionZ;
        private System.Windows.Forms.TextBox txtServerMessages;
    }
}

