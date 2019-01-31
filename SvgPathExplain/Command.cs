using System.Collections.Generic;

namespace SVGPathExplain
{
    public class Command
    {
        public Command PrevCmd { get; set; }
        public string CommandText { get; set; }
        public List<float> Params { get; set; }

        public Command(string cmdText)
        {
            this.CommandText = cmdText;
            this.Params = new List<float>();
        }
    }
}
