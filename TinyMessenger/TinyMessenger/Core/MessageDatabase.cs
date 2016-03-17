using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vandango.Messaging;
using TinyMessenger.Model;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Core
{
	public static class MessageDatabase
	{
		private static Object syncObj = new Object();

		private static List<Chat> Database { get; set; }

		static MessageDatabase()
		{
			Init();
		}

		public static Chat AddChat(ChatModel model)
		{
			lock (syncObj)
			{
				if (Database != null && Database.Count > 0)
				{
					var chat = model.ToChat();
					Database.Add(chat);

					MessageBroker.InternalLogMessage($"Added: {model.Name} - {model.ChatId}");

					return chat;
				}

				return null;
			}
		}

		public static void AddMessage(MessageModel message)
		{
			var chat = MessageDatabase.GetChat(message.ChatId);
			chat.Messages.Add(message.ToMessage());

			Console.WriteLine(message.ToString());
		}

		public static Chat GetChat(Guid chatId)
		{
			return Database.FirstOrDefault(c => c.ChatId == chatId);
		}

		public static List<Chat> GetChats(User user)
		{
			var chats = Database.Where(chat =>
				chat.StartingUser.UserId == user.UserId
				|| chat.TargetUsers.Any(users => users.UserId == user.UserId)
				).ToList();

			return chats;
		}

		public static void Init()
		{
			lock (syncObj)
			{
				if (Database != null && Database.Count > 0)
				{
					return;
				}

				Database = new List<Chat>()
				{
					new Chat()
					{
						Name = "Alle drei",
						ChatId = Guid.NewGuid(),
						StartingUser = UserDatabase.GetById(1),
						TargetUsers = new List<User>()
						{
							UserDatabase.GetById(2),
							UserDatabase.GetById(3)
						},
						Messages = new List<Message>()
						{
							new Message()
							{
								RequestTime = new DateTime(2015, 3, 12, 17, 45, 56),
								User = UserDatabase.GetById(1),
								Text = "Moin"
							},
							new Message()
							{
								RequestTime = new DateTime(2015, 3, 13, 10, 30, 1),
								User = UserDatabase.GetById(2),
								Text = "Gude"
							},
							new Message()
							{
								RequestTime = new DateTime(2015, 3, 13, 10, 30, 15),
								User = UserDatabase.GetById(3),
								Text = "Hi Leute"
							},
							new Message()
							{
								RequestTime = new DateTime(2015, 3, 13, 10, 30, 45),
								User = UserDatabase.GetById(1),
								Text = "Meeting um 11h?"
							}
						}
					},
					new Chat()
					{
						Name = "Mit Marco",
						ChatId = Guid.NewGuid(),
						StartingUser = UserDatabase.GetById(1),
						TargetUsers = new List<User>()
						{
							UserDatabase.GetById(2)
						},
						Messages = new List<Message>()
						{
							new Message()
							{
								RequestTime = new DateTime(2015, 3, 13, 9, 15, 12),
								User = UserDatabase.GetById(1),
								Text = "Hi Marco"
							}
						}
					}
				};

				foreach (var chat in Database)
				{
					MessageBroker.InternalLogMessage($"{chat.Name} - {chat.ChatId}");
				}
			}
		}
	}
}
