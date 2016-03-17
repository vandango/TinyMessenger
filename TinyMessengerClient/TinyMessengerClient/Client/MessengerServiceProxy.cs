using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TinyMessengerClient.Client.CallbackHandler;
using TinyMessengerClient.Client.ClientEventArgs;
using TinyMessengerClient.MessengerService;

namespace TinyMessengerClient.Client
{
	public class MessengerServiceProxy
	{
		public delegate void UserConnectedEventHandler(object sender, UserModel user, bool? loginSuccessfully);
		public event UserConnectedEventHandler UserConnected;

		public delegate void UserDisconnectedEventHandler(object sender, UserModel user);
		public event UserDisconnectedEventHandler UserDisconnected;

		public delegate void ChatRequestedEventHandler(object sender, ChatModel chat);
		public event ChatRequestedEventHandler ChatRequested;

		public delegate void FriendsRequestedEventHandler(object sender, List<UserModel> friends);
		public event FriendsRequestedEventHandler FriendsRequested;

		public delegate void ChatsRequestedEventHandler(object sender, List<ChatModel> chats);
		public event ChatsRequestedEventHandler ChatsRequested;

		public delegate void ErrorEventHandler(object sender, string message);
		public event ErrorEventHandler Error;

		public delegate void MessageEventHandler(object sender, MessageModel message);
		public event MessageEventHandler MessageReceived;

		public delegate void ClientEventHandler(object sender, string message);
		public event ClientEventHandler ClientEvent;

		public delegate void ChatCreatedEventHandler(object sender, ChatModel chat);
		public event ChatCreatedEventHandler ChatCreated;

		private MessengerServiceClient _messengerServiceClient = null;

		public bool IsConnected { get; private set; }
		public bool IsFaulted => this._messengerServiceClient.State == CommunicationState.Faulted;
		public UserModel CurrentUser { get; private set; }
		public Guid NewChatId => Guid.NewGuid();

		private string _username;

		public MessengerServiceProxy(string username)
		{
			this._username = username;

			this.ConnectToService();
		}

		public void Connect()
		{
			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.Connect(this._username);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void Disconnect()
		{
			if (!this.IsConnected)
			{
				// TODO: implement to all methods
			}

			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.Disconnect(this.CurrentUser.Username);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void SendMessage(Guid chatId, string message)
		{
			if (!this.IsConnected)
			{
				// TODO: implement to all methods
			}

			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.SendMessage(new MessageModel()
				{
					ChatId = chatId, 
					Text = message, 
					User = this.CurrentUser, 
					RequestTime = DateTime.Now
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void CreateChat(ChatModel chat)
		{
			if (!this.IsConnected)
			{
				// TODO: implement to all methods
			}

			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.CreateChat(chat);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void RequestChat(Guid chatId)
		{
			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.RequestChat(this.CurrentUser, chatId);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void RequestMyFriends()
		{
			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.RequestMyFriends(this.CurrentUser);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void RequestMyChats()
		{
			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.RequestMyChats(this.CurrentUser);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		public void AddFriend(UserModel user, string username)
		{
			if (this._messengerServiceClient.State == CommunicationState.Faulted)
			{
				this.ConnectToService(true);
			}

			try
			{
				this._messengerServiceClient.AddFriend(this.CurrentUser, username);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		/*
			RESPONSES
		*/
		private bool SendErrorResponse(string message)
		{
			if (this._messengerServiceClient != null)
			{
				if (this.Error != null)
				{
					this.Error(this, message);
				}

				return true;
			}

			return false;
		}

		private bool SendMessageResponse(MessageModel message)
		{
			if (this._messengerServiceClient != null)
			{
				if (this.MessageReceived != null)
				{
					this.MessageReceived(this, message);
				}

				return true;
			}

			return false;
		}

		private bool UserEnterResponse(UserModel user)
		{
			if (this._messengerServiceClient != null)
			{
				bool? loginSuccessfully = null;

				if (user != null
				    && this._username == user.Username)
				{
					this.CurrentUser = user;
					this.IsConnected = true;
					loginSuccessfully = true;
				}

				if (this.UserConnected != null)
				{
					this.UserConnected(this, user, loginSuccessfully);
				}

				return true;
			}

			return false;
		}

		private bool UserLeaveResponse(UserModel user)
		{
			if (this._messengerServiceClient != null)
			{
				if (this.UserDisconnected != null)
				{
					this.UserDisconnected(this, user);
				}

				return true;
			}

			return false;
		}

		private bool RequestChatResponse(ChatModel chat)
		{
			if (this._messengerServiceClient != null)
			{
				if (this.ChatRequested != null)
				{
					this.ChatRequested(this, chat);
				}

				return true;
			}

			return false;
		}

		private bool RequestMyFriendsResponse(List<UserModel> friends)
		{
			if (this._messengerServiceClient != null)
			{
				if (this.FriendsRequested != null)
				{
					this.FriendsRequested(this, friends);
				}

				return true;
			}

			return false;
		}

		private bool RequestMyChatsResponse(List<ChatModel> chats)
		{
			if (this._messengerServiceClient != null)
			{
				if (this.ChatsRequested != null)
				{
					this.ChatsRequested(this, chats);
				}

				return true;
			}

			return false;
		}

		private bool CreateChatResponse(ChatModel chat)
		{
			if (this._messengerServiceClient != null)
			{
				if (this.ChatCreated != null)
				{
					this.ChatCreated(this, chat);
				}

				return true;
			}

			return false;
		}

		private void Abort()
		{
			this._messengerServiceClient.Abort();
			this._messengerServiceClient = null;
		}

		private void ConnectToService(bool abortFirst = false)
		{
			if (abortFirst)
			{
				this.Abort();
			}

			int count = 1;

			do
			{
				if (this.ClientEvent != null)
				{
					this.ClientEvent(this, string.Concat("Reconnect try #", count));
				}

				try
				{
					this._messengerServiceClient = new MessengerServiceClient(
						new InstanceContext(new MessengerServiceCallbackHandler(
							SendErrorResponse,
							SendMessageResponse,
							UserEnterResponse,
							UserLeaveResponse,
							RequestChatResponse,
							RequestMyFriendsResponse,
							RequestMyChatsResponse,
							CreateChatResponse
							))
						);
					this._messengerServiceClient.ChannelFactory.Faulted += ChannelFactory_Faulted;

					count = 11;
				}
				catch
				{
				}

				System.Threading.Thread.Sleep(1000);

				count++;
			} while (count <= 10);
		}

		private void ChannelFactory_Faulted(object sender, EventArgs e)
		{
			this.ConnectToService(true);
		}
	}
}
