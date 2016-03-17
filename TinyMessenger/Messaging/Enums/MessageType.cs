using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vandango.Messaging.Enums
{
	/// <summary>
	/// Message type
	/// </summary>
	public enum MessageType
	{
		/// <summary>
		/// The type of the message is unknown, this is default
		/// </summary>
		Unknown,
		/// <summary>
		/// The message contains simple information
		/// </summary>
		Information,
		/// <summary>
		/// The message contains log information
		/// </summary>
		LogInformation,
		/// <summary>
		/// The message contains warning information
		/// </summary>
		Warning,
		/// <summary>
		/// The message contains error information
		/// </summary>
		Error
	}
}
