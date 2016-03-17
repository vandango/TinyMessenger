using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessengerClient.MessengerService;

namespace TinyMessengerClient.Client.CallbackHandler
{
	public class MessengerServiceCallbackHandler : IMessengerServiceCallback
	{
		private readonly Func<string, bool> _onSendErrorResponse;
		private readonly Func<MessageModel, bool> _onSendMessageResponse;
		private readonly Func<UserModel, bool> _onUserEnterResponse;
		private readonly Func<UserModel, bool> _onUserLeaveResponse;
		private readonly Func<ChatModel, bool> _onRequestChatResponse;
		private readonly Func<List<UserModel>, bool> _onRequestMyFriendsResponse;
		private readonly Func<List<ChatModel>, bool> _onRequestMyChatsResponse;
		private readonly Func<ChatModel, bool> _onCreateChatResponse;

		public MessengerServiceCallbackHandler(
			Func<string, bool> onSendErrorResponse,
			Func<MessageModel, bool> onSendMessageResponse,
			Func<UserModel, bool> onUserEnterResponse,
			Func<UserModel, bool> onUserLeaveResponse,
			Func<ChatModel, bool> onRequestChatResponse,
			Func<List<UserModel>, bool> onRequestMyFriendsResponse,
			Func<List<ChatModel>, bool> onRequestMyChatsResponse,
			Func<ChatModel, bool> onCreateMyChatsResponse
			)
		{
			this._onSendErrorResponse = onSendErrorResponse;
			this._onSendMessageResponse = onSendMessageResponse;
			this._onUserEnterResponse = onUserEnterResponse;
			this._onUserLeaveResponse = onUserLeaveResponse;
			this._onRequestChatResponse = onRequestChatResponse;
			this._onRequestMyFriendsResponse = onRequestMyFriendsResponse;
			this._onRequestMyChatsResponse = onRequestMyChatsResponse;
			this._onCreateChatResponse = onCreateMyChatsResponse;
		}

		public void SendErrorResponse(string message)
		{
			this._onSendErrorResponse(message);
		}

		public void SendMessageResponse(MessageModel message)
		{
			this._onSendMessageResponse(message);
		}

		public void UserEnterResponse(UserModel user)
		{
			this._onUserEnterResponse(user);
		}

		public void UserLeaveResponse(UserModel user)
		{
			this._onUserLeaveResponse(user);
		}

		public void RequestChatResponse(ChatModel chat)
		{
			this._onRequestChatResponse(chat);
		}

		public void RequestMyFriendsResponse(List<UserModel> friends)
		{
			this._onRequestMyFriendsResponse(friends);
		}

		public void RequestMyChatsResponse(List<ChatModel> chats)
		{
			this._onRequestMyChatsResponse(chats);
		}

		public void CreateChatResponse(ChatModel chat)
		{
			this._onCreateChatResponse(chat);
		}
	}
}
