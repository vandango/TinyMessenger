using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyMessengerClient.Client;
using TinyMessengerClient.MessengerService;

namespace TinyMessengerClient
{
	public partial class MainForm : BaseLayoutForm
	{
		private MessengerServiceProxy _proxy;

		private UserModel CurrentUser { get; set; }

		public MainForm()
		{
			InitializeComponent();

			gpChats.Enabled = false;
			gpFriends.Enabled = false;
			gpActiveChat.Enabled = false;
		}

		void _proxy_ChatRequested(object sender, ChatModel chat)
		{
			if (chat != null)
			{
				lbServerLog.Invoke(() =>
				{
					AddServerLogMessage(FormsHelper.ChatString(chat) + " requested!", false);
					AddServerLogMessage("Id: " + chat.ChatId);
				});

				// add message to messageCounter and bold text
				foreach (ListViewItem item in lvChats.Items)
				{
					var chatItem = item.Tag as ChatModel;

					if (chatItem != null)
					{
						if (chatItem.ChatId == chat.ChatId)
						{
							chatItem.NewMessageCounter = 0;
							item.Font = new Font(item.Font, FontStyle.Regular);
							item.Text = FormsHelper.ChatNameString(chat);
							break;
						}
					}
				}

				txtActiveChat.Invoke(() =>
				{
					txtActiveChat.Text = string.Empty;
					txtActiveChat.SuspendLayout();

					txtActiveChat.Tag = chat;

					chat.Messages?.ForEach(message =>
					{
						FormsHelper.MessageString(txtActiveChat, message, CurrentUser);
					});

					txtActiveChat.ResumeLayout(true);
					txtActiveChat.Refresh();
					txtActiveChat.Update();
				});

				lbServerLog.Invoke(() =>
				{
					AddServerLogMessage($"{chat.TargetUsers?.Count} Freunde gefunden!");
				});

				lvChatUser.Invoke(() =>
				{
					lvChatUser.Items.Clear();

					lvChatUser.SuspendLayout();

					chat.TargetUsers?.ForEach(user =>
					{
						lvChatUser.Items.Add(new ListViewItem()
						{
							Text = FormsHelper.UserString(user),
							Tag = user
						});
					});

					if (lvChatUser.Items.Count > 0)
					{
						lvChatUser.Items[lvChatUser.Items.Count - 1].EnsureVisible();
					}
					lvChatUser.ResumeLayout(true);
					lvChatUser.Refresh();
					lvChatUser.Update();
				});

				gpActiveChat.Invoke(() =>
				{
					gpActiveChat.Enabled = true;
					gpActiveChat.Text = FormsHelper.ChatString(chat);
				});
			}
		}

		void _proxy_UserDisconnected(object sender, UserModel user)
		{
			if (user != null)
			{
				Disconnect(user);
			}
		}

		void _proxy_UserConnected(object sender, UserModel user, bool? loginSuccessfully)
		{
			if (user != null)
			{
				lbServerLog.Invoke(() =>
				{
					AddServerLogMessage(FormsHelper.UserString(user) + " connected!");
				});

				if (loginSuccessfully.HasValue
				    && loginSuccessfully.Value)
				{
					if (_proxy != null)
					{
						_proxy.RequestMyFriends();
						_proxy.RequestMyChats();

						if (user.Username == txtUsername.Text)
						{
							CurrentUser = user;
						}
					}
				}
			}
		}

		void _proxy_ChatsRequested(object sender, List<ChatModel> chats)
		{
			if (chats != null)
			{
				lbServerLog.Invoke(() =>
				{
					AddServerLogMessage(chats.Count.ToString() + " offene Chats gefunden!");
				});

				gpChats.Invoke(() =>
				{
					gpChats.Enabled = true;
				});

				lvChats.Invoke(() =>
				{
					lvChats.Items.Clear();

					lvChats.SuspendLayout();

					chats.ForEach(chat =>
					{
						lvChats.Items.Add(new ListViewItem()
						{
							Text = FormsHelper.ChatNameString(chat), 
							Tag = chat
						});
					});

					if (lvChatUser.Items.Count > 0)
					{
						lvChatUser.Items[lvChatUser.Items.Count - 1].EnsureVisible();
					}
					lvChats.ResumeLayout(true);
					lvChats.Refresh();
					lvChats.Update();
				});

				txtChatName.Text = $"New Chat {chats.Count + 1}";
			}
		}

