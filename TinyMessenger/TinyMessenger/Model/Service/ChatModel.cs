using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMessenger.Model.Service
{
	public class ChatModel
	{
		public string Name { get; set; }
		public Guid ChatId { get; set; }
		public UserModel StartingUser { get; set; }
		public List<UserModel> TargetUsers { get; set; }
		public List<MessageModel> Messages { get; set; }
		public int NewMessageCounter { get; set; }

		public List<UserModel> AllUsers { get; set; }

		public Chat ToChat()
		{
			var chat = new Chat()
			{
				ChatId = this.ChatId,
				Name = this.Name,
				StartingUser = this.StartingUser.ToSimpleUser(),
				TargetUsers = new List<User>(),
				Messages = new List<Message>()
			};

			this.TargetUsers?.ForEach(u =>
			{
				chat.TargetUsers.Add(u.ToSimpleUser());
			});

			this.Messages?.ForEach(m =>
			{
				chat.Messages.Add(m.ToMessage());
			});

			return chat;
		}

		public List<UserModel> ToAllUsers()
		{
			if (AllUsers != null && AllUsers.Count > 0)
			{
				return AllUsers;
			}
			else
			{
				var list = new List<UserModel>();
				if (TargetUsers != null)
				{
					list.AddRange(TargetUsers);
				}
				list.Insert(0, StartingUser);
				return list;
			}
		}

		public override string ToString()
		{
			string users = string.Join(
				", ",
				this.TargetUsers.Select(p => p.Username).ToList()
				);

			return string.Format(
				"{0} by {1}",
				this.Name ?? users,
				this.StartingUser.Username
				);
		}
	}
}
