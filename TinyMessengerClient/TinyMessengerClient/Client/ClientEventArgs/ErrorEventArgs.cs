using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessengerClient.MessengerService;

namespace TinyMessengerClient.Client.ClientEventArgs
{
	public class ErrorEventArgs : EventArgs
	{
		public string Error { get; set; }

		public ErrorEventArgs(string error)
		{
			this.Error = error;
		}
	}
}
