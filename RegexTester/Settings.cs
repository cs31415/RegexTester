namespace RegexTester
{
    /// <summary>
    /// Settings to persist
    /// </summary>
    public class Settings
    {
        public string Pattern { get; set; }
        public string Text { get; set; }
        public bool Global { get; set; }
        public bool IgnoreCase { get; set; }
        public bool MultiLine { get; set; }
        public bool SingleLine { get; set; }
        public bool LineByLine { get; set; }
    }
}