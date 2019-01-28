using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp7.CommandProcess
{
    public class CurveTo : CmdProcess
    {
        public CurveTo(bool relativePosition) : base(relativePosition)
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
            for (int i = 0; i < nums.Count; i += 6)
            {
                points.Add($"Draw a cubic Bézier curve from the current point to ({nums[i + 4]}, {nums[i+5]}) using ({nums[i]}, {nums[i+1]}) as the control point at the begining of the curve and ({nums[i+2]}, {nums[i+3]}) as the control point at the end of the curve");
            }

            Console.WriteLine("--------");
            Console.WriteLine(
                this.absolutePosition ? "[abs]" : "[rel]");
            Console.WriteLine(string.Join(Environment.NewLine, points.ToArray()));
            Console.WriteLine("--------");
        }
    }
}
