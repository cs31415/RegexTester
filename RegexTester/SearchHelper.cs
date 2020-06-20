using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexTester
{
    /// <summary>
    /// Search helper that applies regular expression pattern to input and
    /// returns matches
    /// </summary>
    public class SearchHelper
    {
        public IList<MatchResult> Match(SearchSettings settings)
        {
            var matchResults = new List<MatchResult>();
            if (settings.Pattern != "")
            {
                // Split input into lines in order to return matched line number
                var matches = Regex.Matches(
                    settings.Text, @"[^\r\n]*(\n|\r\n?)",
                    RegexOptions.Multiline | RegexOptions.Compiled);

                if (settings.LineByLine)
                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var match = matches[i];
                        matchResults.AddRange(MatchLine(match.Value, settings, matches, i+1));
                    }
                }
                else
                {
                    matchResults.AddRange(MatchLine(settings.Text, settings, matches, 1));
                }
            }

            return matchResults;
        }

        private IList<MatchResult> MatchLine(string line, SearchSettings settings, MatchCollection lines, int lineNum)
        {
            var matchResults = new List<MatchResult>();

            RegexOptions opt = settings.IgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            opt = settings.SingleLine ? opt | RegexOptions.Singleline : opt;
            opt = settings.MultiLine ? opt | RegexOptions.Multiline : opt;
            Regex rx = new Regex(settings.Pattern, opt);

            if (settings.Global)
            {
                MatchCollection matches = rx.Matches(line);
                for (int i = 0; i < matches.Count; i++)
                {
                    Match m = matches[i];
                    matchResults.AddRange(PopulateGroups(m, rx, i + 1, lines, settings, lineNum));
                }
            }
            else
            {
                Match m = rx.Match(line);
                matchResults.AddRange(PopulateGroups(m, rx, 1, lines, settings, lineNum));
            }

            return matchResults;
        }

        private IList<MatchResult> PopulateGroups(Match m, Regex rx, int matchNum, MatchCollection lines, SearchSettings settings, int lineNum)
        {
            var matchResults = new List<MatchResult>();
            int startIndex = m.Groups.Count > 1 ? 1 : 0;
            for (int i = startIndex; i < m.Groups.Count; i++)
            {
                Group g = m.Groups[i];
                string name = rx.GroupNameFromNumber(i);
                int matchIndex = g.Index;
                int lineStartPos = 0;
                int lineEndPos = 0;
                int lineNumber = 0;

                if (!string.IsNullOrWhiteSpace(g.Value))
                {
                    if (settings.LineByLine)
                    {
                        var line = lines[lineNum - 1];
                        lineStartPos = line.Index + 1;
                        lineEndPos = line.Index + line.Length + 1;
                        lineNumber = lineNum;
                        matchIndex += lineStartPos - 1;
                    }
                    else
                    {
                        for (int j = 0; j < lines.Count; j++)
                        {
                            Match line = lines[j];
                            if (matchIndex > line.Index && matchIndex < line.Index + line.Length)
                            {
                                lineStartPos = line.Index + 1;
                                lineEndPos = line.Index + line.Length + 1;
                                lineNumber = j + 1;
                                break;
                            }
                        }
                    }

                    matchResults.Add(new MatchResult
                    {
                        Capture = g,
                        MatchNum = matchNum,
                        GroupNum = 1 + i,
                        GroupName = name,
                        LineNum = lineNumber,
                        MatchPos = matchIndex + 1,
                        MatchText = g.Value,
                        LineStartPos = lineStartPos,
                        LineEndPos = lineEndPos
                    });
                }
            }

            return matchResults;
        }
    }
}
