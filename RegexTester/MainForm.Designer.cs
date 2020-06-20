namespace RegexTester
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
            this.chkGlobal = new System.Windows.Forms.CheckBox();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.chkMultiLine = new System.Windows.Forms.CheckBox();
            this.chkSingleline = new System.Windows.Forms.CheckBox();
            this.chkLinebyline = new System.Windows.Forms.CheckBox();
            this.toolTipGlobal = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtPattern = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridMatches = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupIdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchIdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineStartPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineEndPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtInputText = new RegexTester.SciTextBoxControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMatchCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWhiteSpaceAndTABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEndOfLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWrapSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkGlobal
            // 
            this.chkGlobal.AutoSize = true;
            this.chkGlobal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGlobal.Location = new System.Drawing.Point(6, 52);
            this.chkGlobal.Name = "chkGlobal";
            this.chkGlobal.Size = new System.Drawing.Size(60, 19);
            this.chkGlobal.TabIndex = 5;
            this.chkGlobal.Text = "Global";
            this.toolTipGlobal.SetToolTip(this.chkGlobal, "Enables iterative matching");
            this.chkGlobal.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnoreCase.Location = new System.Drawing.Point(72, 52);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(86, 19);
            this.chkIgnoreCase.TabIndex = 9;
            this.chkIgnoreCase.Text = "Ignore case";
            this.toolTipGlobal.SetToolTip(this.chkIgnoreCase, "Make the search case-insensitive ");
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // chkMultiLine
            // 
            this.chkMultiLine.AutoSize = true;
            this.chkMultiLine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMultiLine.Location = new System.Drawing.Point(164, 52);
            this.chkMultiLine.Name = "chkMultiLine";
            this.chkMultiLine.Size = new System.Drawing.Size(73, 19);
            this.chkMultiLine.TabIndex = 10;
            this.chkMultiLine.Text = "Multiline";
            this.toolTipGlobal.SetToolTip(this.chkMultiLine, "Changes ^ and $ to match at beginning and end of any line, not just beginning and" +
        " end of string");
            this.chkMultiLine.UseVisualStyleBackColor = true;
            // 
            // chkSingleline
            // 
            this.chkSingleline.AutoSize = true;
            this.chkSingleline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSingleline.Location = new System.Drawing.Point(243, 52);
            this.chkSingleline.Name = "chkSingleline";
            this.chkSingleline.Size = new System.Drawing.Size(77, 19);
            this.chkSingleline.TabIndex = 11;
            this.chkSingleline.Text = "Singleline";
            this.toolTipGlobal.SetToolTip(this.chkSingleline, "Changes meaning of .(dot) to match every character including \\n");
            this.chkSingleline.UseVisualStyleBackColor = true;
            // 
            // chkLinebyline
            // 
            this.chkLinebyline.AutoSize = true;
            this.chkLinebyline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLinebyline.Location = new System.Drawing.Point(326, 52);
            this.chkLinebyline.Name = "chkLinebyline";
            this.chkLinebyline.Size = new System.Drawing.Size(90, 19);
            this.chkLinebyline.TabIndex = 12;
            this.chkLinebyline.Text = "Line-by-line";
            this.toolTipGlobal.SetToolTip(this.chkLinebyline, "Split the string on \\n, and apply the regex to each line");
            this.chkLinebyline.UseVisualStyleBackColor = true;
            // 
            // toolTipGlobal
            // 
            this.toolTipGlobal.Tag = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtPattern,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
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
            // txtPattern
            // 
            this.txtPattern.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(700, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 84);
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
            this.Num,
            this.GroupIdx,
            this.Group,
            this.Line,
            this.MatchIdx,
            this.MatchText,
            this.LineStartPos,
            this.LineEndPos});
            this.dataGridMatches.Location = new System.Drawing.Point(0, 0);
            this.dataGridMatches.Name = "dataGridMatches";
            this.dataGridMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMatches.Size = new System.Drawing.Size(1077, 347);
            this.dataGridMatches.TabIndex = 11;
            this.dataGridMatches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMatches_CellClick);
            this.dataGridMatches.SelectionChanged += new System.EventHandler(this.dataGridMatches_SelectionChanged);
            // 
            // Num
            // 
            this.Num.HeaderText = "No.";
            this.Num.Name = "Num";
            // 
            // GroupIdx
            // 
            this.GroupIdx.HeaderText = "Group No.";
            this.GroupIdx.Name = "GroupIdx";
            this.GroupIdx.ReadOnly = true;
            // 
            // Group
            // 
            this.Group.HeaderText = "Group Name";
            this.Group.Name = "Group";
            // 
            // Line
            // 
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            // 
            // MatchIdx
            // 
            this.MatchIdx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MatchIdx.HeaderText = "Match Position";
            this.MatchIdx.Name = "MatchIdx";
            // 
            // MatchText
            // 
            this.MatchText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MatchText.HeaderText = "Match Text";
            this.MatchText.Name = "MatchText";
            // 
            // LineStartPos
            // 
            this.LineStartPos.HeaderText = "LineStartPos";
            this.LineStartPos.Name = "LineStartPos";
            this.LineStartPos.Visible = false;
            // 
            // LineEndPos
            // 
            this.LineEndPos.HeaderText = "LineEndPos";
            this.LineEndPos.Name = "LineEndPos";
            this.LineEndPos.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtInputText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridMatches);
            this.splitContainer1.Size = new System.Drawing.Size(1077, 740);
            this.splitContainer1.SplitterDistance = 389;
            this.splitContainer1.TabIndex = 18;
            // 
            // txtInputText
            // 
            this.txtInputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputText.BackColor = System.Drawing.Color.Transparent;
            this.txtInputText.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputText.Location = new System.Drawing.Point(0, 0);
            this.txtInputText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.Size = new System.Drawing.Size(1077, 390);
            this.txtInputText.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.lblMatchCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 841);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1077, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel4.Text = "Matches:";
            // 
            // lblMatchCount
            // 
            this.lblMatchCount.Name = "lblMatchCount";
            this.lblMatchCount.Size = new System.Drawing.Size(13, 17);
            this.lblMatchCount.Text = "0";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1077, 24);
            this.mnuMain.TabIndex = 17;
            this.mnuMain.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSymbolToolStripMenuItem,
            this.wordWrapToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showSymbolToolStripMenuItem
            // 
            this.showSymbolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWhiteSpaceAndTABToolStripMenuItem,
            this.showEndOfLineToolStripMenuItem,
            this.showAllCharactersToolStripMenuItem,
            this.showWrapSymbolToolStripMenuItem});
            this.showSymbolToolStripMenuItem.Name = "showSymbolToolStripMenuItem";
            this.showSymbolToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.showSymbolToolStripMenuItem.Text = "Show Symbol";
            // 
            // showWhiteSpaceAndTABToolStripMenuItem
            // 
            this.showWhiteSpaceAndTABToolStripMenuItem.CheckOnClick = true;
            this.showWhiteSpaceAndTABToolStripMenuItem.Name = "showWhiteSpaceAndTABToolStripMenuItem";
            this.showWhiteSpaceAndTABToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.showWhiteSpaceAndTABToolStripMenuItem.Text = "Show White Space and TAB";
            this.showWhiteSpaceAndTABToolStripMenuItem.Click += new System.EventHandler(this.showWhiteSpaceAndTABToolStripMenuItem_Click);
            // 
            // showEndOfLineToolStripMenuItem
            // 
            this.showEndOfLineToolStripMenuItem.CheckOnClick = true;
            this.showEndOfLineToolStripMenuItem.Name = "showEndOfLineToolStripMenuItem";
            this.showEndOfLineToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.showEndOfLineToolStripMenuItem.Text = "Show End of Line";
            this.showEndOfLineToolStripMenuItem.Click += new System.EventHandler(this.showEndOfLineToolStripMenuItem_Click);
            // 
            // showAllCharactersToolStripMenuItem
            // 
            this.showAllCharactersToolStripMenuItem.CheckOnClick = true;
            this.showAllCharactersToolStripMenuItem.Name = "showAllCharactersToolStripMenuItem";
            this.showAllCharactersToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.showAllCharactersToolStripMenuItem.Text = "Show All Characters";
            this.showAllCharactersToolStripMenuItem.Click += new System.EventHandler(this.showAllCharactersToolStripMenuItem_Click);
            // 
            // showWrapSymbolToolStripMenuItem
            // 
            this.showWrapSymbolToolStripMenuItem.CheckOnClick = true;
            this.showWrapSymbolToolStripMenuItem.Name = "showWrapSymbolToolStripMenuItem";
            this.showWrapSymbolToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.showWrapSymbolToolStripMenuItem.Text = "Show Wrap Symbol";
            this.showWrapSymbolToolStripMenuItem.Click += new System.EventHandler(this.showWrapSymbolToolStripMenuItem_Click);
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Checked = true;
            this.wordWrapToolStripMenuItem.CheckOnClick = true;
            this.wordWrapToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.wordWrapToolStripMenuItem.Text = "Word wrap";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(767, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1077, 863);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkGlobal);
            this.Controls.Add(this.chkLinebyline);
            this.Controls.Add(this.chkSingleline);
            this.Controls.Add(this.chkMultiLine);
            this.Controls.Add(this.chkIgnoreCase);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "RegexTester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMatches)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkGlobal;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.CheckBox chkMultiLine;
        private System.Windows.Forms.CheckBox chkSingleline;
        private System.Windows.Forms.CheckBox chkLinebyline;
        private System.Windows.Forms.ToolTip toolTipGlobal;
        private SciTextBoxControl txtInputText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtPattern;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblMatchCount;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllCharactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWhiteSpaceAndTABToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEndOfLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWrapSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchIdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchText;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineStartPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineEndPos;
        private System.Windows.Forms.Button btnSearch;
    }
}

