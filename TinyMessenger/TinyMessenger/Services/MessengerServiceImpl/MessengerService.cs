using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using vandango.Messaging;
using TinyMessenger.Core;
using TinyMessenger.Model;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Services.MessengerServiceImpl
{
	[ServiceBehavior(
		ConcurrencyMode = ConcurrencyMode.Multiple,
		InstanceContextMode = InstanceContextMode.PerSession
		)]
	public class MessengerService : IMessengerService
	{
		//thread sync lock object
		private static Object syncObj = new Object();

		public delegate void ChatEventHandler(object sender, User userFromList, ChatEventArgs e);
		public static event ChatEventHandler ChatEvent;
		private ChatEventHandler myEventHandler = null;

		private IMessengerServiceCallback _callback = null;

		private static Dictionary<User, ChatEventHandler> _chatters = new Dictionary<User, ChatEventHandler>();
		private User _user;



		public MessengerService()
		{

			//this._callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();
		}



		public void Disconnect(string username)
		{
			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

			var user = UserDatabase.GetByName(username);

			if (user == null)
			{
				_callback.SendErrorResponse("User not found in database!");
			}
			else
			{
				MessageBroker.InternalLogMessage("User " + username + " disconnected in");

				_callback.UserLeaveResponse(user.ToUserModel());
			}
		}

		public void Connect(string username)
		{
			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

			var user = UserDatabase.GetByName(username);

			if (user == null)
			{
				_callback.SendErrorResponse("User not found in database!");
			}
			else
			{
				bool userAdded = false;

				//create a new ChatEventHandler delegate, pointing to the MyEventHandler() method
				myEventHandler = new ChatEventHandler(MyEventHandler);

				//carry out a critical section that checks to see if the new chatter
				//name is already in use, if its not allow the new chatter to be
				//added to the list of chatters, using the person as the key, and the
				//ChatEventHandler delegate as the value, for later invocation
				lock (syncObj)
				{
					if (CheckIfUserIsOnline(username))
					{
						_chatters.Remove(GetOnlineUser(username));
					}

					this._user = user;
					_chatters.Add(user, MyEventHandler);

					userAdded = true;
				}

				if (userAdded)
				{
					_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

					BroadcastMessage(new ChatEventArgs
					{
						MessageType = MessageType.UserEnter,
						User = user.ToUserModel()
					});

					//add this newly joined chatters ChatEventHandler delegate, to the global
					//multicast delegate for invocation
					ChatEvent += myEventHandler;

					//return AddUserIsOnlineState(UserDatabase.GetFriends(user));

					MessageBroker.InternalLogMessage("User " + username + " connected");

					_callback.UserEnterResponse(user.ToUserModel());
				}
				else
				{
					_callback.SendErrorResponse("User could not be logged in to server!");
				}
			}
		}

		public void SendMessage(MessageModel message)
		{
			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();
			
			var user = UserDatabase.GetByName(message.User.Username);

			if (user == null)
			{
				_callback.SendErrorResponse("User not found in database!");
			}
			else
			{
				var chat = MessageDatabase.GetChat(message.ChatId);

				if (chat == null)
				{
					_callback.SendErrorResponse("Chat not found in database!");
				}
				else
				{
					MessageDatabase.AddMessage(message);
					
					BroadcastMessage(new ChatEventArgs
					{
						MessageType = MessageType.Receive,
						User = user.ToUserModel(),
						Message = message.ToMessage()
					});
				}
			}
		}

		public void CreateChat(ChatModel chat)
		{
			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

			var createdChat = MessageDatabase.AddChat(chat);

			MessageBroker.InternalLogMessage("Chat " + createdChat.ToString() + " created by " + createdChat.StartingUser.Username + ":");
			
			BroadcastMessage(new ChatEventArgs
			{
				MessageType = MessageType.ChatOpen,
				Users = chat.ToAllUsers(),
				Chat = chat
			});
			
			if (createdChat == null)
			{
				_callback.SendErrorResponse("Chat not found in database!");
			}
			else
			{
				if (!createdChat.ContainsUser(chat.StartingUser.ToSimpleUser()))
				{
					_callback.SendErrorResponse("Chat is not related to user!");
				}

				MessageBroker.InternalLogMessage("Created chat " + chat.ToString() + " requested by " + chat.StartingUser.Username + ":");

				_callback.RequestChatResponse(chat);
			}
		}

		public void RequestChat(UserModel user, Guid chatId)
		{
			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

			var chat = MessageDatabase.GetChat(chatId);
			
			if (chat == null)
			{
				_callback.SendErrorResponse("Chat not found in database!");
			}
			else
			{
				if (!chat.ContainsUser(user.ToSimpleUser()))
				{
					_callback.SendErrorResponse("Chat is not related to user!");
				}

				MessageBroker.InternalLogMessage("Chat " + chat.ToString() + " requested by " + user.Username + ":");

				_callback.RequestChatResponse(chat.ToChatModel());
			}
		}
		
		public void RequestMyFriends(UserModel user)
		{
			if (user == null)
			{
				return;
			}

			var friends = UserDatabase.GetFriends(user.ToSimpleUser());

			MessageBroker.InternalLogMessage("Friends requested by " + user.Username + ":");

			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

			if (friends == null)
			{
				_callback.SendErrorResponse("No user in database found!");
			}
			else
			{
				friends.ForEach(friend =>
				{
					MessageBroker.InternalLogMessage("- " + friend.ToString());
				});

				_callback.RequestMyFriendsResponse(friends);
			}
		}
		
		public void RequestMyChats(UserModel user)
		{
			var chats = MessageDatabase.GetChats(user.ToSimpleUser());

			MessageBroker.InternalLogMessage("Chats requested by " + user.Username + ":");
			
			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

			if (chats == null)
			{
				_callback.SendErrorResponse("No chats in database found!");
			}
			else
			{
				chats.ForEach(chat =>
				{
					MessageBroker.InternalLogMessage("- " + chat.ToString());
				});

				_callback.RequestMyChatsResponse(ModelHelper.ToChatModelList(chats));
			}
		}
		
		public void AddFriend(UserModel user, string username)
		{
			if (user == null)
			{
				return;
			}

			var me = UserDatabase.GetById(user.UserId);
			if (me == null)
			{
				_callback.SendErrorResponse("Your account is broken!");
			}

			var newFriend = UserDatabase.GetByName(username);
			if (newFriend == null)
			{
				_callback.SendErrorResponse($"No user with name {username} found!");
				return;
			}

			me.AddFriend(newFriend);
			newFriend.AddFriend(me);

			var friends = UserDatabase.GetFriends(user.ToSimpleUser());

			MessageBroker.InternalLogMessage("Friends requested by " + user.Username + ":");

			_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

			if (friends == null)
			{
				_callback.SendErrorResponse("No user in database found!");
				return;
			}
			else
			{
				friends.ForEach(friend =>
				{
					MessageBroker.InternalLogMessage("- " + friend.ToString());
				});

				//_callback.RequestMyFriendsResponse(friends);

				//_callback = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();

				BroadcastMessage(new ChatEventArgs
				{
					MessageType = MessageType.FriendAdded,
					Users = new List<UserModel>()
					{
						me.ToUserModel(), newFriend.ToUserModel()
					}
				});

				//BroadcastMessage(new ChatEventArgs
				//{
				//	MessageType = MessageType.FriendAdded,
				//	User = newFriend.ToUserModel()
				//});

				////add this newly joined chatters ChatEventHandler delegate, to the global
				////multicast delegate for invocation
				//ChatEvent += myEventHandler;
			}
		}






		private bool CheckIfUserIsOnline(string username)
		{
			return _chatters.Keys.Any(user => user.Username == username);
		}

		private User GetOnlineUser(string username)
		{
			return _chatters.Keys.FirstOrDefault(user => user.Username == username);
		}






		/// <summary>
		/// This method is called when ever one of the chatters
		/// ChatEventHandler delegates is invoked. When this method
		/// is called it will examine the events ChatEventArgs to see
		/// what type of message is being broadcast, and will then
		/// call the correspoding method on the clients callback interface
		/// </summary>
		/// <param name="sender">the sender, which is not used</param>
		/// <param name="userFromList"></param>
		/// <param name="e">The ChatEventArgs</param>
		private void MyEventHandler(object sender, User userFromList, ChatEventArgs e)
		{
			try
			{
				User user = null;

				switch (e.MessageType)
				{
					case MessageType.Receive:
						_callback.SendMessageResponse(e.Message.ToMessageModel());
						break;
					case MessageType.ChatOpen:
						_callback.CreateChatResponse(e.Chat);
						break;
					case MessageType.UserEnter:
						_callback.UserEnterResponse(e.User);
						break;
					case MessageType.UserLeave:
						_callback.UserLeaveResponse(e.User);
						break;
					case MessageType.FriendAdded:
						user = UserDatabase.GetById(userFromList?.UserId ?? e.User.UserId);
						_callback.RequestMyFriendsResponse(user?.Friends.Select(u => u.ToUserModel()).ToList());
						break;
				}
			}
			catch
			{
				//Leave();
			}
		}

		private void BroadcastMessage(ChatEventArgs e)
		{
			if (e.Users != null && e.Users.Count > 0)
			{
				e.Users.ForEach(user =>
				{
					var key = _chatters.Keys.FirstOrDefault(u => u.UserId == user.UserId);

					if (key != null)
					{
						_chatters[key].BeginInvoke(this, user.ToSimpleUser(), e, new AsyncCallback(EndAsync), null);
					}
				});
			}
			else
			{
				ChatEventHandler temp = ChatEvent;

				//loop through all connected chatters and invoke their 
				//ChatEventHandler delegate asynchronously, which will firstly call
				//the MyEventHandler() method and will allow a asynch callback to call
				//the EndAsync() method on completion of the initial call
				if (temp != null)
				{
					foreach (ChatEventHandler handler in temp.GetInvocationList())
					{
						handler.BeginInvoke(this, null, e, new AsyncCallback(EndAsync), null);
					}
				}
			}
		}

		/// <summary>
		/// Is called as a callback from the asynchronous call, so simply get the
		/// delegate and do an EndInvoke on it, to signal the asynchronous call is
		/// now completed
		/// </summary>
		/// <param name="ar">The asnch result</param>
		private void EndAsync(IAsyncResult ar)
		{
			ChatEventHandler d = null;

			try
			{
				//get the standard System.Runtime.Remoting.Messaging.AsyncResult,and then
				//cast it to the correct delegate type, and do an end invoke
				System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
				d = ((ChatEventHandler)asres.AsyncDelegate);
				d.EndInvoke(ar);
			}
			catch
			{
				ChatEvent -= d;
			}
		}
	}
}
