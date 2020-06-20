using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScintillaNET;

namespace RegexTester
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Inputs
        /// </summary>
        private string Input { get => txtInputText.TextBox.Text; set => txtInputText.TextBox.Text = value; }
        private string Pattern { get => txtPattern.Text.Trim(); set => txtPattern.Text = value; }
        private bool Global { get => chkGlobal.Checked; set => chkGlobal.Checked = value; }
        private bool IgnoreCase { get => chkIgnoreCase.Checked; set => chkIgnoreCase.Checked = value; }
        private bool SingleLine { get => chkSingleline.Checked; set => chkSingleline.Checked = value; }
        private bool MultiLine { get => chkMultiLine.Checked; set => chkMultiLine.Checked = value; }
        private bool LineByLine { get => chkLinebyline.Checked; set => chkLinebyline.Checked = value; }

        private readonly SettingsManager<SearchSettings> _settingsManager;

        delegate void DlgHighlightMatches(Match m);
        delegate void DlgResumeLayout();
        delegate void DelegateMethod(params object[] args);

        public MainForm()
        {
            InitializeComponent();
            _settingsManager = new SettingsManager<SearchSettings>(OnLoadSettings, OnSaveSettings);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //clear prior matches
            this.SuspendLayout();
            ClearAllHighlights();
            dataGridMatches.Rows.Clear();

            if (Pattern != "")
            {
                var searchHelper = new SearchHelper();
                var searchSettings = new SearchSettings
                {
                    Text = Input,
                    Pattern = Pattern,
                    IgnoreCase = IgnoreCase,
                    Global = Global,
                    LineByLine = LineByLine,
                    MultiLine = MultiLine,
                    SingleLine = SingleLine
                };
                var results = searchHelper.Match(searchSettings);

                var matchCount = results.Count;
                SetLabelText(lblMatchCount, matchCount.ToString());

                foreach (var result in results)
                {
                    dataGridMatches.Rows.Add(
                        result.MatchNum.ToString(),
                        result.GroupNum.ToString(),
                        result.GroupName,
                        result.LineNum.ToString(),
                        result.MatchPos.ToString(),
                        result.MatchText,
                        result.LineStartPos.ToString(),
                        result.LineEndPos.ToString()
                    );
                    DoHighlight(result.Capture);
                }

                if (matchCount > 0)
                {
                    dataGridMatches.Rows[0].Selected = true;
                }
            }
            DoResumeLayout();

            this.Cursor = Cursors.Default;
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

        private void OnLoadSettings(SearchSettings settings)
        {
            Input = settings.Text;
            Pattern = settings.Pattern;
            Global = settings.Global;
            IgnoreCase = settings.IgnoreCase;
            LineByLine = settings.LineByLine;
            MultiLine = settings.MultiLine;
            SingleLine = settings.SingleLine;
        }

        private SearchSettings OnSaveSettings()
        {
            var settings = new SearchSettings
            {
                Pattern = Pattern,
                Text = Input,
                Global = Global,
                IgnoreCase = IgnoreCase,
                LineByLine = LineByLine,
                MultiLine = MultiLine,
                SingleLine = SingleLine
            };
            return settings;
        }

        private void DoHighlight(Capture c)
        {
            if (this.txtInputText.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                DlgHighlightMatches d = HighlightMatches;
                this.Invoke(d, c);
            }
            else
            {
                HighlightMatches(c);
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

        private void HighlightMatches(Capture c)
        {
            HighlightSelection(1 + c.Index, 1 + c.Index + c.Length, Color.BurlyWood, HighlightLayer.WordLayer);
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
    }
}
