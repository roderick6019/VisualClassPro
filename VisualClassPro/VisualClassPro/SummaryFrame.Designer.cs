namespace VisualClassPro
{
    partial class SummaryFrame
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
            this.testSummaryList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // testSummaryList
            // 
            this.testSummaryList.FormattingEnabled = true;
            this.testSummaryList.ItemHeight = 20;
            this.testSummaryList.Location = new System.Drawing.Point(12, 12);
            this.testSummaryList.Name = "testSummaryList";
            this.testSummaryList.Size = new System.Drawing.Size(1033, 484);
            this.testSummaryList.TabIndex = 0;
            this.testSummaryList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // SummaryFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 515);
            this.Controls.Add(this.testSummaryList);
            this.Name = "SummaryFrame";
            this.Text = "SummaryFrame";
            this.Load += new System.EventHandler(this.SummaryFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox testSummaryList;
    }
}