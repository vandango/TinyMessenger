using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vandango.Messaging.Enums;

namespace vandango.Messaging.CustomEventArgs
{
	/// <summary>
	/// Provides data for the Message event
	/// </summary>
	/// <remarks>MessageEvents are server internal messages, i.e. errors and warnings</remarks>
	public class MessageEventArgs : EventArgs
	{
		#region =============== constructors ===============================

		/// <summary>
		/// Creates new instance of this class
		/// </summary>
		public MessageEventArgs()
		{
		}

		/// <summary>
		/// Creates new instance of this class with the mentioned parameters
		/// </summary>
		/// <param name="msg">Message text</param>
		public MessageEventArgs(string msg)
		{
			this.Message = msg;
			this.Type = MessageType.Unknown;
		}

		/// <summary>
		/// Creates new instance of this class with the mentioned parameters
		/// </summary>
		/// <param name="msg">Message text</param>
		/// <param name="type">The type of the message</param>
		public MessageEventArgs(string msg, MessageType type)
		{
			this.Message = msg;
			this.Type = type;
		}

		/// <summary>
		/// Creates new instance of this class with the mentioned parameters
		/// </summary>
		/// <param name="msg">Message text</param>
		/// <param name="ex">Exception</param>
		public MessageEventArgs(string msg, Exception ex)
			: this(msg)
		{

			this.InternalException = ex;
		}

		/// <summary>
		/// Creates new instance of this class with the mentioned parameters
		/// </summary>
		/// <param name="msg">Message text</param>
		/// <param name="ex">Exception</param>
		/// <param name="type">The type of the message</param>
		public MessageEventArgs(string msg, Exception ex, MessageType type)
			: this(msg, type)
		{

			this.InternalException = ex;
		}

		#endregion

		#region =============== properties =================================

		/// <summary>
		/// Exception
		/// </summary>
		public Exception InternalException { get; set; }

		/// <summary>
		/// Message text
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Message type
		/// </summary>
		public MessageType Type { get; set; }

		#endregion
	}
}
