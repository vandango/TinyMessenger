using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMessenger.Model.Service
{
	public class MessageModel
	{
		public DateTime RequestTime { get; set; }
		public string Text { get; set; }
		public UserModel User { get; set; }
		public Guid ChatId { get; set; }

		public Message ToMessage()
		{
			return new Message()
			{
				ChatId = this.ChatId,
				RequestTime = this.RequestTime,
				Text = this.Text,
				User = this.User.ToSimpleUser()
			};
		}

		public override string ToString()
		{
			return string.Format(
				"{0} - {1}: {2}",
				this.RequestTime,
				this.User.Username,
				this.Text
				);
		}
	}
}
