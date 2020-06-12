using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Reflection;

namespace RegexTestHarness
{
    public delegate void dlgHighlightMatches(Match m);
    public delegate void dlgResumeLayout();

    public partial class MainForm : Form
    {
        public static string m_input = "";
        public static string m_pattern = "";
        const string cacheFileName = @"cache.xml";
        public static bool m_isGlobal = false;
        private static bool m_ignoreCase = false;
        private static bool m_singleLine = false;
        private static bool m_multiLine = false;
        private static bool m_lineByLine = false;
        private static DateTime m_StartTime = DateTime.Now;
        private static TimeSpan m_elapsedTime;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_input = richTextBoxOutput.Text.Trim();
            m_pattern = textBoxPattern.Text.Trim();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (File.Exists(string.Format(@"{0}\{1}", path, cacheFileName)))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(cacheFileName);

                string xpath = "";
                XmlNode node = null;
                if (m_input == "")
                {
                    //load from cache
                    xpath = "//RegexCache/Input";
                    node = xd.SelectSingleNode(xpath);
                    m_input = node.FirstChild.Value;
                    richTextBoxOutput.Text = m_input;
                }
                if (m_pattern == "")
                {
                    //load from cache
                    xpath = "//RegexCache/Pattern";
                    node = xd.SelectSingleNode(xpath);
                    m_pattern = node.FirstChild.Value;
                    textBoxPattern.Text = m_pattern;
                }

                xpath = "//RegexCache";
                node = xd.SelectSingleNode(xpath);
                m_isGlobal = Convert.ToBoolean(node.Attributes["Global"].Value);
                checkBoxGlobal.Checked = m_isGlobal;

                m_ignoreCase = Convert.ToBoolean(node.Attributes["IgnoreCase"].Value);
                checkBoxIgnoreCase.Checked = m_ignoreCase;
                
                m_singleLine = Convert.ToBoolean(node.Attributes["SingleLine"].Value);
                checkBoxSingleline.Checked = m_singleLine;

                m_multiLine = Convert.ToBoolean(node.Attributes["MultiLine"].Value);
                checkBoxMultiLine.Checked = m_multiLine;

                m_lineByLine = Convert.ToBoolean(node.Attributes["LineByLine"].Value);
                checkBoxLinebyline.Checked = m_lineByLine;
            }
        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            m_input = richTextBoxOutput.Text.Trim();
            m_pattern = textBoxPattern.Text.Trim();
            m_isGlobal = checkBoxGlobal.Checked;
            m_ignoreCase = checkBoxIgnoreCase.Checked;
            m_singleLine = checkBoxSingleline.Checked;
            m_multiLine = checkBoxMultiLine.Checked;
            m_lineByLine = checkBoxLinebyline.Checked;

            DoMatch();
        }

        private void DoMatch()
        {
            this.Cursor = Cursors.WaitCursor;
            this.labelStatus.Text = "Working...";
            Timer timer = new Timer();
            StartTimer();

            //clear prior matches
            this.SuspendLayout();
            richTextBoxOutput.SelectAll();
            richTextBoxOutput.SelectionBackColor = Color.Transparent;
            
            //save to cache
            using (XmlTextWriter xw = new XmlTextWriter(cacheFileName, Encoding.UTF8))
            {
                xw.Formatting = Formatting.Indented;
                xw.WriteStartDocument();

                xw.WriteStartElement("RegexCache");

                xw.WriteAttributeString("Global", m_isGlobal.ToString());
                xw.WriteAttributeString("IgnoreCase", m_ignoreCase.ToString());
                xw.WriteAttributeString("SingleLine", m_singleLine.ToString());
                xw.WriteAttributeString("MultiLine", m_multiLine.ToString());
                xw.WriteAttributeString("LineByLine", m_lineByLine.ToString());
               
                xw.WriteStartElement("Pattern");
                xw.WriteCData(m_pattern);
                xw.WriteEndElement();

                xw.WriteStartElement("Input");
                xw.WriteCData(m_input);
                xw.WriteEndElement();
            }

            //Thread t = new Thread (new ParameterizedThreadStart(DoMatchThreadFunc));
            //t.Start();
            DoMatchThreadFunc(null);
            //t.Join();
            StopTimer();
            this.Cursor = Cursors.Default;
            this.labelStatus.Text = "Ready";
            this.labelTime.Text = m_elapsedTime.ToString();
        }

        void DoMatchThreadFunc(object threadParams)
        {
            if (m_pattern != "")
            {
                if (m_lineByLine)
                {
                    m_input.Replace("\r\n", "\n");
                    string[] lines = m_input.Split(new char[] { '\n' }, StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        MatchLine(line);
                    }
                }
                else
                {
                    MatchLine(m_input);
                }
            }
            DoResumeLayout();
        }

        private void MatchLine(string line)
        {
            RegexOptions opt = m_ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            opt = m_singleLine ? opt | RegexOptions.Singleline : opt;
            opt = m_multiLine ? opt | RegexOptions.Multiline : opt;
            Regex rx = new Regex(m_pattern, opt);

            if (m_isGlobal)
            {
                MatchCollection matches = rx.Matches(line);
                PopulateGroups(matches, rx);
                for (int i = 0; i < matches.Count; i++)
                {
                    Match m = matches[i];
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
            if (this.richTextBoxOutput.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                dlgHighlightMatches d = new dlgHighlightMatches(HighlightMatches);
                this.Invoke(d, new object[] { m });
            }
            else
            {
                HighlightMatches(m);
            }        
        }
        
        private void PopulateGroups(MatchCollection mc, Regex rx)
        {
            dataGridMatches.Rows.Clear();
            foreach(Match m in mc)
            {
                for (int i = 0; i < m.Groups.Count; i++)
                {
                    Group g = m.Groups[i];
                    string name = rx.GroupNameFromNumber(i);
                    string idx = g.Index.ToString().PadRight(5);

                    dataGridMatches.Rows.Add(new object[]
                    {
                        i.ToString(), name, idx, g.Value
                    });
                }
            }
        }

        private void PopulateGroups(Match m, Regex rx)
        {
            dataGridMatches.Rows.Clear();
            for(int i=0; i<m.Groups.Count; i++)
            {
                Group g = m.Groups[i];
                string name = rx.GroupNameFromNumber(i);
                string idx = g.Index.ToString().PadRight(5);
                dataGridMatches.Rows.Add(new object[]
                {
                    i.ToString(), name, idx, g.Value
                });
            }
        }
        
        private void DoResumeLayout()
        {
            if (this.richTextBoxOutput.InvokeRequired)
            {
                dlgResumeLayout d = new dlgResumeLayout(ResumeLayout2);
                this.Invoke(d);
            }
            else
                ResumeLayout2();
        }

        private void ResumeLayout2()
        {
            this.ResumeLayout();
        }

        private void HighlightMatches(Match m)
        {
            if (m.Success)
            {
                foreach (Capture c in m.Captures)
                {
                    richTextBoxOutput.Select(c.Index, c.Length);
                    richTextBoxOutput.SelectionBackColor = Color.Orange;
                }
            }
        }

        public static void StartTimer()
        {
            m_StartTime = DateTime.Now;
        }
        public static void StopTimer()
        {
            DateTime endTime = DateTime.Now;
            m_elapsedTime = endTime - m_StartTime;
        }
    }
}
