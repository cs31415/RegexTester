using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScintillaNET;

namespace RegexTester
{
    public partial class MainForm : Form
    {
        // -- todo delete
        private string _input = "";
        private string _pattern = "";
        private bool _isGlobal;
        private bool _ignoreCase;
        private bool _singleLine;
        private bool _multiLine;
        private bool _lineByLine;
        // -- todo delete

        private readonly SettingsManager _settingsManager;
        delegate void DlgHighlightMatches(Match m);
        delegate void DlgResumeLayout();
        delegate void DelegateMethod(params object[] args);

        


        public MainForm()
        {
            InitializeComponent();
            _settingsManager = new SettingsManager(OnLoadSettings, OnSaveSettings);
        }

        #region Event handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            _settingsManager.LoadSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingsManager.SaveSettings();
        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            // -- todo delete
            _input = txtInputText.TextBox.Text;
            _pattern = txtPattern.Text.Trim();
            _isGlobal = chkGlobal.Checked;
            _ignoreCase = chkIgnoreCase.Checked;
            _singleLine = chkSingleline.Checked;
            _multiLine = chkMultiLine.Checked;
            _lineByLine = chkLinebyline.Checked;
            // -- todo delete

            DoMatch();
        }

        private void dataGridMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OnSelectRow();
        }

        private void dataGridMatches_SelectionChanged(object sender, EventArgs e)
        {
            OnSelectRow();
        }

        private void showWhiteSpaceAndTABToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var showWhitespace = showWhiteSpaceAndTABToolStripMenuItem.Checked;
            ToggleWhiteSpace(showWhitespace);

            if (showWhitespace && showEndOfLineToolStripMenuItem.Checked)
            {
                showEndOfLineToolStripMenuItem.Checked = false;
                ToggleEol(false);
            }
        }

        private void showEndOfLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var showEol = showEndOfLineToolStripMenuItem.Checked;
            ToggleEol(showEol);

            if (showEol && showWhiteSpaceAndTABToolStripMenuItem.Checked)
            {
                showWhiteSpaceAndTABToolStripMenuItem.Checked = false;
                ToggleWhiteSpace(false);
            }
        }

        private void showAllCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showEndOfLineToolStripMenuItem.Checked = showWhiteSpaceAndTABToolStripMenuItem.Checked = false;

            var showAll = showAllCharactersToolStripMenuItem.Checked;
            ToggleWhiteSpace(showAll);
            ToggleEol(showAll);
        }

        private void showWrapSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var showWrapSymbol = showWrapSymbolToolStripMenuItem.Checked;
            txtInputText.TextBox.WrapVisualFlags = showWrapSymbol ? WrapVisualFlags.End : WrapVisualFlags.None;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wordWrap = wordWrapToolStripMenuItem.Checked;
            txtInputText.TextBox.WrapMode = wordWrap ? WrapMode.Word : WrapMode.None;
        }

        #endregion

        #region  Private methods

        private void OnLoadSettings(Settings settings)
        {
            txtInputText.TextBox.Text = settings.Text;
            txtPattern.Text = settings.Pattern;
            chkGlobal.Checked = settings.Global;
            chkIgnoreCase.Checked = settings.IgnoreCase;
            chkLinebyline.Checked = settings.LineByLine;
            chkMultiLine.Checked = settings.MultiLine;
            chkSingleline.Checked = settings.SingleLine;
        }

        private Settings OnSaveSettings()
        {
            var settings = new Settings();
            settings.Pattern = txtPattern.Text;
            settings.Text = txtInputText.TextBox.Text;
            settings.Global = chkGlobal.Checked;
            settings.IgnoreCase = chkIgnoreCase.Checked;
            settings.LineByLine = chkLinebyline.Checked;
            settings.MultiLine = chkMultiLine.Checked;
            settings.SingleLine = chkSingleline.Checked;
            return settings;
        }

        private void DoMatch()
        {
            this.Cursor = Cursors.WaitCursor;

            //clear prior matches
            this.SuspendLayout();
            ClearAllHighlights();
            dataGridMatches.Rows.Clear();

            if (_pattern != "")
            {
                if (_lineByLine)
                {
                    var matches = Regex.Matches(
                        _input, @"[^\r\n]*(\n|\r\n?)", 
                        RegexOptions.Multiline | RegexOptions.Compiled);
                    for (int i=0; i<matches.Count; i++)
                    {
                        var match = matches[i];
                        MatchLine(match.Value);
                    }
                }
                else
                {
                    MatchLine(_input);
                }

                var matchCount = dataGridMatches.RowCount;
                SetLabelText(lblMatchCount, matchCount.ToString());
                if (matchCount > 0)
                {
                    dataGridMatches.Rows[0].Selected = true;
                }
            }
            DoResumeLayout();

            this.Cursor = Cursors.Default;
        }

        private void MatchLine(string line)
        {
            RegexOptions opt = _ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            opt = _singleLine ? opt | RegexOptions.Singleline : opt;
            opt = _multiLine ? opt | RegexOptions.Multiline : opt;
            Regex rx = new Regex(_pattern, opt);
            
            if (_isGlobal)
            {
                MatchCollection matches = rx.Matches(line);
                for (int i = 0; i < matches.Count; i++)
                {
                    Match m = matches[i];
                    PopulateGroups(m, rx, i+1);
                    DoHighlight(m);
                }
            }
            else
            {
                Match m = rx.Match(line);
                PopulateGroups(m, rx);
                DoHighlight(m);
            }
        }

        private void DoHighlight(Match m)
        {
            if (this.txtInputText.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                DlgHighlightMatches d = new DlgHighlightMatches(HighlightMatches);
                this.Invoke(d, new object[] { m });
            }
            else
            {
                HighlightMatches(m);
            }        
        }

        private void PopulateGroups(Match m, Regex rx, int matchNum = 1)
        {
            for(int i=0; i<m.Groups.Count; i++)
            {
                Group g = m.Groups[i];
                string name = rx.GroupNameFromNumber(i);
                int matchIndex = g.Index;
                string idx = (1 + matchIndex).ToString().PadRight(5);
                int lineNumber = txtInputText.TextBox.LineFromPosition(matchIndex);
                var line = txtInputText.TextBox.Lines[lineNumber];
                int lineStartPos = 1 + txtInputText.TextBox.Lines[lineNumber].Position;
                int lineEndPos = 1 + txtInputText.TextBox.Lines[lineNumber].EndPosition;
                dataGridMatches.Rows.Add(
                    matchNum.ToString(), 
                    (1+i).ToString(), 
                    name, 
                    (1+lineNumber).ToString(), 
                    idx, 
                    g.Value, 
                    lineStartPos.ToString(), 
                    lineEndPos.ToString());
            }
        }

        private void OnSelectRow()
        {
            if (dataGridMatches.CurrentRow == null || !dataGridMatches.Columns.Contains("MatchIdx") ||
                !dataGridMatches.Columns.Contains("MatchText"))
            {
                return;
            }

            int index = int.Parse((string)dataGridMatches.CurrentRow.Cells["MatchIdx"].Value);
            string text = (string)dataGridMatches.CurrentRow.Cells["MatchText"].Value;

            var textLength = txtInputText.TextBox.Text.Length;
            UnHighlightSelection(1, 1 + textLength, HighlightLayer.HighlightWordLayer);
            HighlightSelection(index, index + text.Length, Color.Orange, HighlightLayer.HighlightWordLayer);

            int lineStartPos = int.Parse((string)dataGridMatches.CurrentRow.Cells["LineStartPos"].Value);
            int lineEndPos = int.Parse((string)dataGridMatches.CurrentRow.Cells["LineEndPos"].Value);

            // unhighlight previous line if any
            UnHighlightSelection(1, 1 + textLength, HighlightLayer.LineLayer);

            // highlight current line
            HighlightSelection(lineStartPos, lineEndPos, Color.LemonChiffon, HighlightLayer.LineLayer);


            // Scroll view if selection is out of visible range
            int scrollStart = Math.Max(index, 0);
            int scrollEnd = Math.Min(index + text.Length, textLength - 1);
            txtInputText.TextBox.ScrollRange(scrollStart - 1, scrollEnd - 1);
        }

        private void DoResumeLayout()
        {
            if (txtInputText.InvokeRequired)
            {
                DlgResumeLayout d = ResumeLayout;
                this.Invoke(d);
            }
            else
                ResumeLayout();
        }

        private void HighlightMatches(Match m)
        {
            if (m.Success)
            {
                foreach (Capture c in m.Captures)
                {
                    HighlightSelection(1 + c.Index, 1 + c.Index + c.Length, Color.LightGray, HighlightLayer.WordLayer);
                }
            }
        }

        private void HighlightSelection(int startIndex, int endIndex, Color color, HighlightLayer layer)
        {
            txtInputText.TextBox.HighlightSelection(startIndex - 1, endIndex - 1, color, layer);
        }

        private void UnHighlightSelection(int startIndex, int endIndex, HighlightLayer layer)
        {
            txtInputText.TextBox.UnHighlightSelection(startIndex - 1, endIndex - 1, layer);
        }

        private void ClearAllHighlights()
        {
            var textLength = txtInputText.TextBox.Text.Length;
            UnHighlightSelection(1, 1 + textLength, HighlightLayer.HighlightWordLayer);
            UnHighlightSelection(1, 1 + textLength, HighlightLayer.WordLayer);
            UnHighlightSelection(1, 1 + textLength, HighlightLayer.LineLayer);
        }

        private void SetLabelText(ToolStripStatusLabel label, string text)
        {
            InvokeIfRequired(
                x =>
                {
                    label.Text = (string)x[0];
                },
                text);
        }

        private void InvokeIfRequired(DelegateMethod method, params object[] args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(method, new object[] { args });
            }
            else
            {
                method(args);
            }
        }

        private void ToggleEol(bool show)
        {
            txtInputText.TextBox.ViewEol = show;
        }

        private void ToggleWhiteSpace(bool show)
        {
            txtInputText.TextBox.ViewWhitespace = show ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
        }

        #endregion

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
