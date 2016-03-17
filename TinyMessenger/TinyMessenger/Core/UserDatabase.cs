using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger.Model;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Core
{
	public class UserDatabase
	{
		public static List<User> Database { get; set; }

		public static User GetById(int userId)
		{
			return Database.FirstOrDefault(u => u.UserId == userId);
		}

		public static User GetByName(string username)
		{
			return Database.FirstOrDefault(u => u.Username == username);
		}

		public static List<UserModel> GetFriends(User user)
		{
			UserDatabase.Init();

			var foundUser = Database.FirstOrDefault(u => u.UserId == user.UserId);

			return foundUser.ToFriendsUserModelList();
		}

		public static void Init()
		{
			if (Database == null || Database.Count == 0)
			{
				Database = new List<User>()
				{
					new User()
					{
						UserId = 1,
						Username = "schnulle",
						IsOnline = false
					},
					new User()
					{
						UserId = 2,
						Username = "tbussi",
						IsOnline = false
					},
					new User()
					{
						UserId = 3,
						Username = "hwurst",
						IsOnline = false
					},
					new User()
					{
						UserId = 4,
						Username = "keule",
						IsOnline = false
					},
					new User()
					{
						UserId = 5,
						Username = "kalle",
						IsOnline = false
					}
				};

				Database.FirstOrDefault(u => u.UserId == 1).Friends.Add(Database.FirstOrDefault(u => u.UserId == 2));
				Database.FirstOrDefault(u => u.UserId == 1).Friends.Add(Database.FirstOrDefault(u => u.UserId == 3));

				Database.FirstOrDefault(u => u.UserId == 2).Friends.Add(Database.FirstOrDefault(u => u.UserId == 1));
				Database.FirstOrDefault(u => u.UserId == 2).Friends.Add(Database.FirstOrDefault(u => u.UserId == 3));

				Database.FirstOrDefault(u => u.UserId == 3).Friends.Add(Database.FirstOrDefault(u => u.UserId == 1));
				Database.FirstOrDefault(u => u.UserId == 3).Friends.Add(Database.FirstOrDefault(u => u.UserId == 2));
			}
		}
	}
}
