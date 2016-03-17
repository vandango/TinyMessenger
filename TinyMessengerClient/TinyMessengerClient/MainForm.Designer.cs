namespace TinyMessengerClient
{
	partial class MainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.lvChats = new System.Windows.Forms.ListView();
			this.btnConnect = new System.Windows.Forms.Button();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.lvFriends = new System.Windows.Forms.ListView();
			this.lbServerLog = new System.Windows.Forms.ListBox();
			this.btnCreateChat = new System.Windows.Forms.Button();
			this.gpChats = new System.Windows.Forms.GroupBox();
			this.gpFriends = new System.Windows.Forms.GroupBox();
			this.txtNewFriendUsername = new System.Windows.Forms.TextBox();
			this.btnAddNewFriend = new System.Windows.Forms.Button();
			this.txtChatName = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtActiveChat = new System.Windows.Forms.RichTextBox();
			this.gpActiveChat = new System.Windows.Forms.GroupBox();
			this.lvChatUser = new System.Windows.Forms.ListView();
			this.gpChats.SuspendLayout();
			this.gpFriends.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gpActiveChat.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvChats
			// 
			this.lvChats.FullRowSelect = true;
			this.lvChats.HideSelection = false;
			this.lvChats.Location = new System.Drawing.Point(6, 19);
			this.lvChats.MultiSelect = false;
			this.lvChats.Name = "lvChats";
			this.lvChats.Size = new System.Drawing.Size(227, 141);
			this.lvChats.TabIndex = 0;
			this.lvChats.UseCompatibleStateImageBehavior = false;
			this.lvChats.View = System.Windows.Forms.View.List;
			this.lvChats.DoubleClick += new System.EventHandler(this.lvChats_DoubleClick);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(217, 18);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 20);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Tag = "CONNECT";
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(67, 19);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(144, 20);
			this.txtUsername.TabIndex = 6;
			this.txtUsername.Text = "jnaumann";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Username";
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(6, 258);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(315, 58);
			this.txtMessage.TabIndex = 7;
			this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(328, 258);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(76, 58);
			this.btnSend.TabIndex = 8;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// lvFriends
			// 
			this.lvFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lvFriends.FullRowSelect = true;
			this.lvFriends.HideSelection = false;
			this.lvFriends.Location = new System.Drawing.Point(6, 19);
			this.lvFriends.Name = "lvFriends";
			this.lvFriends.Size = new System.Drawing.Size(227, 73);
			this.lvFriends.TabIndex = 9;
			this.lvFriends.UseCompatibleStateImageBehavior = false;
			this.lvFriends.View = System.Windows.Forms.View.List;
			// 
			// lbServerLog
			// 
			this.lbServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbServerLog.FormattingEnabled = true;
			this.lbServerLog.Location = new System.Drawing.Point(6, 19);
			this.lbServerLog.Name = "lbServerLog";
			this.lbServerLog.Size = new System.Drawing.Size(643, 264);
			this.lbServerLog.TabIndex = 10;
			// 
			// btnCreateChat
			// 
			this.btnCreateChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCreateChat.Location = new System.Drawing.Point(158, 98);
			this.btnCreateChat.Name = "btnCreateChat";
			this.btnCreateChat.Size = new System.Drawing.Size(75, 20);
			this.btnCreateChat.TabIndex = 11;
			this.btnCreateChat.Text = "Create Chat";
			this.btnCreateChat.UseVisualStyleBackColor = true;
			this.btnCreateChat.Click += new System.EventHandler(this.btnCreateChat_Click);
			// 
			// gpChats
			// 
			this.gpChats.Controls.Add(this.lvChats);
			this.gpChats.Location = new System.Drawing.Point(12, 97);
			this.gpChats.Name = "gpChats";
			this.gpChats.Size = new System.Drawing.Size(239, 166);
			this.gpChats.TabIndex = 12;
			this.gpChats.TabStop = false;
			this.gpChats.Text = "Chats";
			// 
			// gpFriends
			// 
			this.gpFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gpFriends.Controls.Add(this.txtNewFriendUsername);
			this.gpFriends.Controls.Add(this.btnAddNewFriend);
			this.gpFriends.Controls.Add(this.txtChatName);
			this.gpFriends.Controls.Add(this.lvFriends);
			this.gpFriends.Controls.Add(this.btnCreateChat);
			this.gpFriends.Location = new System.Drawing.Point(12, 269);
			this.gpFriends.Name = "gpFriends";
			this.gpFriends.Size = new System.Drawing.Size(239, 150);
			this.gpFriends.TabIndex = 13;
			this.gpFriends.TabStop = false;
			this.gpFriends.Text = "Friends";
			// 
			// txtNewFriendUsername
			// 
			this.txtNewFriendUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtNewFriendUsername.Location = new System.Drawing.Point(6, 124);
			this.txtNewFriendUsername.Name = "txtNewFriendUsername";
			this.txtNewFriendUsername.Size = new System.Drawing.Size(146, 20);
			this.txtNewFriendUsername.TabIndex = 14;
			// 
			// btnAddNewFriend
			// 
			this.btnAddNewFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddNewFriend.Location = new System.Drawing.Point(158, 124);
			this.btnAddNewFriend.Name = "btnAddNewFriend";
			this.btnAddNewFriend.Size = new System.Drawing.Size(75, 20);
			this.btnAddNewFriend.TabIndex = 13;
			this.btnAddNewFriend.Text = "Add Friend";
			this.btnAddNewFriend.UseVisualStyleBackColor = true;
			this.btnAddNewFriend.Click += new System.EventHandler(this.btnAddNewFriend_Click);
			// 
			// txtChatName
			// 
			this.txtChatName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtChatName.Location = new System.Drawing.Point(6, 98);
			this.txtChatName.Name = "txtChatName";
			this.txtChatName.Size = new System.Drawing.Size(146, 20);
			this.txtChatName.TabIndex = 12;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.btnConnect);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.txtUsername);
			this.groupBox3.Location = new System.Drawing.Point(12, 40);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(655, 51);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Connect";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.lbServerLog);
			this.groupBox4.Location = new System.Drawing.Point(12, 425);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(655, 289);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Server Log";
			// 
			// txtActiveChat
			// 
			this.txtActiveChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtActiveChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtActiveChat.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtActiveChat.Location = new System.Drawing.Point(6, 74);
			this.txtActiveChat.Name = "txtActiveChat";
			this.txtActiveChat.Size = new System.Drawing.Size(398, 178);
			this.txtActiveChat.TabIndex = 16;
			this.txtActiveChat.Text = "";
			this.txtActiveChat.TextChanged += new System.EventHandler(this.txtActiveChat_TextChanged);
			// 
			// gpActiveChat
			// 
			this.gpActiveChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gpActiveChat.Controls.Add(this.lvChatUser);
			this.gpActiveChat.Controls.Add(this.txtActiveChat);
			this.gpActiveChat.Controls.Add(this.txtMessage);
			this.gpActiveChat.Controls.Add(this.btnSend);
			this.gpActiveChat.Enabled = false;
			this.gpActiveChat.Location = new System.Drawing.Point(257, 97);
			this.gpActiveChat.Name = "gpActiveChat";
			this.gpActiveChat.Size = new System.Drawing.Size(410, 322);
			this.gpActiveChat.TabIndex = 11;
			this.gpActiveChat.TabStop = false;
			this.gpActiveChat.Text = "(No Chat selected)";
			// 
			// lvChatUser
			// 
			this.lvChatUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvChatUser.FullRowSelect = true;
			this.lvChatUser.HideSelection = false;
			this.lvChatUser.Location = new System.Drawing.Point(6, 19);
			this.lvChatUser.Name = "lvChatUser";
			this.lvChatUser.Size = new System.Drawing.Size(398, 49);
			this.lvChatUser.TabIndex = 17;
			this.lvChatUser.UseCompatibleStateImageBehavior = false;
			this.lvChatUser.View = System.Windows.Forms.View.List;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 726);
			this.Controls.Add(this.gpActiveChat);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.gpChats);
			this.Controls.Add(this.gpFriends);
			this.MinimumSize = new System.Drawing.Size(679, 726);
			this.Name = "MainForm";
			this.Text = "TinyMessenger";
			this.Controls.SetChildIndex(this.gpFriends, 0);
			this.Controls.SetChildIndex(this.gpChats, 0);
			this.Controls.SetChildIndex(this.groupBox3, 0);
			this.Controls.SetChildIndex(this.groupBox4, 0);
			this.Controls.SetChildIndex(this.gpActiveChat, 0);
			this.gpChats.ResumeLayout(false);
			this.gpFriends.ResumeLayout(false);
			this.gpFriends.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.gpActiveChat.ResumeLayout(false);
			this.gpActiveChat.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvChats;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.ListView lvFriends;
		private System.Windows.Forms.ListBox lbServerLog;
		private System.Windows.Forms.Button btnCreateChat;
		private System.Windows.Forms.GroupBox gpChats;
		private System.Windows.Forms.GroupBox gpFriends;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RichTextBox txtActiveChat;
		private System.Windows.Forms.TextBox txtChatName;
		private System.Windows.Forms.GroupBox gpActiveChat;
		private System.Windows.Forms.ListView lvChatUser;
		private System.Windows.Forms.TextBox txtNewFriendUsername;
		private System.Windows.Forms.Button btnAddNewFriend;
	}
}

