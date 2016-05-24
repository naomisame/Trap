using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrapClasses
{
    public abstract class Strategy: GenericMovement
    {
        public Direction Direction { get; set; }

        public virtual Tuple<int, int> Analyze(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            throw new NotImplementedException();
        }

        public bool CanMoveSouthEast(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1 + 1 && x.Item2 == currentPosition.Item2 + 1);
        }

        public bool CanMoveSouthWest(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1 - 1 && x.Item2 == currentPosition.Item2 + 1);
        }

        public bool CanMoveSouth(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1 && x.Item2 == currentPosition.Item2 + 1);
        }

        public bool CanMoveWest(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1 - 1 && x.Item2 == currentPosition.Item2);
        }
        public bool CanMoveNorthEast(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1 + 1 && x.Item2 == currentPosition.Item2-1);
        }

        public bool CanMoveNorthWest(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1 - 1 && x.Item2 == currentPosition.Item2 - 1);
        }

        public bool CanMoveEast(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1 + 1 && x.Item2 == currentPosition.Item2 );
        }
        public bool CanMoveNorth(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            return !blockedSpaces.Exists(x => x.Item1 == currentPosition.Item1  && x.Item2 == currentPosition.Item2-1);
        }
    }
}
