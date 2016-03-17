using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using TinyMessenger.Model.Service;

namespace TinyMessenger.Services.MessengerServiceImpl
{
	[ServiceContract(Namespace = "http://TinyMessengerService.MessengerService", 
		SessionMode = SessionMode.Required,
		CallbackContract = typeof(IMessengerServiceCallback)
		)]
	public interface IMessengerService
	{
		[OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
		void Connect(string username);

		[OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
		void Disconnect(string username);

		[OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
		void SendMessage(MessageModel message);

		[OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
		void RequestChat(UserModel user, Guid chatId);

		[OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
		void RequestMyChats(UserModel user);

		[OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
		void RequestMyFriends(UserModel user);

		[OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
		void CreateChat(ChatModel chat);

		[OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
		void AddFriend(UserModel user, string username);
	}
}
