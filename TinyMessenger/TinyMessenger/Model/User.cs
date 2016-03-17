using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Model
{
	public class User
	{
		public User()
		{
			Friends = new List<User>();
		}

		public int UserId { get; set; }
		public string Username { get; set; }
		public List<User> Friends { get; set; }
		public List<Chat> Chats { get; set; }
		public bool IsOnline { get; set; }

		public void AddFriend(User newFriend)
		{
			if (Friends.All(u => u.UserId != newFriend.UserId))
			{
				Friends.Add(newFriend);
			}
		}

		public UserModel ToUserModel()
		{
			return new UserModel()
			{
				UserId = this.UserId,
				Username = this.Username
			};
		}

		public List<UserModel> ToFriendsUserModelList()
		{
			if (Friends != null)
			{
				return Friends.Select(u => new UserModel()
				{
					UserId = u.UserId, 
					Username = u.Username
				}).ToList();
			}

			return new List<UserModel>();
		}

		public override string ToString()
		{
			return this.ToUserModel().ToString();
		}
	}
}
