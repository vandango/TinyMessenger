using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Model
{
	public class ChatEventArgs : EventArgs
	{
		public MessageType MessageType { get; set; }
		public ChatModel Chat { get; set; }
		public UserModel User { get; set; }
		public List<UserModel> Users { get; set; }
		public Message Message { get; set; }
	}
}
