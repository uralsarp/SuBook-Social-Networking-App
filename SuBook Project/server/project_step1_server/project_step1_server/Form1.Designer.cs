namespace server
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
            this.svlogs = new System.Windows.Forms.RichTextBox();
            this.textBox_svport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // svlogs
            // 
            this.svlogs.Location = new System.Drawing.Point(77, 63);
            this.svlogs.Name = "svlogs";
            this.svlogs.ReadOnly = true;
            this.svlogs.Size = new System.Drawing.Size(375, 276);
            this.svlogs.TabIndex = 0;
            this.svlogs.Text = "";
            // 
            // textBox_svport
            // 
            this.textBox_svport.Location = new System.Drawing.Point(76, 25);
            this.textBox_svport.Name = "textBox_svport";
            this.textBox_svport.Size = new System.Drawing.Size(173, 20);
            this.textBox_svport.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(288, 22);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(88, 25);
            this.button_listen.TabIndex = 3;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 363);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_svport);
            this.Controls.Add(this.svlogs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox svlogs;
        private System.Windows.Forms.TextBox textBox_svport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
    }
}

