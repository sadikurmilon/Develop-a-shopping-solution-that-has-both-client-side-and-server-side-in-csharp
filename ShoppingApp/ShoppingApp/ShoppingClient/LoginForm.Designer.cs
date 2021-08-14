
namespace ShoppingClient
{
    partial class LoginForm
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
            this.HostNaTxtBox = new System.Windows.Forms.TextBox();
            this.AccNoTxtBox = new System.Windows.Forms.TextBox();
            this.lblHostName = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.Connectbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HostNaTxtBox
            // 
            this.HostNaTxtBox.Location = new System.Drawing.Point(105, 71);
            this.HostNaTxtBox.Name = "HostNaTxtBox";
            this.HostNaTxtBox.Size = new System.Drawing.Size(187, 20);
            this.HostNaTxtBox.TabIndex = 8;
            this.HostNaTxtBox.Text = "localhost";
            // 
            // AccNoTxtBox
            // 
            this.AccNoTxtBox.Location = new System.Drawing.Point(105, 36);
            this.AccNoTxtBox.Name = "AccNoTxtBox";
            this.AccNoTxtBox.Size = new System.Drawing.Size(187, 20);
            this.AccNoTxtBox.TabIndex = 6;
            this.AccNoTxtBox.TextChanged += new System.EventHandler(this.AccNoTxtBox_TextChanged);
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostName.Location = new System.Drawing.Point(12, 71);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(84, 18);
            this.lblHostName.TabIndex = 7;
            this.lblHostName.Text = "&Host Name";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNo.Location = new System.Drawing.Point(12, 39);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(86, 18);
            this.lblAccountNo.TabIndex = 5;
            this.lblAccountNo.Text = "&Account No";
            // 
            // Connectbtn
            // 
            this.Connectbtn.BackColor = System.Drawing.Color.OliveDrab;
            this.Connectbtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Connectbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connectbtn.Location = new System.Drawing.Point(156, 114);
            this.Connectbtn.Name = "Connectbtn";
            this.Connectbtn.Size = new System.Drawing.Size(126, 38);
            this.Connectbtn.TabIndex = 9;
            this.Connectbtn.Text = "Connect";
            this.Connectbtn.UseVisualStyleBackColor = false;
            this.Connectbtn.Click += new System.EventHandler(this.Connectbtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(329, 184);
            this.Controls.Add(this.HostNaTxtBox);
            this.Controls.Add(this.AccNoTxtBox);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.Connectbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HostNaTxtBox;
        private System.Windows.Forms.TextBox AccNoTxtBox;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Button Connectbtn;
    }
}

