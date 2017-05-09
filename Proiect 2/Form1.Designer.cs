namespace Proiect_2
{
    partial class Form1
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
            this.buttonNSSK = new System.Windows.Forms.Button();
            this.textBoxRead = new System.Windows.Forms.TextBox();
            this.textBoxWrite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonKerberos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNSSK
            // 
            this.buttonNSSK.Location = new System.Drawing.Point(481, 8);
            this.buttonNSSK.Name = "buttonNSSK";
            this.buttonNSSK.Size = new System.Drawing.Size(75, 23);
            this.buttonNSSK.TabIndex = 0;
            this.buttonNSSK.Text = "NSSK Protocol";
            this.buttonNSSK.UseVisualStyleBackColor = true;
            this.buttonNSSK.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // textBoxRead
            // 
            this.textBoxRead.Location = new System.Drawing.Point(13, 37);
            this.textBoxRead.Multiline = true;
            this.textBoxRead.Name = "textBoxRead";
            this.textBoxRead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRead.Size = new System.Drawing.Size(624, 212);
            this.textBoxRead.TabIndex = 1;
            // 
            // textBoxWrite
            // 
            this.textBoxWrite.Location = new System.Drawing.Point(13, 277);
            this.textBoxWrite.Multiline = true;
            this.textBoxWrite.Name = "textBoxWrite";
            this.textBoxWrite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxWrite.Size = new System.Drawing.Size(624, 218);
            this.textBoxWrite.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Initial assumptions:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current knowledge:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Unsafe Protocol";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonKerberos
            // 
            this.buttonKerberos.Location = new System.Drawing.Point(400, 8);
            this.buttonKerberos.Name = "buttonKerberos";
            this.buttonKerberos.Size = new System.Drawing.Size(75, 23);
            this.buttonKerberos.TabIndex = 6;
            this.buttonKerberos.Text = "Kerberos Protocol";
            this.buttonKerberos.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 507);
            this.Controls.Add(this.buttonKerberos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWrite);
            this.Controls.Add(this.textBoxRead);
            this.Controls.Add(this.buttonNSSK);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNSSK;
        private System.Windows.Forms.TextBox textBoxRead;
        private System.Windows.Forms.TextBox textBoxWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonKerberos;
    }
}

