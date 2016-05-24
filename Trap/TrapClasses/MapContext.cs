using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapClasses
{
    public class MapContext
    {
        public List<Tuple<int, int>> BlockedSpaces { get; set; }
        public Tuple<int, int> CurrentPosition { get; set; }
        public List<Tuple<int,int>> PossibleSpaces { get; set; }
        public Strategy Strategy { get; set; }

        public MapContext()
        {
            BlockedSpaces = new List<Tuple<int, int>>();
            PossibleSpaces = new List<Tuple<int, int>>();
        }
        public void SetStrategy(Strategy s)
        {
            Strategy = s;
        }

        public Tuple<int, int> Analyze()
        {
           return Strategy.Analyze(CurrentPosition, BlockedSpaces);
        }
    }
}
