using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputTree
{
    internal class Step
    {
        public int step = 0;
        public Stack<string> stack = new Stack<string>();
        public int stringIndex = 0;
        public string outString = "";
        public string backPoints = "";
        public string innerResult = "";
        public string stars = "";
        public Dictionary<string, List<int>> usedProductions;
        public List<string> addings;
        public Step(int st,Stack<string> stac, int index,string oStr,string points, string inner,string star, Dictionary<string, List<int>> usedProductions, List<string> add)
        {
            step = st;
            stack = stac;
            stringIndex = index;
            outString = oStr;
            backPoints = points;
            innerResult = inner;
            stars = star;
            this.usedProductions = usedProductions;
            addings = add;
        }
    }
}
