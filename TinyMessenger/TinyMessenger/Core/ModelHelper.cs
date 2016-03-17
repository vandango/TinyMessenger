using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger.Model;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Core
{
	public static class ModelHelper
	{
		public static List<ChatModel> ToChatModelList(List<Chat> chatList)
		{
			return chatList.Select(c => c.ToChatModel()).ToList();
		}
	}
}
