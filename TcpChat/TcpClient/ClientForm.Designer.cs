namespace TcpClient
{
    partial class ClientForm
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
            this.cntWelcome = new System.Windows.Forms.ContainerControl();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cntWelcome.SuspendLayout();
            this.SuspendLayout();
            // 
            // cntWelcome
            // 
            this.cntWelcome.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cntWelcome.Controls.Add(this.btnConnect);
            this.cntWelcome.Controls.Add(this.txtRoomName);
            this.cntWelcome.Controls.Add(this.lblRoomName);
            this.cntWelcome.Controls.Add(this.txtUsername);
            this.cntWelcome.Controls.Add(this.lblUsername);
            this.cntWelcome.Location = new System.Drawing.Point(1, -1);
            this.cntWelcome.Name = "cntWelcome";
            this.cntWelcome.Size = new System.Drawing.Size(379, 453);
            this.cntWelcome.TabIndex = 0;
            this.cntWelcome.Text = "Welcome";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(122, 187);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(171, 33);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(140, 133);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(189, 20);
            this.txtRoomName.TabIndex = 3;
            // 
            // lblRoomName
            // 
            this.lblRoomName.Location = new System.Drawing.Point(56, 132);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(78, 20);
            this.lblRoomName.TabIndex = 2;
            this.lblRoomName.Text = "Room\'s name :";
            this.lblRoomName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(140, 93);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(189, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(56, 93);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(66, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username : ";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 450);
            this.Controls.Add(this.cntWelcome);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.cntWelcome.ResumeLayout(false);
            this.cntWelcome.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox txtRoomName;

        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Button btnConnect;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.ContainerControl cntWelcome;

        #endregion
    }
}