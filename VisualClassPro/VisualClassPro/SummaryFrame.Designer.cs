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
            this.statsList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // statsList
            // 
            this.statsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsList.HideSelection = false;
            this.statsList.Location = new System.Drawing.Point(18, 18);
            this.statsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statsList.Name = "statsList";
            this.statsList.Size = new System.Drawing.Size(1020, 476);
            this.statsList.TabIndex = 0;
            this.statsList.UseCompatibleStateImageBehavior = false;
            // 
            // SummaryFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 515);
            this.Controls.Add(this.statsList);
            this.Name = "SummaryFrame";
            this.Text = "SummaryFrame";
            this.Load += new System.EventHandler(this.SummaryFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView statsList;
    }
}