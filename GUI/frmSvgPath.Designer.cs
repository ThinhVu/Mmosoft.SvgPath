namespace GUI
{
    partial class frmSvgPath
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
            this.txtSVGPath = new System.Windows.Forms.TextBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.lbParsedCmds = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbShape = new System.Windows.Forms.ListBox();
            this.lblError = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.nudScale = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBase = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.txtParsedCmds = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSVGPath
            // 
            this.txtSVGPath.Location = new System.Drawing.Point(6, 38);
            this.txtSVGPath.Multiline = true;
            this.txtSVGPath.Name = "txtSVGPath";
            this.txtSVGPath.Size = new System.Drawing.Size(629, 87);
            this.txtSVGPath.TabIndex = 0;
            this.txtSVGPath.TextChanged += new System.EventHandler(this.txtSVGPath_TextChanged);
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(6, 16);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(83, 83);
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // lbParsedCmds
            // 
            this.lbParsedCmds.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbParsedCmds.FormattingEnabled = true;
            this.lbParsedCmds.Location = new System.Drawing.Point(3, 16);
            this.lbParsedCmds.Name = "lbParsedCmds";
            this.lbParsedCmds.Size = new System.Drawing.Size(738, 212);
            this.lbParsedCmds.TabIndex = 4;
            this.lbParsedCmds.SelectedIndexChanged += new System.EventHandler(this.lbParsedCmds_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path";
            // 
            // lbShape
            // 
            this.lbShape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShape.FormattingEnabled = true;
            this.lbShape.Location = new System.Drawing.Point(3, 16);
            this.lbShape.Name = "lbShape";
            this.lbShape.Size = new System.Drawing.Size(156, 428);
            this.lbShape.TabIndex = 8;
            this.lbShape.SelectedIndexChanged += new System.EventHandler(this.lbShape_SelectedIndexChanged);
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(278, 470);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(632, 25);
            this.lblError.TabIndex = 11;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 485);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(225, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/ThinhVu/mmosoft.svgpath";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(5, 103);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nudScale
            // 
            this.nudScale.Location = new System.Drawing.Point(507, 11);
            this.nudScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScale.Name = "nudScale";
            this.nudScale.Size = new System.Drawing.Size(42, 20);
            this.nudScale.TabIndex = 16;
            this.nudScale.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudScale.ValueChanged += new System.EventHandler(this.nudScale_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Scale";
            // 
            // nudBase
            // 
            this.nudBase.Location = new System.Drawing.Point(593, 12);
            this.nudBase.Name = "nudBase";
            this.nudBase.Size = new System.Drawing.Size(42, 20);
            this.nudBase.TabIndex = 18;
            this.nudBase.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudBase.ValueChanged += new System.EventHandler(this.nudBase_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(559, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Base";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(6, 469);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(140, 13);
            this.linkLabel2.TabIndex = 20;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://useiconic.com/open";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtParsedCmds);
            this.groupBox1.Controls.Add(this.lbParsedCmds);
            this.groupBox1.Location = new System.Drawing.Point(171, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 310);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands (select each step to see what happen)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbPreview);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(821, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 131);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbColor);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtSVGPath);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nudScale);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.nudBase);
            this.groupBox3.Location = new System.Drawing.Point(174, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 131);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbShape);
            this.groupBox4.Location = new System.Drawing.Point(6, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(162, 447);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Samples";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Color (A,R,G,B) or Hex Format:";
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "255, 255, 0, 0",
            "#FFFF0000"});
            this.cbColor.Location = new System.Drawing.Point(340, 10);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(121, 21);
            this.cbColor.TabIndex = 22;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
            this.cbColor.TextChanged += new System.EventHandler(this.cbColor_TextChanged);
            // 
            // txtParsedCmds
            // 
            this.txtParsedCmds.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtParsedCmds.Location = new System.Drawing.Point(3, 247);
            this.txtParsedCmds.Multiline = true;
            this.txtParsedCmds.Name = "txtParsedCmds";
            this.txtParsedCmds.Size = new System.Drawing.Size(738, 60);
            this.txtParsedCmds.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(362, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Absolute commands (sometimes it contain exponent => cannot use to draw)";
            // 
            // frmSvgPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(927, 504);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSvgPath";
            this.ShowIcon = false;
            this.Text = "SVG Path Practice";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSVGPath;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.ListBox lbParsedCmds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbShape;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nudScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.TextBox txtParsedCmds;
        private System.Windows.Forms.Label label4;
    }
}

