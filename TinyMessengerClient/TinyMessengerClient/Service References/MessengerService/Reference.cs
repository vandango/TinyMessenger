﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TinyMessengerClient.MessengerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageModel", Namespace="http://schemas.datacontract.org/2004/07/TinyMessenger.Model.Service")]
    [System.SerializableAttribute()]
    public partial class MessageModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid ChatIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime RequestTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TinyMessengerClient.MessengerService.UserModel UserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ChatId {
            get {
                return this.ChatIdField;
            }
            set {
                if ((this.ChatIdField.Equals(value) != true)) {
                    this.ChatIdField = value;
                    this.RaisePropertyChanged("ChatId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime RequestTime {
            get {
                return this.RequestTimeField;
            }
            set {
                if ((this.RequestTimeField.Equals(value) != true)) {
                    this.RequestTimeField = value;
                    this.RaisePropertyChanged("RequestTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TinyMessengerClient.MessengerService.UserModel User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserModel", Namespace="http://schemas.datacontract.org/2004/07/TinyMessenger.Model.Service")]
    [System.SerializableAttribute()]
    public partial class UserModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChatModel", Namespace="http://schemas.datacontract.org/2004/07/TinyMessenger.Model.Service")]
    [System.SerializableAttribute()]
    public partial class ChatModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<TinyMessengerClient.MessengerService.UserModel> AllUsersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid ChatIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<TinyMessengerClient.MessengerService.MessageModel> MessagesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NewMessageCounterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TinyMessengerClient.MessengerService.UserModel StartingUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<TinyMessengerClient.MessengerService.UserModel> TargetUsersField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<TinyMessengerClient.MessengerService.UserModel> AllUsers {
            get {
                return this.AllUsersField;
            }
            set {
                if ((object.ReferenceEquals(this.AllUsersField, value) != true)) {
                    this.AllUsersField = value;
                    this.RaisePropertyChanged("AllUsers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ChatId {
            get {
                return this.ChatIdField;
            }
            set {
                if ((this.ChatIdField.Equals(value) != true)) {
                    this.ChatIdField = value;
                    this.RaisePropertyChanged("ChatId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<TinyMessengerClient.MessengerService.MessageModel> Messages {
            get {
                return this.MessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.MessagesField, value) != true)) {
                    this.MessagesField = value;
                    this.RaisePropertyChanged("Messages");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NewMessageCounter {
            get {
                return this.NewMessageCounterField;
            }
            set {
                if ((this.NewMessageCounterField.Equals(value) != true)) {
                    this.NewMessageCounterField = value;
                    this.RaisePropertyChanged("NewMessageCounter");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TinyMessengerClient.MessengerService.UserModel StartingUser {
            get {
                return this.StartingUserField;
            }
            set {
                if ((object.ReferenceEquals(this.StartingUserField, value) != true)) {
                    this.StartingUserField = value;
                    this.RaisePropertyChanged("StartingUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<TinyMessengerClient.MessengerService.UserModel> TargetUsers {
            get {
                return this.TargetUsersField;
            }
            set {
                if ((object.ReferenceEquals(this.TargetUsersField, value) != true)) {
                    this.TargetUsersField = value;
                    this.RaisePropertyChanged("TargetUsers");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://TinyMessengerService.MessengerService", ConfigurationName="MessengerService.IMessengerService", CallbackContract=typeof(TinyMessengerClient.MessengerService.IMessengerServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IMessengerService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/Connect")]
        void Connect(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/Connect")]
        System.Threading.Tasks.Task ConnectAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/Disconnect")]
        void Disconnect(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/Disconnect")]
        System.Threading.Tasks.Task DisconnectAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/SendMessage")]
        void SendMessage(TinyMessengerClient.MessengerService.MessageModel message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(TinyMessengerClient.MessengerService.MessageModel message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestChat")]
        void RequestChat(TinyMessengerClient.MessengerService.UserModel user, System.Guid chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestChat")]
        System.Threading.Tasks.Task RequestChatAsync(TinyMessengerClient.MessengerService.UserModel user, System.Guid chatId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestMyChats")]
        void RequestMyChats(TinyMessengerClient.MessengerService.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestMyChats")]
        System.Threading.Tasks.Task RequestMyChatsAsync(TinyMessengerClient.MessengerService.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestMyFriends")]
        void RequestMyFriends(TinyMessengerClient.MessengerService.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestMyFriends")]
        System.Threading.Tasks.Task RequestMyFriendsAsync(TinyMessengerClient.MessengerService.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/CreateChat")]
        void CreateChat(TinyMessengerClient.MessengerService.ChatModel chat);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/CreateChat")]
        System.Threading.Tasks.Task CreateChatAsync(TinyMessengerClient.MessengerService.ChatModel chat);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/AddFriend")]
        void AddFriend(TinyMessengerClient.MessengerService.UserModel user, string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://TinyMessengerService.MessengerService/IMessengerService/AddFriend")]
        System.Threading.Tasks.Task AddFriendAsync(TinyMessengerClient.MessengerService.UserModel user, string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessengerServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/SendErrorResponse")]
        void SendErrorResponse(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/SendMessageRespons" +
            "e")]
        void SendMessageResponse(TinyMessengerClient.MessengerService.MessageModel message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/UserEnterResponse")]
        void UserEnterResponse(TinyMessengerClient.MessengerService.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/UserLeaveResponse")]
        void UserLeaveResponse(TinyMessengerClient.MessengerService.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestChatRespons" +
            "e")]
        void RequestChatResponse(TinyMessengerClient.MessengerService.ChatModel chat);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestMyChatsResp" +
            "onse")]
        void RequestMyChatsResponse(System.Collections.Generic.List<TinyMessengerClient.MessengerService.ChatModel> chats);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/RequestMyFriendsRe" +
            "sponse")]
        void RequestMyFriendsResponse(System.Collections.Generic.List<TinyMessengerClient.MessengerService.UserModel> friends);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://TinyMessengerService.MessengerService/IMessengerService/CreateChatResponse" +
            "")]
        void CreateChatResponse(TinyMessengerClient.MessengerService.ChatModel chat);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessengerServiceChannel : TinyMessengerClient.MessengerService.IMessengerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessengerServiceClient : System.ServiceModel.DuplexClientBase<TinyMessengerClient.MessengerService.IMessengerService>, TinyMessengerClient.MessengerService.IMessengerService {
        
        public MessengerServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public MessengerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public MessengerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MessengerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MessengerServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect(string username) {
            base.Channel.Connect(username);
        }
        
        public System.Threading.Tasks.Task ConnectAsync(string username) {
            return base.Channel.ConnectAsync(username);
        }
        
        public void Disconnect(string username) {
            base.Channel.Disconnect(username);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(string username) {
            return base.Channel.DisconnectAsync(username);
        }
        
        public void SendMessage(TinyMessengerClient.MessengerService.MessageModel message) {
            base.Channel.SendMessage(message);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(TinyMessengerClient.MessengerService.MessageModel message) {
            return base.Channel.SendMessageAsync(message);
        }
        
        public void RequestChat(TinyMessengerClient.MessengerService.UserModel user, System.Guid chatId) {
            base.Channel.RequestChat(user, chatId);
        }
        
        public System.Threading.Tasks.Task RequestChatAsync(TinyMessengerClient.MessengerService.UserModel user, System.Guid chatId) {
            return base.Channel.RequestChatAsync(user, chatId);
        }
        
        public void RequestMyChats(TinyMessengerClient.MessengerService.UserModel user) {
            base.Channel.RequestMyChats(user);
        }
        
        public System.Threading.Tasks.Task RequestMyChatsAsync(TinyMessengerClient.MessengerService.UserModel user) {
            return base.Channel.RequestMyChatsAsync(user);
        }
        
        public void RequestMyFriends(TinyMessengerClient.MessengerService.UserModel user) {
            base.Channel.RequestMyFriends(user);
        }
        
        public System.Threading.Tasks.Task RequestMyFriendsAsync(TinyMessengerClient.MessengerService.UserModel user) {
            return base.Channel.RequestMyFriendsAsync(user);
        }
        
        public void CreateChat(TinyMessengerClient.MessengerService.ChatModel chat) {
            base.Channel.CreateChat(chat);
        }
        
        public System.Threading.Tasks.Task CreateChatAsync(TinyMessengerClient.MessengerService.ChatModel chat) {
            return base.Channel.CreateChatAsync(chat);
        }
        
        public void AddFriend(TinyMessengerClient.MessengerService.UserModel user, string username) {
            base.Channel.AddFriend(user, username);
        }
        
        public System.Threading.Tasks.Task AddFriendAsync(TinyMessengerClient.MessengerService.UserModel user, string username) {
            return base.Channel.AddFriendAsync(user, username);
        }
    }
}