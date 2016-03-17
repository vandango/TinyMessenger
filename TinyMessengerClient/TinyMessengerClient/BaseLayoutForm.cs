using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyMessengerClient
{
	public partial class BaseLayoutForm : Form
	{
		#region MouseMove

		private bool _mouseDownForMove = false;
		private Point _firstPointForMove;

		//public const int WM_NCLBUTTONDOWN = 0xA1;
		//public const int HT_CAPTION = 0x2;

		//[DllImport("user32.dll")]
		//public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		//[DllImportAttribute("user32.dll")]
		//public static extern bool ReleaseCapture();

		private void mainPanel_MouseDown(object sender, MouseEventArgs e)
		{
			_firstPointForMove = e.Location;
			_mouseDownForMove = true;
		}

		private void mainPanel_MouseUp(object sender, MouseEventArgs e)
		{
			_mouseDownForMove = false;
		}

		private void mainPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (_mouseDownForMove)
			{
				// Get the difference between the two points
				int xDiff = _firstPointForMove.X - e.Location.X;
				int yDiff = _firstPointForMove.Y - e.Location.Y;

				// Set the new point
				int x = Location.X - xDiff;
				int y = Location.Y - yDiff;
				Location = new Point(x, y);

				//ReleaseCapture();
				//SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		#endregion

		#region ChangeWindowSize

		//private bool _mouseDownForResize = false;
		//private Point _firstPointForResize;
		//private Size _windowsSizeForResize;

		//private void panelGripLeftBottom_MouseDown(object sender, MouseEventArgs e)
		//{
		//	_mouseDownForResize = true;
		//	_firstPointForResize = e.Location;
		//	_windowsSizeForResize = Size;
		//}

		//private void panelGripLeftBottom_MouseUp(object sender, MouseEventArgs e)
		//{
		//	_mouseDownForResize = false;
		//}

		//private void panelGripLeftBottom_MouseMove(object sender, MouseEventArgs e)
		//{
		//	if (_mouseDownForResize)
		//	{
		//		//int widthOffset = _firstPointForResize.X - _windowsSizeForResize.Width;
		//		//int heightOffset = _firstPointForResize.Y - _windowsSizeForResize.Height;

		//		int xDiff = _firstPointForResize.X - e.Location.X;
		//		int yDiff = _firstPointForResize.Y + e.Location.Y;

		//		int width = Size.Width + xDiff;
		//		int height = Size.Height + yDiff;

		//		Debug.WriteLine($"{width} x {height}");

		//		width = _windowsSizeForResize.Width;
		//		height = _windowsSizeForResize.Height;

		//		Size = new Size(width, height);
		//	}
		//}

		//// ---------------------------------------------- GRIP ---

		private const int sizeGrip = 20;

		protected override void OnPaint(PaintEventArgs e)
		{
			var rc = new Rectangle(
				ClientSize.Width - sizeGrip,
				ClientSize.Height - sizeGrip,
				sizeGrip,
				sizeGrip
				);

			//Graphics graphics = panelStatus.CreateGraphics();
			//ControlPaint.DrawSizeGrip(graphics, Color.White, rc);
			//ControlPaint.DrawSizeGrip(graphics, panelStatus.BackColor, rc);

			ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);

			base.OnPaint(e);
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x84)
			{
				// Trap WM_NCHITTEST
				Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
				pos = PointToClient(pos);

				if (pos.X >= ClientSize.Width - sizeGrip && pos.Y >= ClientSize.Height - sizeGrip)
				{
					// HTBOTTOMRIGHT
					m.Result = (IntPtr)17;
					return;
				}
			}
			base.WndProc(ref m);
		}

		#endregion

		public BaseLayoutForm()
		{
			InitializeComponent();

			DoubleBuffered = true;
			base.BackColor = SystemColors.Control;
			panelHeader.Dock = DockStyle.Top;
			panelBody.Visible = false;
			panelStatus.Visible = false;
			panelGripLeftBottom.Visible = false;

			//panelGripLeftBottom.MouseDown += this.panelGripLeftBottom_MouseDown;
			//panelGripLeftBottom.MouseMove += this.panelGripLeftBottom_MouseMove;
			//panelGripLeftBottom.MouseUp += this.panelGripLeftBottom_MouseUp;
			
			SetStyle(ControlStyles.ResizeRedraw, true);
		}

		//public new Control.ControlCollection Controls => panelBody.Controls;

		//public new Size ClientSize
		//{
		//	get { return panelBody.Size; }
		//	set
		//	{
		//		panelBody.Size = value;
		//		base.ClientSize = new Size(value.Width + 2, value.Height + 2);
		//		base.Size = new Size(value.Width + 2, value.Height + 2);
		//	}
		//}

		private void btnClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Abort;
			Close();
		}

		private void btnMaximize_Click(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Normal)
			{
				WindowState = FormWindowState.Maximized;
				btnMaximize.Image = Properties.Resources.maximize;
			}
			else
			{
				WindowState = FormWindowState.Normal;
				btnMaximize.Image = Properties.Resources.normal;
			}
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
	}
}
