using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Model
{
	public class Chat
	{
		public string Name { get; set; }
		public Guid ChatId { get; set; }
		public User StartingUser { get; set; }
		public List<User> TargetUsers { get; set; }
		public List<Message> Messages { get; set; }

		//public List<User> AllUsers { get; set; }
		public List<User> AllUsersInternal
		{
			get
			{
				var list = new List<User>(TargetUsers);
				list.Insert(0, StartingUser);
				return list;
			}
		}

		public ChatModel ToChatModel()
		{
			return new ChatModel()
			{
				ChatId = this.ChatId,
				Name = this.Name,
				StartingUser = this.StartingUser.ToUserModel(),
				TargetUsers = this.ToTargetUsersPersonModelList(), 
				Messages = this.ToMessageModelList(),
				AllUsers = this.ToAllUsersPersonModelList()
			};
		}

		public List<UserModel> ToTargetUsersPersonModelList()
		{
			if (TargetUsers != null)
			{
				return TargetUsers.Select(u => new UserModel()
				{
					UserId = u.UserId, 
					Username = u.Username
				}).ToList();
			}

			return new List<UserModel>();
		}

		public List<UserModel> ToAllUsersPersonModelList()
		{
			if (AllUsersInternal != null)
			{
				return AllUsersInternal.Select(u => new UserModel()
				{
					UserId = u.UserId,
					Username = u.Username
				}).ToList();
			}

			return new List<UserModel>();
		}

		public List<MessageModel> ToMessageModelList()
		{
			if (Messages != null)
			{
				return Messages.Select(m => new MessageModel()
				{
					User = m.User.ToUserModel(), 
					RequestTime = m.RequestTime, 
					Text = m.Text
				}).ToList();
			}

			return new List<MessageModel>();
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

		internal bool ContainsUser(User user)
		{
			if (this.StartingUser.UserId == user.UserId)
			{
				return true;
			}

			if (this.TargetUsers.Any(u => u.UserId == user.UserId))
			{
				return true;
			}

			return false;
		}
	}
}
