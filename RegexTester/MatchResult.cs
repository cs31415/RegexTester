using System.Text.RegularExpressions;

namespace RegexTester
{
    public class MatchResult
    {
        public Capture Capture { get; set; }
        public int MatchNum { get; set; }
        public int GroupNum { get; set; }
        public string GroupName { get; set; }
        public int LineNum { get; set; }
        public int MatchPos { get; set; }
        public string MatchText { get; set; }
        public int LineStartPos { get; set; }
        public int LineEndPos { get; set; }
    }
}
