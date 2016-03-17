using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMessenger.Model
{
	public enum MessageType
	{
		Receive, 
		UserEnter, 
		UserLeave, 
		ChatOpen,
		FriendAdded
	};
}
