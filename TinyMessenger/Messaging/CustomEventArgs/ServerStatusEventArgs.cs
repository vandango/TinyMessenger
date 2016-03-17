using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vandango.Messaging.Enums;

namespace vandango.Messaging.CustomEventArgs
{
	/// <summary>
	/// Provides data for the ServerStatus event
	/// </summary>
	public class ServerStatusEventArgs : EventArgs
	{
		#region =============== constructors ===============================

		/// <summary>
		/// Erzeugt eine neue Instanz dieser Klasse
		/// </summary>
		public ServerStatusEventArgs()
		{
		}

		/// <summary>
		/// Erzeugt eine neue Instanz dieser Klasse anhand der angegebenen Parameter
		/// </summary>
		/// <param name="newState">Aktueller Status des Jobs</param>
		public ServerStatusEventArgs(ServerStatus newState)
		{
			this.Status = newState;
		}

		#endregion

		#region =============== properties =================================

		/// <summary>
		/// Aktueller Status des Jobs
		/// </summary>
		public ServerStatus Status { get; set; }

		#endregion
	}
}
