using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Model
{
	public class Message
	{
		public DateTime RequestTime { get; set; }
		public string Text { get; set; }
		public User User { get; set; }
		public Guid ChatId { get; set; }

		public MessageModel ToMessageModel()
		{
			return new MessageModel()
			{
				ChatId = this.ChatId,
				RequestTime = this.RequestTime,
				Text = this.Text,
				User = this.User.ToUserModel()
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
