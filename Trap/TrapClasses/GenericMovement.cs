using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapClasses
{
    public abstract class GenericMovement
    {
        public Tuple<int, int> MoveNorthEast(Tuple<int,int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1 + 1, current.Item2 - 1);
            return move;
        }

        public Tuple<int, int> MoveNorthWest(Tuple<int, int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1 - 1, current.Item2 - 1);
            return move;
        }

        public Tuple<int, int> MoveSouthEast(Tuple<int, int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1 + 1, current.Item2 + 1);
            return move;
        }
        public Tuple<int, int> MoveSouthWest(Tuple<int, int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1 -1, current.Item2 + 1);
            return move;
        }

        public Tuple<int, int> MoveSouth(Tuple<int, int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1 , current.Item2+1);
            return move;
        }
        public Tuple<int, int> MoveNorth(Tuple<int, int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1 , current.Item2-1);
            return move;
        }

        public Tuple<int, int> MoveEast(Tuple<int, int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1+1 , current.Item2);
            return move;
        }

        public Tuple<int, int> MoveWest(Tuple<int, int> current)
        {
            Tuple<int, int> move = new Tuple<int, int>(current.Item1-1, current.Item2);
            return move;
        }

    }
}
