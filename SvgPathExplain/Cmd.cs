using System.Collections.Generic;

namespace SVGPathExplain
{
    public class Cmd
    {
        public static readonly string[] AbsoluteCmdChars = new string[] {
            "M", "L", "H", "V", "C", "S", "Q", "T", "A",  "Z"
        };
        public static readonly string[] RelativeCmdChars = new string[] {
            "m", "l", "h", "v", "c", "s", "q", "t", "a", "z"
        };

        public float X;
        public float Y;

        public Cmd PrevCmd;
        public string CmdText { get; set; }
        public List<float> Params { get; set; }

        public Cmd()
        {
            this.CmdText = "";
            this.Params = new List<float>();
        }

        public override string ToString()
        {
            return $"Cmd: {CmdText} Pos:({X}, {Y}) Params: {string.Join(", ", Params.ToArray())}";
        }
    }
}
