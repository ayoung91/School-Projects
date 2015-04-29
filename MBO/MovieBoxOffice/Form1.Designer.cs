namespace MovieBoxOffice
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
            this.lblMovSelec = new System.Windows.Forms.Label();
            this.cboMovie = new System.Windows.Forms.ComboBox();
            this.chkMatinee = new System.Windows.Forms.CheckBox();
            this.grpTickets = new System.Windows.Forms.GroupBox();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.lstAmount = new System.Windows.Forms.ListBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lstRecord = new System.Windows.Forms.ListBox();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpTickets.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMovSelec
            // 
            this.lblMovSelec.AutoSize = true;
            this.lblMovSelec.Location = new System.Drawing.Point(13, 13);
            this.lblMovSelec.Name = "lblMovSelec";
            this.lblMovSelec.Size = new System.Drawing.Size(83, 13);
            this.lblMovSelec.TabIndex = 0;
            this.lblMovSelec.Text = "Movie Selection";
            // 
            // cboMovie
            // 
            this.cboMovie.FormattingEnabled = true;
            this.cboMovie.Items.AddRange(new object[] {
            "Die Hard",
            "Die Hard 2",
            "Die Hard 3",
            "Die Hard 4",
            "Die Hard 5"});
            this.cboMovie.Location = new System.Drawing.Point(12, 30);
            this.cboMovie.Name = "cboMovie";
            this.cboMovie.Size = new System.Drawing.Size(268, 21);
            this.cboMovie.TabIndex = 1;
            // 
            // chkMatinee
            // 
            this.chkMatinee.AutoSize = true;
            this.chkMatinee.Location = new System.Drawing.Point(30, 90);
            this.chkMatinee.Name = "chkMatinee";
            this.chkMatinee.Size = new System.Drawing.Size(109, 17);
            this.chkMatinee.TabIndex = 2;
            this.chkMatinee.Text = "Matinee Discount";
            this.chkMatinee.UseVisualStyleBackColor = true;
            this.chkMatinee.CheckedChanged += new System.EventHandler(this.chkMatinee_CheckedChanged);
            // 
            // grpTickets
            // 
            this.grpTickets.Controls.Add(this.rb4);
            this.grpTickets.Controls.Add(this.rb3);
            this.grpTickets.Controls.Add(this.rb2);
            this.grpTickets.Controls.Add(this.rb1);
            this.grpTickets.Location = new System.Drawing.Point(12, 190);
            this.grpTickets.Name = "grpTickets";
            this.grpTickets.Size = new System.Drawing.Size(268, 58);
            this.grpTickets.TabIndex = 4;
            this.grpTickets.TabStop = false;
            this.grpTickets.Text = "# of Tickets";
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(231, 20);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(31, 17);
            this.rb4.TabIndex = 3;
            this.rb4.TabStop = true;
            this.rb4.Text = "4";
            this.rb4.UseVisualStyleBackColor = true;
            this.rb4.Click += new System.EventHandler(this.rb4_Click);
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(152, 20);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(31, 17);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.Text = "3";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.Click += new System.EventHandler(this.rb3_Click);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(81, 20);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(31, 17);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "2";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.Click += new System.EventHandler(this.rb2_Click);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(18, 20);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(31, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "1";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.Click += new System.EventHandler(this.rb1_Click);
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Location = new System.Drawing.Point(13, 296);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(66, 13);
            this.lblAmountDue.TabIndex = 5;
            this.lblAmountDue.Text = "Amount Due";
            // 
            // lstAmount
            // 
            this.lstAmount.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lstAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAmount.FormattingEnabled = true;
            this.lstAmount.Location = new System.Drawing.Point(12, 315);
            this.lstAmount.Name = "lstAmount";
            this.lstAmount.Size = new System.Drawing.Size(155, 43);
            this.lstAmount.TabIndex = 6;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(173, 315);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(107, 32);
            this.btnEnter.TabIndex = 7;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lstRecord
            // 
            this.lstRecord.FormattingEnabled = true;
            this.lstRecord.Location = new System.Drawing.Point(12, 406);
            this.lstRecord.Name = "lstRecord";
            this.lstRecord.Size = new System.Drawing.Size(268, 95);
            this.lstRecord.TabIndex = 8;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(12, 387);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(101, 13);
            this.lblRecord.TabIndex = 9;
            this.lblRecord.Text = "Transaction Record";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(12, 524);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(268, 36);
            this.btnQuit.TabIndex = 10;
            this.btnQuit.Text = "Quit Movie Box Office";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 46);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 572);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.lstRecord);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lstAmount);
            this.Controls.Add(this.lblAmountDue);
            this.Controls.Add(this.grpTickets);
            this.Controls.Add(this.chkMatinee);
            this.Controls.Add(this.cboMovie);
            this.Controls.Add(this.lblMovSelec);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpTickets.ResumeLayout(false);
            this.grpTickets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMovSelec;
        private System.Windows.Forms.ComboBox cboMovie;
        private System.Windows.Forms.CheckBox chkMatinee;
        private System.Windows.Forms.GroupBox grpTickets;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.ListBox lstAmount;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.ListBox lstRecord;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Panel panel1;
    }
}

