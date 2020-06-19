﻿using System.Drawing;
using System.Windows.Forms;
using ScintillaNET;

namespace RegexTester
{
    public enum HighlightLayer
    {
        LineLayer = 7,
		WordLayer = 8,
		HighlightWordLayer = 9
    }

	public class SciTextBox : Scintilla
	{
		/// <summary>
		/// change this to whatever margin you want the line numbers to show in
		/// </summary>
		private const int NUMBER_MARGIN = 1;

		/// <summary>
		/// change this to whatever margin you want the bookmarks/breakpoints to show in
		/// </summary>
		private const int BOOKMARK_MARGIN = 2;
		private const int BOOKMARK_MARKER = 2;

		public SciTextBox()
		{
			Dock = System.Windows.Forms.DockStyle.Fill;

			// INITIAL VIEW CONFIG
			WrapMode = WrapMode.Word;
			IndentationGuides = IndentView.LookBoth;
			
			InitColors();
			InitSyntaxColoring();
			InitNumberMargin();
        }

		#region Public methods
		public void HighlightSelection(int startIndex, int endIndex, Color color, HighlightLayer layer)
		{
			int NUM = (int)layer;

			// Remove all uses of our indicator
			this.IndicatorCurrent = NUM;

			// Update indicator appearance
			this.Indicators[NUM].Style = IndicatorStyle.FullBox;
			this.Indicators[NUM].Under = true;
			this.Indicators[NUM].ForeColor = color;
			this.Indicators[NUM].Alpha = 200;

			this.IndicatorFillRange(startIndex, endIndex - startIndex);
		}

        public void UnHighlightSelection(int startIndex, int endIndex, HighlightLayer layer)
        {
			int NUM = (int)layer;

            // Remove all uses of our indicator
            this.IndicatorCurrent = NUM;
			this.IndicatorClearRange(startIndex, endIndex - startIndex);
        }

		#endregion

        #region Event handlers
		private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
		{
			if (e.Margin == BOOKMARK_MARGIN)
			{
				// Do we have a marker for this line?
				const uint mask = (1 << BOOKMARK_MARKER);
				var line = Lines[LineFromPosition(e.Position)];
				if ((line.MarkerGet() & mask) > 0)
				{
					// Remove existing bookmark
					line.MarkerDelete(BOOKMARK_MARKER);
				}
				else
				{
					// Add bookmark
					line.MarkerAdd(BOOKMARK_MARKER);
				}
			}
		}

		#endregion

		#region Private methods
		private void InitColors()
        {
            SetSelectionBackColor(true, Color.LightBlue);
            SetWhitespaceForeColor(true, Color.DarkOrange);
        }

        private void InitSyntaxColoring()
        {
            // Configure the default style
            StyleResetDefault();
            Styles[Style.Default].Font = "Lucida Console";
            Styles[Style.Default].Size = 10;
            Styles[Style.Default].BackColor = Color.White;
            Styles[Style.Default].ForeColor = Color.Black;
            StyleClearAll();
        }

        private void InitNumberMargin()
        {
            Styles[Style.LineNumber].BackColor = Color.WhiteSmoke;
            this.Styles[Style.IndentGuide].ForeColor = Color.Gray;
            this.Styles[Style.IndentGuide].BackColor = Color.LightGray;

            var nums = Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            MarginClick += TextArea_MarginClick;
        }

        #endregion 
	}
}