		void _proxy_FriendsRequested(object sender, List<UserModel> friends)
		{
			if (friends != null)
			{
				lbServerLog.Invoke(() =>
				{
					AddServerLogMessage(friends.Count.ToString() + " Freunde gefunden!");
				});

				gpFriends.Invoke(() =>
				{
					gpFriends.Enabled = true;
				});

				lvFriends.Invoke(() =>
				{
					lvFriends.Items.Clear();

					lvFriends.SuspendLayout();

					friends.ForEach(user =>
					{
						lvFriends.Items.Add(new ListViewItem()
						{
							Text = FormsHelper.UserString(user),
							Tag = user
						});
					});

					if (lvFriends.Items.Count > 0)
					{
						lvFriends.Items[lvFriends.Items.Count - 1].EnsureVisible();
					}
					lvFriends.ResumeLayout(true);
					lvFriends.Refresh();
					lvFriends.Update();
				});
			}
		}

		void _proxy_Error(object sender, string message)
		{
			lbServerLog.Invoke(() =>
			{
				AddServerLogMessage("Fehler: " + message);
			});
		}

		void _proxy_ClientEvent(object sender, string message)
		{
			lbServerLog.Invoke(() =>
			{
				AddServerLogMessage("Client: " + message);
			});
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (btnConnect.Tag.ToString() == "CONNECT")
			{
				_proxy = new MessengerServiceProxy(txtUsername.Text);
				_proxy.ClientEvent += _proxy_ClientEvent;
				_proxy.Error += _proxy_Error;
				_proxy.MessageReceived += _proxy_MessageReceived;
				_proxy.UserConnected += _proxy_UserConnected;
				_proxy.UserDisconnected += _proxy_UserDisconnected;
				_proxy.ChatRequested += _proxy_ChatRequested;
				_proxy.FriendsRequested += _proxy_FriendsRequested;
				_proxy.ChatsRequested += _proxy_ChatsRequested;
				_proxy.ChatCreated += _proxy_ChatCreated;

				_proxy.Connect();

				btnConnect.Text = "Disconnect";
				btnConnect.Tag = "DISCONNECT";
			}
			else
			{
				if (_proxy.IsConnected 
					&& !_proxy.IsFaulted)
				{
					_proxy.Disconnect();
				}
				else
				{
					Disconnect();
				}

				_proxy = null;
			}
		}

		private void Disconnect(UserModel user = null)
		{
			btnConnect.Text = "Connect";
			btnConnect.Tag = "CONNECT";

			if (user == null)
			{
				user = CurrentUser;
			}

			lbServerLog.Invoke(() =>
			{
				AddServerLogMessage(FormsHelper.UserString(user) + " disconnected!");
			});

			lvChats.Invoke(() =>
			{
				lvChats.Items.Clear();
			});

			gpChats.Invoke(() =>
			{
				gpChats.Enabled = false;
			});

			lvFriends.Invoke(() =>
			{
				lvFriends.Items.Clear();
			});

			gpFriends.Invoke(() =>
			{
				gpFriends.Enabled = false;
			});

			lvChatUser.Invoke(() =>
			{
				lvChatUser.Items.Clear();
			});

			txtActiveChat.Invoke(() =>
			{
				txtActiveChat.Tag = null;
				txtActiveChat.Text = "";
			});

			txtMessage.Invoke(() =>
			{
				txtMessage.Text = "";
			});

			txtNewFriendUsername.Invoke(() =>
			{
				txtNewFriendUsername.Text = "";
			});

			gpActiveChat.Invoke(() =>
			{
				gpActiveChat.Text = "(No Chat selected)";
				gpActiveChat.Enabled = false;
			});

			CurrentUser = null;
		}

		void _proxy_ChatCreated(object sender, ChatModel chat)
		{
			if (chat != null)
			{
				lbServerLog.Invoke(() =>
				{
					AddServerLogMessage(FormsHelper.ChatString(chat) + " created!", false);
					AddServerLogMessage("Id: " + chat.ChatId);
				});

				gpChats.Invoke(() =>
				{
					gpChats.Enabled = true;
				});

				lvChats.Invoke(() =>
				{
					lvChats.SuspendLayout();
					
					lvChats.Items.Add(new ListViewItem()
					{
						Text = FormsHelper.ChatNameString(chat),
						Tag = chat
					});

					lvChats.Items[lvChats.Items.Count - 1].EnsureVisible();
					lvChats.ResumeLayout(true);
					lvChats.Refresh();
					lvChats.Update();
				});

				txtChatName.Text = $"New Chat {lvChats.Items.Count + 1}";

				txtActiveChat.Invoke(() =>
				{
					txtActiveChat.Text = string.Empty;
					txtActiveChat.SuspendLayout();

					txtActiveChat.Tag = chat;

					chat.Messages?.ForEach(message =>
					{
						FormsHelper.MessageString(txtActiveChat, message, CurrentUser);
					});

					txtActiveChat.ResumeLayout(true);
					txtActiveChat.Refresh();
					txtActiveChat.Update();
				});

				lbServerLog.Invoke(() =>
				{
					AddServerLogMessage($"{chat.TargetUsers?.Count} Freunde gefunden!");
				});

				lvChatUser.Invoke(() =>
				{
					lvChatUser.Items.Clear();

					lvChatUser.SuspendLayout();

					chat.TargetUsers?.ForEach(user =>
					{
						lvChatUser.Items.Add(new ListViewItem()
						{
							Text = FormsHelper.UserString(user),
							Tag = user
						});
					});

					lvChatUser.Items[lvChatUser.Items.Count - 1].EnsureVisible();
					lvChatUser.ResumeLayout(true);
					lvChatUser.Refresh();
					lvChatUser.Update();
				});

				gpActiveChat.Invoke(() =>
				{
					gpActiveChat.Enabled = true;
					gpActiveChat.Text = FormsHelper.ChatString(chat);
				});
			}
		}

