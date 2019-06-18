using System.Collections.Generic;

namespace SVGPath
{
    public class Cmd
    {
        // position
        public float X;
        public float Y;
        // command
        public string Text;
        // params
        public List<float> Params;

        public Cmd()
        {
            this.Text = "";
            this.Params = new List<float>();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Text, string.Join(" ", Params.ToArray()));
        }
    }
}
