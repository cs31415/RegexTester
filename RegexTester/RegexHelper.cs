using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexTester
{
    public class SearchOptions
    {
        public bool IsGlobal { get; set; }
        public bool IgnoreCase{ get; set; }
        public bool SingleLine{ get; set; }
        public bool MultiLine{ get; set; }
        public bool LineByLine{ get; set; }
    }

    public class RegexHelper
    {
        public RegexHelper()
        {
        }

        public IList<MatchResult> Match(string input, string pattern, SearchOptions options)
        {
            var matchResults = new List<MatchResult>();
            if (pattern != "")
            {
                var matches = Regex.Matches(
                    input, @"[^\r\n]*(\n|\r\n?)",
                    RegexOptions.Multiline | RegexOptions.Compiled);
                Func<int, Match> getLine =
                (pos) =>
                {
                    foreach (Match match in matches)
                    {
                        if (pos > match.Index && pos < match.Index + match.Length)
                        {
                            return match;
                        }
                    }

                    return null;
                };

                if (options.LineByLine)
                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                        var match = matches[i];
                        matchResults.AddRange(MatchLine(match.Value, pattern, options, matches));
                    }
                }
                else
                {
                    matchResults.AddRange(MatchLine(input, pattern, options, matches));
                }
            }

            return matchResults;
        }

        private IList<MatchResult> MatchLine(string line, string pattern, SearchOptions options, MatchCollection lines)
        {
            var matchResults = new List<MatchResult>();

            RegexOptions opt = options.IgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            opt = options.SingleLine ? opt | RegexOptions.Singleline : opt;
            opt = options.MultiLine ? opt | RegexOptions.Multiline : opt;
            Regex rx = new Regex(pattern, opt);

            if (options.IsGlobal)
            {
                MatchCollection matches = rx.Matches(line);
                for (int i = 0; i < matches.Count; i++)
                {
                    Match m = matches[i];
                    matchResults.AddRange(PopulateGroups(m, rx, i + 1, lines));
                }
            }
            else
            {
                Match m = rx.Match(line);
                matchResults.AddRange(PopulateGroups(m, rx, 1, lines));
            }

            return matchResults;
        }

        private IList<MatchResult> PopulateGroups(Match m, Regex rx, int matchNum, MatchCollection lines)
        {
            var matchResults = new List<MatchResult>();
            for (int i = 0; i < m.Groups.Count; i++)
            {
                Group g = m.Groups[i];
                string name = rx.GroupNameFromNumber(i);
                int matchIndex = g.Index;
                int lineStartPos = 0;
                int lineEndPos = 0;
                int lineNumber = 0;

                for(int j = 0; j < lines.Count; i++)
                {
                    Match line = lines[j];
                    if (matchIndex > line.Index && matchIndex < line.Index + line.Length)
                    {
                        lineStartPos = line.Index + 1;
                        lineEndPos = line.Index + line.Length + 1;
                        lineNumber = i + 1;
                        break;
                    }
                }

                matchResults.Add(new MatchResult
                {
                    MatchNum = matchNum,
                    GroupNum = 1 + i,
                    GroupName = name,
                    LineNum = lineNumber,
                    MatchPos = 1 + matchIndex,
                    MatchText = g.Value,
                    LineStartPos = lineStartPos,
                    LineEndPos = lineEndPos
                });
            }

            return matchResults;
        }
    }
}