		void _proxy_MessageReceived(object sender, MessageModel message)
		{
			lbServerLog.Invoke(() =>
			{
				AddServerLogMessage("Eingehende Nachricht für " + message.ChatId.ToString());
			});
			
			var chat = (ChatModel)txtActiveChat.Tag;

			if (chat != null 
				&& chat.ChatId == message.ChatId)
			{
				txtActiveChat.Invoke(() =>
				{
					txtActiveChat.SuspendLayout();

					FormsHelper.MessageString(txtActiveChat, message, CurrentUser);

					txtActiveChat.ResumeLayout(true);
					txtActiveChat.Refresh();
					txtActiveChat.Update();
				});

				txtMessage.Invoke(() =>
				{
					txtMessage.Text = "";
				});
			}
			else
			{
				// add message to messageCounter and bold text
				foreach (ListViewItem item in lvChats.Items)
				{
					if (item.Tag != null)
					{
						chat = item.Tag as ChatModel;
						if (chat != null)
						{
							if (chat.ChatId == message.ChatId)
							{
								if (chat.NewMessageCounter < 1)
								{
									chat.NewMessageCounter = 0;
								}

								chat.NewMessageCounter++;
								
								item.Font = new Font(item.Font, FontStyle.Bold);
								item.Text = FormsHelper.ChatNameString(chat);
							}
						}
					}
				}
			}
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			var chat = (ChatModel) txtActiveChat.Tag;

			_proxy.SendMessage(
				chat.ChatId,
				txtMessage.Text
				);
		}

		private void lvChats_DoubleClick(object sender, EventArgs e)
		{
			var chat = FormsHelper.GetSelectedItem<ChatModel>(lvChats);

			if (chat != null)
			{
				_proxy.RequestChat(chat.ChatId);
			}
		}

		private void btnCreateChat_Click(object sender, EventArgs e)
		{
			if (CurrentUser == null)
			{
				AddServerLogMessage("Please login first!");
				return;
			}

			_proxy.CreateChat(new ChatModel()
			{
				ChatId = _proxy.NewChatId,
				StartingUser = CurrentUser,
				TargetUsers = FormsHelper.GetSelectedItems<UserModel>(lvFriends).ToList(),
				Name = txtChatName.Text
			});

			txtChatName.Invoke(() =>
			{
				txtChatName.Text = "";
			});
		}

		private void txtActiveChat_TextChanged(object sender, EventArgs e)
		{
			// Set the current caret position at the end
			txtActiveChat.SelectionStart = txtActiveChat.Text.Length;
			// Now scroll it automatically
			txtActiveChat.ScrollToCaret();
		}

		private void txtMessage_KeyDown(object sender, KeyEventArgs e)
		{
			//AddServerLogMessage($"Alt: {e.Alt} | Key: {e.KeyData} | Key: {e.KeyCode}");

			if (e.Alt && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter))
			{
				var chat = (ChatModel)txtActiveChat.Tag;

				_proxy.SendMessage(
					chat.ChatId,
					txtMessage.Text
					);
			}
		}

		private void AddServerLogMessage(string message, bool scrollDown = true)
		{
			lbServerLog.Items.Add(message);

			if (scrollDown)
			{
				lbServerLog.ScrollAlwaysVisible = true;
			}
		}

		private void btnAddNewFriend_Click(object sender, EventArgs e)
		{
			_proxy.AddFriend(CurrentUser, txtNewFriendUsername.Text);

			txtNewFriendUsername.Invoke(() =>
			{
				txtNewFriendUsername.Text = "";
			});
		}
	}
}
