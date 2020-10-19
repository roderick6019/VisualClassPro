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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FileInstructionLabel = new System.Windows.Forms.Label();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(377, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FileInstructionLabel
            // 
            this.FileInstructionLabel.AutoSize = true;
            this.FileInstructionLabel.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileInstructionLabel.ForeColor = System.Drawing.Color.White;
            this.FileInstructionLabel.Location = new System.Drawing.Point(13, 9);
            this.FileInstructionLabel.Name = "FileInstructionLabel";
            this.FileInstructionLabel.Size = new System.Drawing.Size(311, 15);
            this.FileInstructionLabel.TabIndex = 1;
            this.FileInstructionLabel.Text = "Please Enter the file path were all you CSV files are stored:\r\n";
            // 
            // fileListBox
            // 
            this.fileListBox.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 22;
            this.fileListBox.Items.AddRange(new object[] {
            "Item 1",
            "Item 2"});
            this.fileListBox.Location = new System.Drawing.Point(16, 100);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(759, 312);
            this.fileListBox.TabIndex = 2;
            // 
            // ListFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.FileInstructionLabel);
            this.Controls.Add(this.textBox1);
            this.Name = "ListFrame";
            this.Text = "ListFrame";
            this.Load += new System.EventHandler(this.ListFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label FileInstructionLabel;
        private System.Windows.Forms.ListBox fileListBox;
    }
}