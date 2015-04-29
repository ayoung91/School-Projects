namespace Assignment_4
{
    partial class frmMain
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
            this.rdoBinary = new System.Windows.Forms.RadioButton();
            this.rdoText = new System.Windows.Forms.RadioButton();
            this.lblChoose = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.lblScheme = new System.Windows.Forms.Label();
            this.lblBinaryString = new System.Windows.Forms.Label();
            this.cboEncoding = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdoBinary
            // 
            this.rdoBinary.AutoSize = true;
            this.rdoBinary.BackColor = System.Drawing.SystemColors.Control;
            this.rdoBinary.Location = new System.Drawing.Point(269, 43);
            this.rdoBinary.Name = "rdoBinary";
            this.rdoBinary.Size = new System.Drawing.Size(84, 17);
            this.rdoBinary.TabIndex = 0;
            this.rdoBinary.TabStop = true;
            this.rdoBinary.Text = "Binary String";
            this.rdoBinary.UseVisualStyleBackColor = false;
            this.rdoBinary.CheckedChanged += new System.EventHandler(this.rdoBinary_CheckedChanged);
            // 
            // rdoText
            // 
            this.rdoText.AutoSize = true;
            this.rdoText.BackColor = System.Drawing.SystemColors.Control;
            this.rdoText.Location = new System.Drawing.Point(412, 43);
            this.rdoText.Name = "rdoText";
            this.rdoText.Size = new System.Drawing.Size(76, 17);
            this.rdoText.TabIndex = 1;
            this.rdoText.TabStop = true;
            this.rdoText.Text = "Text String";
            this.rdoText.UseVisualStyleBackColor = false;
            this.rdoText.CheckedChanged += new System.EventHandler(this.rdoText_CheckedChanged);
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.BackColor = System.Drawing.SystemColors.Control;
            this.lblChoose.Location = new System.Drawing.Point(153, 45);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(95, 13);
            this.lblChoose.TabIndex = 2;
            this.lblChoose.Text = "Choose input type:";
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(130, 92);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(219, 20);
            this.txtInput.TabIndex = 3;
            this.txtInput.Visible = false;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(29, 95);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(0, 13);
            this.lblInput.TabIndex = 4;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConvert.Location = new System.Drawing.Point(274, 132);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Visible = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGraph.Location = new System.Drawing.Point(553, 132);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 8;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = false;
            this.btnGraph.Visible = false;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheme.Location = new System.Drawing.Point(12, 177);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(0, 16);
            this.lblScheme.TabIndex = 9;
            // 
            // lblBinaryString
            // 
            this.lblBinaryString.AutoSize = true;
            this.lblBinaryString.BackColor = System.Drawing.SystemColors.Control;
            this.lblBinaryString.Location = new System.Drawing.Point(128, 115);
            this.lblBinaryString.Name = "lblBinaryString";
            this.lblBinaryString.Size = new System.Drawing.Size(0, 13);
            this.lblBinaryString.TabIndex = 14;
            // 
            // cboEncoding
            // 
            this.cboEncoding.BackColor = System.Drawing.Color.White;
            this.cboEncoding.FormattingEnabled = true;
            this.cboEncoding.Items.AddRange(new object[] {
            "NRZL",
            "NRZI",
            "Bipolar-AMI",
            "Pseudoternary",
            "Manchester",
            "Differential Manchester",
            "B8ZS",
            "HDB3"});
            this.cboEncoding.Location = new System.Drawing.Point(491, 91);
            this.cboEncoding.Name = "cboEncoding";
            this.cboEncoding.Size = new System.Drawing.Size(137, 21);
            this.cboEncoding.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(388, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Encoding Scheme:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(754, 327);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEncoding);
            this.Controls.Add(this.lblBinaryString);
            this.Controls.Add(this.lblScheme);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.rdoText);
            this.Controls.Add(this.rdoBinary);
            this.Name = "frmMain";
            this.Text = "Digital Encoding";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoBinary;
        private System.Windows.Forms.RadioButton rdoText;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Label lblBinaryString;
        private System.Windows.Forms.ComboBox cboEncoding;
        private System.Windows.Forms.Label label1;
    }
}

