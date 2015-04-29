namespace Stop
{
    partial class frmStop
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
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnding = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnding = new System.Windows.Forms.TextBox();
            this.txtElapsed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 54);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(13, 163);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(174, 38);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(72, 13);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "Starting Time:";
            // 
            // lblEnding
            // 
            this.lblEnding.AutoSize = true;
            this.lblEnding.Location = new System.Drawing.Point(177, 113);
            this.lblEnding.Name = "lblEnding";
            this.lblEnding.Size = new System.Drawing.Size(69, 13);
            this.lblEnding.TabIndex = 3;
            this.lblEnding.Text = "Ending Time:";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(175, 201);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(71, 13);
            this.lblElapsed.TabIndex = 4;
            this.lblElapsed.Text = "ElapsedTime:";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(272, 35);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 5;
            // 
            // txtEnding
            // 
            this.txtEnding.Location = new System.Drawing.Point(272, 110);
            this.txtEnding.Name = "txtEnding";
            this.txtEnding.Size = new System.Drawing.Size(100, 20);
            this.txtEnding.TabIndex = 6;
            // 
            // txtElapsed
            // 
            this.txtElapsed.Location = new System.Drawing.Point(272, 198);
            this.txtElapsed.Name = "txtElapsed";
            this.txtElapsed.Size = new System.Drawing.Size(100, 20);
            this.txtElapsed.TabIndex = 7;
            // 
            // frmStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 271);
            this.Controls.Add(this.txtElapsed);
            this.Controls.Add(this.txtEnding);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.lblEnding);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "frmStop";
            this.Text = "Stop Watch";
            this.Load += new System.EventHandler(this.frmStop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnding;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnding;
        private System.Windows.Forms.TextBox txtElapsed;
    }
}

