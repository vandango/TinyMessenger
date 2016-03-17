using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Services.MessengerServiceImpl
{
	public interface IMessengerServiceCallback
	{
		[OperationContract(IsOneWay = true)]
		void SendErrorResponse(string message);

		[OperationContract(IsOneWay = true)]
		void SendMessageResponse(MessageModel message);

		[OperationContract(IsOneWay = true)]
		void UserEnterResponse(UserModel user);

		[OperationContract(IsOneWay = true)]
		void UserLeaveResponse(UserModel user);

		[OperationContract(IsOneWay = true)]
		void RequestChatResponse(ChatModel chat);

		[OperationContract(IsOneWay = true)]
		void RequestMyChatsResponse(List<ChatModel> chats);

		[OperationContract(IsOneWay = true)]
		void RequestMyFriendsResponse(List<UserModel> friends);

		[OperationContract(IsOneWay = true)]
		void CreateChatResponse(ChatModel chat);
	}
}
