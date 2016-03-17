using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyMessengerClient.MessengerService;

namespace TinyMessengerClient.Client
{
	internal static class FormsHelper
	{
		public static void MessageString(RichTextBox textBox, MessageModel model, UserModel currentUser)
		{
			var align = (
				model.User.UserId == currentUser.UserId 
				? HorizontalAlignment.Right 
				: HorizontalAlignment.Left
				);

			var message = new StringBuilder();
			int start = 0;
			int length = 0;

			// time and user
			message.Append(UserString(model.User));
			message.Append(" wrote:");

			textBox.SelectionAlignment = align;
			textBox.SelectionIndent = 0;
			start = textBox.Text.Length;
			length = message.Length - 1;
			textBox.AppendText(message.ToString());
			textBox.DeselectAll();
			textBox.Select(start, length);
			textBox.SelectionColor = Color.Gray;
			textBox.PerformLayout();

			// reset
			message = new StringBuilder();

			// date
			message.Append(" (");
			message.Append(DateTimeString(model.RequestTime));
			message.Append(")");
			message.Append(Environment.NewLine);

			textBox.SelectionAlignment = align;
			textBox.SelectionIndent = 0;
			start = textBox.Text.Length;
			length = message.Length - 1;
			textBox.AppendText(message.ToString());
			textBox.DeselectAll();
			textBox.Select(start, length);
			textBox.SelectionColor = Color.LightGray;
			textBox.PerformLayout();

			// reset
			message = new StringBuilder();

			// body
			message.Append(model.Text);
			message.Append(Environment.NewLine);

			textBox.SelectionAlignment = align;
			textBox.SelectionIndent = 10;
			start = textBox.Text.Length;
			length = message.Length - 1;
			textBox.AppendText(message.ToString());
			textBox.DeselectAll();
			textBox.Select(start, length);
			textBox.SelectionColor = Color.DarkBlue;
			textBox.PerformLayout();

			// reset
			message = new StringBuilder();

			// date
			message.Append("----------");
			message.Append(Environment.NewLine);
			message.Append(Environment.NewLine);

			textBox.SelectionAlignment = align;
			textBox.SelectionIndent = 0;
			start = textBox.Text.Length;
			length = message.Length - 1;
			textBox.AppendText(message.ToString());
			textBox.DeselectAll();
			textBox.Select(start, length);
			textBox.SelectionColor = Color.LightGray;
			textBox.PerformLayout();

			// reset
			textBox.SelectionAlignment = HorizontalAlignment.Left;
		}

		public static string DateTimeString(DateTime date)
		{
			return string.Concat(
				date.ToString("dd.MM.yyyy HH:mm:ss"),
				" Uhr"
				);
		}

		public static string TimeString(DateTime date)
		{
			return string.Concat(
				date.ToString("HH:mm:ss"),
				" Uhr"
				);
		}

		public static string DateString(DateTime date)
		{
			return date.ToString("dd.MM.yyyy");
		}

		public static string UserString(UserModel model)
		{
			return model?.Username ?? "";

			//return string.Format(
			//	"{0} ({1})",
			//	model.Username,
			//	model.UserId
			//	);
		}

		public static string ChatNameString(ChatModel model)
		{
			string users = "[Kein Teilnehmer]";

			if (model.AllUsers != null
			    && model.AllUsers.Count > 0)
			{
				if (model.AllUsers.Count > 0)
				{
					users = string.Join(
						", ",
						model.AllUsers.Select(p => p.Username).ToList()
						);
				}
			}
			else
			{
				if (model.TargetUsers.Count > 0)
				{
					users = string.Concat(
						model.StartingUser.Username, 
						", ",
						string.Join(
							", ",
							model.TargetUsers.Select(p => p.Username).ToList()
							)
						);
				}
			}

			string newMessageCounter = (
				model.NewMessageCounter > 0
					? $" ({model.NewMessageCounter})"
					: "");

			return $"{model.Name}: {users}{newMessageCounter}";
		}

		public static string ChatString(ChatModel model)
		{
			string users = string.Join(
				", ",
				model.TargetUsers.Select(p => p.Username).ToList()
				);

			return string.Format(
				"{0} by {1}",
				model.Name ?? users,
				model.StartingUser.Username
				);
		}

		public static T GetSelectedItem<T>(ListView listView)
		{
			if (listView.SelectedItems.Count > 0)
			{
				object selectedItem = listView.SelectedItems[0].Tag;

				if (selectedItem is T)
				{
					return (T)selectedItem;
				}
			}

			return default(T);
		}

		public static IEnumerable<T> GetSelectedItems<T>(ListView listView)
		{
			if (listView.SelectedItems.Count > 0)
			{
				foreach (ListViewItem item in listView.SelectedItems)
				{
					object selectedItem = item.Tag;

					if (selectedItem != null && selectedItem is T)
					{
						yield return (T)selectedItem;
					}
				}
			}

			//yield return default(T);
		}

		public static ListViewGroup GetRelatedGroup(ListView listView, string groupKey)
		{
			ListViewGroup groupItem = null;

			if (listView.Groups.Count > 0)
			{
				groupItem = listView.Groups
					.Cast<ListViewGroup>()
					.FirstOrDefault(@group => @group.Name == groupKey);
			}

			if (groupItem == null)
			{
				groupItem = new ListViewGroup(groupKey, groupKey);
				listView.Groups.Add(groupItem);
			}

			return groupItem;
		}
	}
}
