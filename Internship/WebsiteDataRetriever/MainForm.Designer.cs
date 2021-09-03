namespace WebsiteDataRetriever
{
    partial class MainForm
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
            this.pbLoader = new System.Windows.Forms.ProgressBar();
            this.btnNormalExecute = new System.Windows.Forms.Button();
            this.btnNormalParallelExecute = new System.Windows.Forms.Button();
            this.btnAsyncExecute = new System.Windows.Forms.Button();
            this.btnParallelAsyncExecute = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pbLoader
            // 
            this.pbLoader.ForeColor = System.Drawing.Color.Crimson;
            this.pbLoader.Location = new System.Drawing.Point(43, 218);
            this.pbLoader.Name = "pbLoader";
            this.pbLoader.Size = new System.Drawing.Size(483, 36);
            this.pbLoader.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLoader.TabIndex = 4;
            // 
            // btnNormalExecute
            // 
            this.btnNormalExecute.Location = new System.Drawing.Point(43, 38);
            this.btnNormalExecute.Name = "btnNormalExecute";
            this.btnNormalExecute.Size = new System.Drawing.Size(224, 72);
            this.btnNormalExecute.TabIndex = 5;
            this.btnNormalExecute.Text = "Normal Execute";
            this.btnNormalExecute.UseVisualStyleBackColor = true;
            this.btnNormalExecute.Click += new System.EventHandler(this.btnNormalExecute_Click);
            // 
            // btnNormalParallelExecute
            // 
            this.btnNormalParallelExecute.Location = new System.Drawing.Point(302, 38);
            this.btnNormalParallelExecute.Name = "btnNormalParallelExecute";
            this.btnNormalParallelExecute.Size = new System.Drawing.Size(224, 72);
            this.btnNormalParallelExecute.TabIndex = 6;
            this.btnNormalParallelExecute.Text = "Normal Parallel Execute";
            this.btnNormalParallelExecute.UseVisualStyleBackColor = true;
            this.btnNormalParallelExecute.Click += new System.EventHandler(this.btnNormalParallelExecute_Click);
            // 
            // btnAsyncExecute
            // 
            this.btnAsyncExecute.Location = new System.Drawing.Point(43, 126);
            this.btnAsyncExecute.Name = "btnAsyncExecute";
            this.btnAsyncExecute.Size = new System.Drawing.Size(224, 72);
            this.btnAsyncExecute.TabIndex = 7;
            this.btnAsyncExecute.Text = "Async Execute";
            this.btnAsyncExecute.UseVisualStyleBackColor = true;
            this.btnAsyncExecute.Click += new System.EventHandler(this.btnAsyncExecute_Click);
            // 
            // btnParallelAsyncExecute
            // 
            this.btnParallelAsyncExecute.Location = new System.Drawing.Point(302, 126);
            this.btnParallelAsyncExecute.Name = "btnParallelAsyncExecute";
            this.btnParallelAsyncExecute.Size = new System.Drawing.Size(224, 72);
            this.btnParallelAsyncExecute.TabIndex = 8;
            this.btnParallelAsyncExecute.Text = "Parallel Async Execute";
            this.btnParallelAsyncExecute.UseVisualStyleBackColor = true;
            this.btnParallelAsyncExecute.Click += new System.EventHandler(this.btnParallelAsyncExecute_Click);
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(43, 280);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.Size = new System.Drawing.Size(482, 264);
            this.tbDisplay.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 593);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.btnParallelAsyncExecute);
            this.Controls.Add(this.btnAsyncExecute);
            this.Controls.Add(this.btnNormalParallelExecute);
            this.Controls.Add(this.btnNormalExecute);
            this.Controls.Add(this.pbLoader);
            this.Name = "MainForm";
            this.Text = "Retrieve Data";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox tbDisplay;

        private System.Windows.Forms.Button btnParallelAsyncExecute;

        private System.Windows.Forms.Button btnAsyncExecute;

        private System.Windows.Forms.Button btnNormalParallelExecute;

        private System.Windows.Forms.Button btnNormalExecute;
        
        private System.Windows.Forms.ProgressBar pbLoader;

        #endregion
    }
}