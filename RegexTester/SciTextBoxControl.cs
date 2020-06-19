using System;
using System.Windows.Forms;

namespace RegexTester
{
    public partial class SciTextBoxControl : UserControl
    {
        public SciTextBox TextBox { get; set; }
        public SciTextBoxControl()
        {
            InitializeComponent();

            txtEditor.UpdateUI += TxtFileViewer_UpdateUI; ;
            txtEditor.Resize += TxtFileViewerOnResize;
            txtEditor.TextChanged += TxtFileViewerOnTextChanged;

            TextBox = txtEditor;
        }

        private void TxtFileViewerOnTextChanged(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void TxtFileViewerOnResize(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void TxtFileViewer_UpdateUI(object sender, ScintillaNET.UpdateUIEventArgs e)
        {
            UpdateStats();
        }

        private void UpdateStats()
        {
            lblPosition.Text = (1 + txtEditor.CurrentPosition).ToString();
            lblSelection.Text = txtEditor.SelectedText.Length.ToString();
            lblLineNumber.Text = (1 + txtEditor.CurrentLine).ToString();
            lblColumnNumber.Text = (1 + txtEditor.GetColumn(txtEditor.CurrentPosition)).ToString();
        }
    }
}
