namespace BootCampStudentResultManagement
{
    partial class MainUI
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
            this.exitButton = new System.Windows.Forms.Button();
            this.showresultSheetButton = new System.Windows.Forms.Button();
            this.enterResultButton = new System.Windows.Forms.Button();
            this.enrollButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(108, 310);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // showresultSheetButton
            // 
            this.showresultSheetButton.Location = new System.Drawing.Point(61, 200);
            this.showresultSheetButton.Name = "showresultSheetButton";
            this.showresultSheetButton.Size = new System.Drawing.Size(161, 72);
            this.showresultSheetButton.TabIndex = 6;
            this.showresultSheetButton.Text = "Show Result Sheet";
            this.showresultSheetButton.UseVisualStyleBackColor = true;
            this.showresultSheetButton.Click += new System.EventHandler(this.showresultSheetButton_Click);
            // 
            // enterResultButton
            // 
            this.enterResultButton.Location = new System.Drawing.Point(61, 102);
            this.enterResultButton.Name = "enterResultButton";
            this.enterResultButton.Size = new System.Drawing.Size(161, 72);
            this.enterResultButton.TabIndex = 7;
            this.enterResultButton.Text = "Enter Result";
            this.enterResultButton.UseVisualStyleBackColor = true;
            this.enterResultButton.Click += new System.EventHandler(this.enterResultButton_Click);
            // 
            // enrollButton
            // 
            this.enrollButton.Location = new System.Drawing.Point(61, 12);
            this.enrollButton.Name = "enrollButton";
            this.enrollButton.Size = new System.Drawing.Size(161, 72);
            this.enrollButton.TabIndex = 8;
            this.enrollButton.Text = "Enroll";
            this.enrollButton.UseVisualStyleBackColor = true;
            this.enrollButton.Click += new System.EventHandler(this.enrollButton_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 357);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.showresultSheetButton);
            this.Controls.Add(this.enterResultButton);
            this.Controls.Add(this.enrollButton);
            this.Name = "MainUI";
            this.Text = "MainUI";
           
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button showresultSheetButton;
        private System.Windows.Forms.Button enterResultButton;
        private System.Windows.Forms.Button enrollButton;
    }
}

