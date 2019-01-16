namespace DBScriptRunner
{
    partial class CustomDialogBox
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOKYes = new System.Windows.Forms.Button();
            this.btnNoCancel = new System.Windows.Forms.Button();
            this.chkOption1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 10);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message";
            // 
            // btnOKYes
            // 
            this.btnOKYes.Location = new System.Drawing.Point(351, 175);
            this.btnOKYes.Name = "btnOKYes";
            this.btnOKYes.Size = new System.Drawing.Size(75, 23);
            this.btnOKYes.TabIndex = 1;
            this.btnOKYes.Text = "Yes";
            this.btnOKYes.UseVisualStyleBackColor = true;
            // 
            // btnNoCancel
            // 
            this.btnNoCancel.Location = new System.Drawing.Point(433, 175);
            this.btnNoCancel.Name = "btnNoCancel";
            this.btnNoCancel.Size = new System.Drawing.Size(75, 23);
            this.btnNoCancel.TabIndex = 2;
            this.btnNoCancel.Text = "No";
            this.btnNoCancel.UseVisualStyleBackColor = true;
            // 
            // chkOption1
            // 
            this.chkOption1.AutoSize = true;
            this.chkOption1.Location = new System.Drawing.Point(351, 152);
            this.chkOption1.Name = "chkOption1";
            this.chkOption1.Size = new System.Drawing.Size(182, 17);
            this.chkOption1.TabIndex = 3;
            this.chkOption1.Text = "Do not show this dialog any more";
            this.chkOption1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 121);
            this.panel1.TabIndex = 4;
            // 
            // CustomDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNoCancel;
            this.ClientSize = new System.Drawing.Size(539, 216);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkOption1);
            this.Controls.Add(this.btnNoCancel);
            this.Controls.Add(this.btnOKYes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomDialogBox";
            this.Text = "CustomDialogBox";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Button btnOKYes;
        internal System.Windows.Forms.Button btnNoCancel;
        internal System.Windows.Forms.CheckBox chkOption1;
        private System.Windows.Forms.Panel panel1;
    }
}