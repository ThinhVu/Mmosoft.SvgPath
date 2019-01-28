using System;
using System.Collections.Generic;

namespace ConsoleApp7.CommandProcess
{
    public class LineTo : CmdProcess
    {
        public LineTo(bool relativePosition) : base(relativePosition)
        {
        }

        public override void Process(List<string> tokenize, ref int index)
        {
            index++; // skip command
            var nums = new List<string>();
            string temp;
            while (index < tokenize.Count)
            {
                temp = tokenize[index];
                if (temp.Length == 1 && !char.IsDigit(temp[0]))
                {
                    // only have 1 char and first char is not digit => next command
                    index--;
                    break;
                }
                else
                {
                    nums.Add(temp);
                    index++;
                }
            }

            // build point
            if (nums.Count % 2 != 0)
                throw new Exception("Argument missing!");

            var points = new List<string>();
            for (int i = 0; i < nums.Count; i += 2)
            {
                points.Add("(" + nums[i] + " " + nums[i + 1] + ")");
            }

            Console.WriteLine(
                "Line to position {0} {1}",
                string.Join(", then to ", points.ToArray()),
                this.absolutePosition ? "" : "relative.");
        }
    }
}
