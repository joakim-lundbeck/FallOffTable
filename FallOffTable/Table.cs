using FallOffTable.Models;

namespace FallOffTable
{
    public class Table
    {
        public int BoardWidth { get; }
        public int BoardHeight { get; }

        public Table(InputArgumentsModel inputArguments)
        {
            BoardWidth = inputArguments.BoardWidht - 1;
            BoardHeight = inputArguments.BoardHeight - 1;
        }

        public bool ObjectOutsideTable(int positionX, int positionY)
        {
            return (positionX < 0 || 
                    positionY < 0 || 
                    positionX > BoardWidth || 
                    positionY > BoardHeight);
        }
    }
}
