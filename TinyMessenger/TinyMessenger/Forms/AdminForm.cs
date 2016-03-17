using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyMessenger.Core;

namespace TinyMessenger.Forms
{
	public partial class AdminForm : Form
	{
		public AdminForm()
		{
			InitializeComponent();
		}

		private void AdminForm_Shown(object sender, EventArgs e)
		{
			
		}

		private void btnLoadUser_Click(object sender, EventArgs e)
		{
			gridUsers.DataSource = UserDatabase.Database;
		}
	}
}
