namespace Server_Stress_Test
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.gbStressTest = new System.Windows.Forms.GroupBox();
            this.lblEstablishAmount = new System.Windows.Forms.Label();
            this.txtAmountToEstablish = new System.Windows.Forms.TextBox();
            this.lblSendRandom = new System.Windows.Forms.Label();
            this.chkSendRandomData = new System.Windows.Forms.CheckBox();
            this.txtBox = new System.Windows.Forms.RichTextBox();
            this.gbStressTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(540, 222);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbStressTest
            // 
            this.gbStressTest.Controls.Add(this.chkSendRandomData);
            this.gbStressTest.Controls.Add(this.lblSendRandom);
            this.gbStressTest.Controls.Add(this.txtAmountToEstablish);
            this.gbStressTest.Controls.Add(this.lblEstablishAmount);
            this.gbStressTest.Location = new System.Drawing.Point(12, 12);
            this.gbStressTest.Name = "gbStressTest";
            this.gbStressTest.Size = new System.Drawing.Size(252, 229);
            this.gbStressTest.TabIndex = 1;
            this.gbStressTest.TabStop = false;
            this.gbStressTest.Text = "Options";
            // 
            // lblEstablishAmount
            // 
            this.lblEstablishAmount.AutoSize = true;
            this.lblEstablishAmount.Location = new System.Drawing.Point(7, 20);
            this.lblEstablishAmount.Name = "lblEstablishAmount";
            this.lblEstablishAmount.Size = new System.Drawing.Size(183, 13);
            this.lblEstablishAmount.TabIndex = 0;
            this.lblEstablishAmount.Text = "Amount Of Connecitons To Establish:";
            // 
            // txtAmountToEstablish
            // 
            this.txtAmountToEstablish.Location = new System.Drawing.Point(196, 17);
            this.txtAmountToEstablish.Name = "txtAmountToEstablish";
            this.txtAmountToEstablish.Size = new System.Drawing.Size(49, 20);
            this.txtAmountToEstablish.TabIndex = 1;
            // 
            // lblSendRandom
            // 
            this.lblSendRandom.AutoSize = true;
            this.lblSendRandom.Location = new System.Drawing.Point(7, 50);
            this.lblSendRandom.Name = "lblSendRandom";
            this.lblSendRandom.Size = new System.Drawing.Size(102, 13);
            this.lblSendRandom.TabIndex = 2;
            this.lblSendRandom.Text = "Send Random Text:";
            // 
            // chkSendRandomData
            // 
            this.chkSendRandomData.AutoSize = true;
            this.chkSendRandomData.Location = new System.Drawing.Point(116, 50);
            this.chkSendRandomData.Name = "chkSendRandomData";
            this.chkSendRandomData.Size = new System.Drawing.Size(15, 14);
            this.chkSendRandomData.TabIndex = 3;
            this.chkSendRandomData.UseVisualStyleBackColor = true;
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(270, 12);
            this.txtBox.Name = "txtBox";
            this.txtBox.ReadOnly = true;
            this.txtBox.Size = new System.Drawing.Size(345, 204);
            this.txtBox.TabIndex = 2;
            this.txtBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 253);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.gbStressTest);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbStressTest.ResumeLayout(false);
            this.gbStressTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbStressTest;
        private System.Windows.Forms.CheckBox chkSendRandomData;
        private System.Windows.Forms.Label lblSendRandom;
        private System.Windows.Forms.TextBox txtAmountToEstablish;
        private System.Windows.Forms.Label lblEstablishAmount;
        public System.Windows.Forms.RichTextBox txtBox;
    }
}

