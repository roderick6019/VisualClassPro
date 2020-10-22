namespace VisualClassPro
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SummaryButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListButton = new System.Windows.Forms.Button();
            this.AnalysisButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.txtPathLabel = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // SummaryButton
            // 
            resources.ApplyResources(this.SummaryButton, "SummaryButton");
            this.SummaryButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SummaryButton.FlatAppearance.BorderSize = 0;
            this.SummaryButton.Name = "SummaryButton";
            this.SummaryButton.UseVisualStyleBackColor = false;
            this.SummaryButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.ListButton);
            this.panel1.Controls.Add(this.AnalysisButton);
            this.panel1.Controls.Add(this.SummaryButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // ListButton
            // 
            this.ListButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.ListButton, "ListButton");
            this.ListButton.FlatAppearance.BorderSize = 0;
            this.ListButton.Name = "ListButton";
            this.ListButton.UseVisualStyleBackColor = false;
            this.ListButton.Click += new System.EventHandler(this.ListButton_Click);
            // 
            // AnalysisButton
            // 
            resources.ApplyResources(this.AnalysisButton, "AnalysisButton");
            this.AnalysisButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.AnalysisButton.FlatAppearance.BorderSize = 0;
            this.AnalysisButton.Name = "AnalysisButton";
            this.AnalysisButton.UseVisualStyleBackColor = false;
            this.AnalysisButton.Click += new System.EventHandler(this.AnalysisButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.txtPathLabel);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Name = "panel2";
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // txtPathLabel
            // 
            this.txtPathLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtPathLabel, "txtPathLabel");
            this.txtPathLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.txtPathLabel.Name = "txtPathLabel";
            this.txtPathLabel.ReadOnly = true;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SummaryButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button AnalysisButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        public System.Windows.Forms.TextBox txtPathLabel;
    }
}

