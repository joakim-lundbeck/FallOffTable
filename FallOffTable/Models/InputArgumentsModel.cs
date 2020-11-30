using System.Collections.Generic;

namespace FallOffTable.Models
{
    public class InputArgumentsModel
    {
        public int BoardWidht { get; set; }
        public int BoardHeight { get; set; }
        public int StartPositionX { get; set; }
        public int StartPositionY { get; set; }
        public List<int> Movements { get; set; }
    }
}
