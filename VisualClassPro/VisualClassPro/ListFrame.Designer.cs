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
            this.backBtn = new System.Windows.Forms.Button();
            this.frontBtn = new System.Windows.Forms.Button();
            this.selectFilebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtfilePath
            // 
            this.txtfilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtfilePath.Location = new System.Drawing.Point(16, 40);
            this.txtfilePath.Name = "txtfilePath";
            this.txtfilePath.ReadOnly = true;
            this.txtfilePath.Size = new System.Drawing.Size(603, 20);
            this.txtfilePath.TabIndex = 0;
            this.txtfilePath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FileInstructionLabel
            // 
            this.FileInstructionLabel.AutoSize = true;
            this.FileInstructionLabel.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileInstructionLabel.ForeColor = System.Drawing.Color.Black;
            this.FileInstructionLabel.Location = new System.Drawing.Point(13, 22);
            this.FileInstructionLabel.Name = "FileInstructionLabel";
            this.FileInstructionLabel.Size = new System.Drawing.Size(308, 15);
            this.FileInstructionLabel.TabIndex = 1;
            this.FileInstructionLabel.Text = "Use the \"Browse\" button to selected your work directory.";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(637, 37);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fileBrowser
            // 
            this.fileBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBrowser.Location = new System.Drawing.Point(16, 78);
            this.fileBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.Size = new System.Drawing.Size(772, 341);
            this.fileBrowser.TabIndex = 4;
            this.fileBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.fileBrowser_DocumentCompleted);
            // 
            // backBtn
            // 
            this.backBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backBtn.Location = new System.Drawing.Point(12, 425);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 5;
            this.backBtn.Text = "<<";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // frontBtn
            // 
            this.frontBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.frontBtn.Location = new System.Drawing.Point(718, 425);
            this.frontBtn.Name = "frontBtn";
            this.frontBtn.Size = new System.Drawing.Size(75, 23);
            this.frontBtn.TabIndex = 6;
            this.frontBtn.Text = ">>";
            this.frontBtn.UseVisualStyleBackColor = true;
            this.frontBtn.Click += new System.EventHandler(this.frontBtn_Click);
            // 
            // selectFilebtn
            // 
            this.selectFilebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFilebtn.Location = new System.Drawing.Point(718, 37);
            this.selectFilebtn.Name = "selectFilebtn";
            this.selectFilebtn.Size = new System.Drawing.Size(75, 23);
            this.selectFilebtn.TabIndex = 7;
            this.selectFilebtn.Text = "Select File";
            this.selectFilebtn.UseVisualStyleBackColor = true;
            this.selectFilebtn.Click += new System.EventHandler(this.selectFilebtn_Click);
            // 
            // ListFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectFilebtn);
            this.Controls.Add(this.frontBtn);
            this.Controls.Add(this.backBtn);
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
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button frontBtn;
        private System.Windows.Forms.Button selectFilebtn;
    }
}