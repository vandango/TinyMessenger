namespace TinyMessenger.Forms
{
	partial class AdminForm
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
			this.gridUsers = new System.Windows.Forms.DataGridView();
			this.btnLoadUser = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
			this.SuspendLayout();
			// 
			// gridUsers
			// 
			this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridUsers.Location = new System.Drawing.Point(76, 103);
			this.gridUsers.Name = "gridUsers";
			this.gridUsers.Size = new System.Drawing.Size(508, 275);
			this.gridUsers.TabIndex = 0;
			// 
			// btnLoadUser
			// 
			this.btnLoadUser.Location = new System.Drawing.Point(341, 48);
			this.btnLoadUser.Name = "btnLoadUser";
			this.btnLoadUser.Size = new System.Drawing.Size(75, 23);
			this.btnLoadUser.TabIndex = 1;
			this.btnLoadUser.Text = "Load User";
			this.btnLoadUser.UseVisualStyleBackColor = true;
			this.btnLoadUser.Click += new System.EventHandler(this.btnLoadUser_Click);
			// 
			// AdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 496);
			this.Controls.Add(this.btnLoadUser);
			this.Controls.Add(this.gridUsers);
			this.Name = "AdminForm";
			this.Text = "AdminForm";
			this.Shown += new System.EventHandler(this.AdminForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridUsers;
		private System.Windows.Forms.Button btnLoadUser;
	}
}