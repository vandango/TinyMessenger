namespace TinyMessengerClient
{
	partial class BaseLayoutForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelHeader = new System.Windows.Forms.Panel();
			this.btnMinimize = new System.Windows.Forms.Button();
			this.btnMaximize = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panelBody = new System.Windows.Forms.Panel();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.panelGripLeftBottom = new System.Windows.Forms.Panel();
			this.panelHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelHeader
			// 
			this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelHeader.BackColor = System.Drawing.Color.Green;
			this.panelHeader.Controls.Add(this.btnMinimize);
			this.panelHeader.Controls.Add(this.btnMaximize);
			this.panelHeader.Controls.Add(this.btnClose);
			this.panelHeader.Location = new System.Drawing.Point(1, 1);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(298, 34);
			this.panelHeader.TabIndex = 0;
			this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
			this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
			this.panelHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseUp);
			// 
			// btnMinimize
			// 
			this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimize.Image = global::TinyMessengerClient.Properties.Resources.minimize;
			this.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.btnMinimize.Location = new System.Drawing.Point(202, 4);
			this.btnMinimize.Name = "btnMinimize";
			this.btnMinimize.Size = new System.Drawing.Size(26, 26);
			this.btnMinimize.TabIndex = 2;
			this.btnMinimize.UseVisualStyleBackColor = true;
			this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
			// 
			// btnMaximize
			// 
			this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMaximize.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMaximize.Image = global::TinyMessengerClient.Properties.Resources.normal;
			this.btnMaximize.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.btnMaximize.Location = new System.Drawing.Point(234, 4);
			this.btnMaximize.Name = "btnMaximize";
			this.btnMaximize.Size = new System.Drawing.Size(26, 26);
			this.btnMaximize.TabIndex = 2;
			this.btnMaximize.UseVisualStyleBackColor = true;
			this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Image = global::TinyMessengerClient.Properties.Resources.cross;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.btnClose.Location = new System.Drawing.Point(266, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(26, 26);
			this.btnClose.TabIndex = 1;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panelBody
			// 
			this.panelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelBody.BackColor = System.Drawing.SystemColors.Control;
			this.panelBody.Location = new System.Drawing.Point(1, 35);
			this.panelBody.Name = "panelBody";
			this.panelBody.Size = new System.Drawing.Size(298, 246);
			this.panelBody.TabIndex = 1;
			// 
			// panelStatus
			// 
			this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelStatus.BackColor = System.Drawing.Color.OliveDrab;
			this.panelStatus.Location = new System.Drawing.Point(1, 282);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(282, 16);
			this.panelStatus.TabIndex = 2;
			// 
			// panelGripLeftBottom
			// 
			this.panelGripLeftBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.panelGripLeftBottom.BackColor = System.Drawing.Color.Yellow;
			this.panelGripLeftBottom.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.panelGripLeftBottom.Location = new System.Drawing.Point(280, 280);
			this.panelGripLeftBottom.Name = "panelGripLeftBottom";
			this.panelGripLeftBottom.Size = new System.Drawing.Size(20, 20);
			this.panelGripLeftBottom.TabIndex = 0;
			// 
			// BaseLayoutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.OliveDrab;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.Controls.Add(this.panelGripLeftBottom);
			this.Controls.Add(this.panelBody);
			this.Controls.Add(this.panelHeader);
			this.Controls.Add(this.panelStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "BaseLayoutForm";
			this.Text = "LayoutForm";
			this.panelHeader.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelHeader;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnMinimize;
		private System.Windows.Forms.Button btnMaximize;
		private System.Windows.Forms.Panel panelBody;
		private System.Windows.Forms.Panel panelStatus;
		private System.Windows.Forms.Panel panelGripLeftBottom;
	}
}