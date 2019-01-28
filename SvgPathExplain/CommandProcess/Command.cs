using System.Collections.Generic;

namespace SVGPathExplain.CommandProcess
{
    public class Command
    {
        public string CommandText { get; set; }
        public List<string> Paramenters { get; set; }

        public Command(string cmdText)
        {
            this.CommandText = cmdText;
            this.Paramenters = new List<string>();
        }
    }
}
