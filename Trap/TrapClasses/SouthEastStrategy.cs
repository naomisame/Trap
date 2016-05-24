using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapClasses
{
    public class SouthEastStrategy:Strategy
    {
        public override Tuple<int, int> Analyze(Tuple<int, int> currentPosition, List<Tuple<int, int>> blockedSpaces)
        {
            if (CanMoveSouthEast(currentPosition, blockedSpaces))
            {
                return MoveSouthEast(currentPosition);
            }
            else if (CanMoveSouth(currentPosition, blockedSpaces))
            {
                return MoveSouth(currentPosition);
            }
            else if (CanMoveEast(currentPosition, blockedSpaces))
            {
                return MoveEast(currentPosition);
            }
            else if (CanMoveSouthWest(currentPosition, blockedSpaces))
            {
                return MoveSouthWest(currentPosition);
            }
            else if (CanMoveNorth(currentPosition, blockedSpaces))
            {
                return MoveNorth(currentPosition);
            }
            else if (CanMoveNorthEast(currentPosition, blockedSpaces))
            {
                return MoveNorthEast(currentPosition);
            }
            else if (CanMoveNorthWest(currentPosition, blockedSpaces))
            {
                return MoveNorthWest(currentPosition);
            }
            else if (CanMoveWest(currentPosition, blockedSpaces))
            {
                return MoveWest(currentPosition);
            }
            return null;
        }
    }
}
