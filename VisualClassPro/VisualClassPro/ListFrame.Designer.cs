namespace VisualClassPro
{
    partial class ListFrame
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
            this.txtfilePath = new System.Windows.Forms.TextBox();
            this.FileInstructionLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.fileBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // txtfilePath
            // 
            this.txtfilePath.Location = new System.Drawing.Point(16, 37);
            this.txtfilePath.Name = "txtfilePath";
            this.txtfilePath.ReadOnly = true;
            this.txtfilePath.Size = new System.Drawing.Size(691, 20);
            this.txtfilePath.TabIndex = 0;
            this.txtfilePath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FileInstructionLabel
            // 
            this.FileInstructionLabel.AutoSize = true;
            this.FileInstructionLabel.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileInstructionLabel.ForeColor = System.Drawing.Color.Black;
            this.FileInstructionLabel.Location = new System.Drawing.Point(13, 9);
            this.FileInstructionLabel.Name = "FileInstructionLabel";
            this.FileInstructionLabel.Size = new System.Drawing.Size(308, 15);
            this.FileInstructionLabel.TabIndex = 1;
            this.FileInstructionLabel.Text = "Use the \"Browse\" button to selected your work directory.";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(713, 34);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fileBrowser
            // 
            this.fileBrowser.Location = new System.Drawing.Point(16, 78);
            this.fileBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.Size = new System.Drawing.Size(772, 360);
            this.fileBrowser.TabIndex = 4;
            this.fileBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.fileBrowser_DocumentCompleted);
            // 
            // ListFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileBrowser);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.FileInstructionLabel);
            this.Controls.Add(this.txtfilePath);
            this.Name = "ListFrame";
            this.Text = "ListFrame";
            this.Load += new System.EventHandler(this.ListFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfilePath;
        private System.Windows.Forms.Label FileInstructionLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.WebBrowser fileBrowser;
    }
}