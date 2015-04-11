namespace DSEServer
{
    partial class Home
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
        private void  InitializeComponent()
        {
            this.txtBox = new System.Windows.Forms.RichTextBox();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.txtField = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(12, 39);
            this.txtBox.Name = "txtBox";
            this.txtBox.ReadOnly = true;
            this.txtBox.Size = new System.Drawing.Size(782, 277);
            this.txtBox.TabIndex = 0;
            this.txtBox.Text = " ";
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(800, 39);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(117, 277);
            this.lbUsers.TabIndex = 1;
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(12, 322);
            this.txtField.Multiline = true;
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(782, 20);
            this.txtField.TabIndex = 2;
            this.txtField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(800, 322);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(117, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mToolStripMenuItem
            // 
            this.mToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descToolStripMenuItem,
            this.insertColumnToolStripMenuItem,
            this.createAccountToolStripMenuItem,
            this.checkAccountToolStripMenuItem});
            this.mToolStripMenuItem.Name = "mToolStripMenuItem";
            this.mToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.mToolStripMenuItem.Text = "MySql Commands";
            // 
            // descToolStripMenuItem
            // 
            this.descToolStripMenuItem.Name = "descToolStripMenuItem";
            this.descToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.descToolStripMenuItem.Text = "Describe UserInfo";
            this.descToolStripMenuItem.Click += new System.EventHandler(this.descToolStripMenuItem_Click);
            // 
            // insertColumnToolStripMenuItem
            // 
            this.insertColumnToolStripMenuItem.Name = "insertColumnToolStripMenuItem";
            this.insertColumnToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.insertColumnToolStripMenuItem.Text = "Insert Column";
            this.insertColumnToolStripMenuItem.Click += new System.EventHandler(this.insertColumnToolStripMenuItem_Click);
            // 
            // createAccountToolStripMenuItem
            // 
            this.createAccountToolStripMenuItem.Name = "createAccountToolStripMenuItem";
            this.createAccountToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.createAccountToolStripMenuItem.Text = "Create Account";
            this.createAccountToolStripMenuItem.Click += new System.EventHandler(this.createAccountToolStripMenuItem_Click);
            // 
            // checkAccountToolStripMenuItem
            // 
            this.checkAccountToolStripMenuItem.Name = "checkAccountToolStripMenuItem";
            this.checkAccountToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.checkAccountToolStripMenuItem.Text = "Check Account";
            this.checkAccountToolStripMenuItem.Click += new System.EventHandler(this.checkAccountToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 354);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtField);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "DSE Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertColumnToolStripMenuItem;
        public System.Windows.Forms.RichTextBox txtBox;
        private System.Windows.Forms.ToolStripMenuItem createAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAccountToolStripMenuItem;
    }
}

