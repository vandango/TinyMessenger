using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMessenger.Model.Service
{
	public class UserModel
	{
		public int UserId { get; set; }
		public string Username { get; set; }

		public User ToSimpleUser()
		{
			return new User()
			{
				UserId = this.UserId,
				Username = this.Username
			};
		}

		public override string ToString()
		{
			return string.Format(
				"{0} ({1})",
				this.Username,
				this.UserId
				);
		}
	}
}
