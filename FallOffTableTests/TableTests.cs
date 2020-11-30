using FallOffTable;
using FallOffTable.Models;
using NUnit.Framework;

namespace FallOffTableTests
{
    class TableTests
    {
        [Test]
        public void Table_InputArguments_NewBoard()
        {
            InputArgumentsModel inputs = new InputArgumentsModel
            {
                BoardHeight = 10, 
                BoardWidht = 15,
                StartPositionX = 10,
                StartPositionY = 5
            };

            Table table = new Table(inputs);

            Assert.AreEqual(table.BoardHeight, 9);
            Assert.AreEqual(table.BoardWidth, 14);
        }
    }
}
