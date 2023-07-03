namespace client
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
            this.components = new System.ComponentModel.Container();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_post = new System.Windows.Forms.TextBox();
            this.button_allposts = new System.Windows.Forms.Button();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.textBox_postID = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_removefriend = new System.Windows.Forms.Button();
            this.button_friendpost = new System.Windows.Forms.Button();
            this.button_addfriend = new System.Windows.Forms.Button();
            this.button_myposts = new System.Windows.Forms.Button();
            this.friendBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_deletefriend = new System.Windows.Forms.TextBox();
            this.button_showfriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(89, 17);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(177, 22);
            this.textBox_IP.TabIndex = 1;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(89, 110);
            this.textBox_Username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(177, 22);
            this.textBox_Username.TabIndex = 3;
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(293, 386);
            this.button_send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(93, 28);
            this.button_send.TabIndex = 5;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(89, 66);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(177, 22);
            this.textBox_Port.TabIndex = 6;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(297, 41);
            this.button_connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(100, 28);
            this.button_connect.TabIndex = 7;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(423, 26);
            this.logs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(296, 373);
            this.logs.TabIndex = 8;
            this.logs.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Port:";
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(293, 96);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(104, 33);
            this.button_disconnect.TabIndex = 15;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 395);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Post:";
            // 
            // textBox_post
            // 
            this.textBox_post.Enabled = false;
            this.textBox_post.Location = new System.Drawing.Point(89, 386);
            this.textBox_post.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_post.Name = "textBox_post";
            this.textBox_post.Size = new System.Drawing.Size(177, 22);
            this.textBox_post.TabIndex = 17;
            // 
            // button_allposts
            // 
            this.button_allposts.Enabled = false;
            this.button_allposts.Location = new System.Drawing.Point(423, 412);
            this.button_allposts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_allposts.Name = "button_allposts";
            this.button_allposts.Size = new System.Drawing.Size(93, 28);
            this.button_allposts.TabIndex = 18;
            this.button_allposts.Text = "All Posts";
            this.button_allposts.UseVisualStyleBackColor = true;
            this.button_allposts.Click += new System.EventHandler(this.button_allposts_Click);
            // 
            // textBox_user
            // 
            this.textBox_user.Enabled = false;
            this.textBox_user.Location = new System.Drawing.Point(89, 334);
            this.textBox_user.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(177, 22);
            this.textBox_user.TabIndex = 19;
            // 
            // textBox_postID
            // 
            this.textBox_postID.Enabled = false;
            this.textBox_postID.Location = new System.Drawing.Point(89, 438);
            this.textBox_postID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_postID.Name = "textBox_postID";
            this.textBox_postID.Size = new System.Drawing.Size(177, 22);
            this.textBox_postID.TabIndex = 20;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 337);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 442);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Post ID:";
            // 
            // button_delete
            // 
            this.button_delete.Enabled = false;
            this.button_delete.Location = new System.Drawing.Point(293, 434);
            this.button_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(93, 28);
            this.button_delete.TabIndex = 24;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_removefriend
            // 
            this.button_removefriend.Enabled = false;
            this.button_removefriend.Location = new System.Drawing.Point(293, 295);
            this.button_removefriend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_removefriend.Name = "button_removefriend";
            this.button_removefriend.Size = new System.Drawing.Size(93, 28);
            this.button_removefriend.TabIndex = 26;
            this.button_removefriend.Text = "Remove";
            this.button_removefriend.UseVisualStyleBackColor = true;
            this.button_removefriend.Click += new System.EventHandler(this.button_removefriend_Click);
            // 
            // button_friendpost
            // 
            this.button_friendpost.Enabled = false;
            this.button_friendpost.Location = new System.Drawing.Point(581, 412);
            this.button_friendpost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_friendpost.Name = "button_friendpost";
            this.button_friendpost.Size = new System.Drawing.Size(139, 28);
            this.button_friendpost.TabIndex = 27;
            this.button_friendpost.Text = "Friend\'s Post";
            this.button_friendpost.UseVisualStyleBackColor = true;
            this.button_friendpost.Click += new System.EventHandler(this.button_friendpost_Click);
            // 
            // button_addfriend
            // 
            this.button_addfriend.Enabled = false;
            this.button_addfriend.Location = new System.Drawing.Point(293, 330);
            this.button_addfriend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_addfriend.Name = "button_addfriend";
            this.button_addfriend.Size = new System.Drawing.Size(93, 28);
            this.button_addfriend.TabIndex = 28;
            this.button_addfriend.Text = "Add Friend";
            this.button_addfriend.UseVisualStyleBackColor = true;
            this.button_addfriend.Click += new System.EventHandler(this.button_addfriend_Click);
            // 
            // button_myposts
            // 
            this.button_myposts.Enabled = false;
            this.button_myposts.Location = new System.Drawing.Point(503, 454);
            this.button_myposts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_myposts.Name = "button_myposts";
            this.button_myposts.Size = new System.Drawing.Size(116, 28);
            this.button_myposts.TabIndex = 29;
            this.button_myposts.Text = "My Posts";
            this.button_myposts.UseVisualStyleBackColor = true;
            this.button_myposts.Click += new System.EventHandler(this.button_myposts_Click);
            // 
            // friendBox
            // 
            this.friendBox.Location = new System.Drawing.Point(89, 154);
            this.friendBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.friendBox.Name = "friendBox";
            this.friendBox.Size = new System.Drawing.Size(177, 130);
            this.friendBox.TabIndex = 30;
            this.friendBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 299);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "Delete User:";
            // 
            // textBox_deletefriend
            // 
            this.textBox_deletefriend.Enabled = false;
            this.textBox_deletefriend.Location = new System.Drawing.Point(89, 295);
            this.textBox_deletefriend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_deletefriend.Name = "textBox_deletefriend";
            this.textBox_deletefriend.Size = new System.Drawing.Size(177, 22);
            this.textBox_deletefriend.TabIndex = 32;
            // 
            // button_showfriend
            // 
            this.button_showfriend.Enabled = false;
            this.button_showfriend.Location = new System.Drawing.Point(293, 210);
            this.button_showfriend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_showfriend.Name = "button_showfriend";
            this.button_showfriend.Size = new System.Drawing.Size(93, 50);
            this.button_showfriend.TabIndex = 33;
            this.button_showfriend.Text = "Show Friends";
            this.button_showfriend.UseVisualStyleBackColor = true;
            this.button_showfriend.Click += new System.EventHandler(this.button_showfriend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 513);
            this.Controls.Add(this.button_showfriend);
            this.Controls.Add(this.textBox_deletefriend);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.friendBox);
            this.Controls.Add(this.button_myposts);
            this.Controls.Add(this.button_addfriend);
            this.Controls.Add(this.button_friendpost);
            this.Controls.Add(this.button_removefriend);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_postID);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.button_allposts);
            this.Controls.Add(this.textBox_post);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.textBox_IP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_post;
        private System.Windows.Forms.Button button_allposts;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.TextBox textBox_postID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_removefriend;
        private System.Windows.Forms.Button button_friendpost;
        private System.Windows.Forms.Button button_addfriend;
        private System.Windows.Forms.Button button_myposts;
        private System.Windows.Forms.RichTextBox friendBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_deletefriend;
        private System.Windows.Forms.Button button_showfriend;
    }
}

