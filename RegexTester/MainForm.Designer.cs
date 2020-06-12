namespace RegexTestHarness
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.checkBoxGlobal = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreCase = new System.Windows.Forms.CheckBox();
            this.checkBoxMultiLine = new System.Windows.Forms.CheckBox();
            this.checkBoxSingleline = new System.Windows.Forms.CheckBox();
            this.checkBoxLinebyline = new System.Windows.Forms.CheckBox();
            this.toolTipGlobal = new System.Windows.Forms.ToolTip(this.components);
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.textBoxPattern = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonMatch = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridMatches = new System.Windows.Forms.DataGridView();
            this.MatchText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchIdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupIdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatches)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxGlobal
            // 
            this.checkBoxGlobal.AutoSize = true;
            this.checkBoxGlobal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGlobal.Location = new System.Drawing.Point(6, 35);
            this.checkBoxGlobal.Name = "checkBoxGlobal";
            this.checkBoxGlobal.Size = new System.Drawing.Size(60, 19);
            this.checkBoxGlobal.TabIndex = 5;
            this.checkBoxGlobal.Text = "Global";
            this.toolTipGlobal.SetToolTip(this.checkBoxGlobal, "Enables iterative matching");
            this.checkBoxGlobal.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreCase
            // 
            this.checkBoxIgnoreCase.AutoSize = true;
            this.checkBoxIgnoreCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIgnoreCase.Location = new System.Drawing.Point(73, 35);
            this.checkBoxIgnoreCase.Name = "checkBoxIgnoreCase";
            this.checkBoxIgnoreCase.Size = new System.Drawing.Size(86, 19);
            this.checkBoxIgnoreCase.TabIndex = 9;
            this.checkBoxIgnoreCase.Text = "Ignore case";
            this.toolTipGlobal.SetToolTip(this.checkBoxIgnoreCase, "Make the search case-insensitive ");
            this.checkBoxIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // checkBoxMultiLine
            // 
            this.checkBoxMultiLine.AutoSize = true;
            this.checkBoxMultiLine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMultiLine.Location = new System.Drawing.Point(161, 35);
            this.checkBoxMultiLine.Name = "checkBoxMultiLine";
            this.checkBoxMultiLine.Size = new System.Drawing.Size(73, 19);
            this.checkBoxMultiLine.TabIndex = 10;
            this.checkBoxMultiLine.Text = "Multiline";
            this.toolTipGlobal.SetToolTip(this.checkBoxMultiLine, "Changes ^ and $ to match at beginning and end of any line, not just beginning and" +
        " end of string");
            this.checkBoxMultiLine.UseVisualStyleBackColor = true;
            // 
            // checkBoxSingleline
            // 
            this.checkBoxSingleline.AutoSize = true;
            this.checkBoxSingleline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSingleline.Location = new System.Drawing.Point(234, 35);
            this.checkBoxSingleline.Name = "checkBoxSingleline";
            this.checkBoxSingleline.Size = new System.Drawing.Size(77, 19);
            this.checkBoxSingleline.TabIndex = 11;
            this.checkBoxSingleline.Text = "Singleline";
            this.toolTipGlobal.SetToolTip(this.checkBoxSingleline, "Changes meaning of .(dot) to match every character including \\n");
            this.checkBoxSingleline.UseVisualStyleBackColor = true;
            // 
            // checkBoxLinebyline
            // 
            this.checkBoxLinebyline.AutoSize = true;
            this.checkBoxLinebyline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLinebyline.Location = new System.Drawing.Point(314, 35);
            this.checkBoxLinebyline.Name = "checkBoxLinebyline";
            this.checkBoxLinebyline.Size = new System.Drawing.Size(90, 19);
            this.checkBoxLinebyline.TabIndex = 12;
            this.checkBoxLinebyline.Text = "Line-by-line";
            this.toolTipGlobal.SetToolTip(this.checkBoxLinebyline, "Split the string on \\n, and apply the regex to each line");
            this.checkBoxLinebyline.UseVisualStyleBackColor = true;
            // 
            // toolTipGlobal
            // 
            this.toolTipGlobal.Tag = "";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutput.BackColor = System.Drawing.Color.White;
            this.richTextBoxOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBoxOutput.Size = new System.Drawing.Size(1074, 316);
            this.richTextBoxOutput.TabIndex = 9;
            this.richTextBoxOutput.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.textBoxPattern,
            this.toolStripSeparator1,
            this.buttonMatch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1077, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "Pattern:";
            // 
            // textBoxPattern
            // 
            this.textBoxPattern.Name = "textBoxPattern";
            this.textBoxPattern.Size = new System.Drawing.Size(700, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonMatch
            // 
            this.buttonMatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonMatch.Image = ((System.Drawing.Image)(resources.GetObject("buttonMatch.Image")));
            this.buttonMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMatch.Name = "buttonMatch";
            this.buttonMatch.Size = new System.Drawing.Size(46, 22);
            this.buttonMatch.Text = "Search";
            this.buttonMatch.Click += new System.EventHandler(this.buttonMatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Text to search:";
            // 
            // dataGridMatches
            // 
            this.dataGridMatches.AllowUserToAddRows = false;
            this.dataGridMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMatches.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupIdx,
            this.Group,
            this.MatchIdx,
            this.MatchText});
            this.dataGridMatches.Location = new System.Drawing.Point(0, 0);
            this.dataGridMatches.Name = "dataGridMatches";
            this.dataGridMatches.Size = new System.Drawing.Size(1077, 444);
            this.dataGridMatches.TabIndex = 11;
            // 
            // MatchText
            // 
            this.MatchText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MatchText.HeaderText = "Text";
            this.MatchText.Name = "MatchText";
            // 
            // MatchIdx
            // 
            this.MatchIdx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MatchIdx.HeaderText = "Index";
            this.MatchIdx.Name = "MatchIdx";
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            // 
            // GroupIdx
            // 
            this.GroupIdx.HeaderText = "GroupIdx";
            this.GroupIdx.Name = "GroupIdx";
            this.GroupIdx.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 77);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxOutput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridMatches);
            this.splitContainer1.Size = new System.Drawing.Size(1077, 763);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 18;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.labelStatus,
            this.toolStripStatusLabel1,
            this.labelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 841);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1077, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "| Time:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel2.Text = "Status:";
            // 
            // labelTime
            // 
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1077, 863);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxGlobal);
            this.Controls.Add(this.checkBoxLinebyline);
            this.Controls.Add(this.checkBoxSingleline);
            this.Controls.Add(this.checkBoxMultiLine);
            this.Controls.Add(this.checkBoxIgnoreCase);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "RegexTester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatches)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxGlobal;
        private System.Windows.Forms.CheckBox checkBoxIgnoreCase;
        private System.Windows.Forms.CheckBox checkBoxMultiLine;
        private System.Windows.Forms.CheckBox checkBoxSingleline;
        private System.Windows.Forms.CheckBox checkBoxLinebyline;
        private System.Windows.Forms.ToolTip toolTipGlobal;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox textBoxPattern;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonMatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchText;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel labelTime;
    }
}

