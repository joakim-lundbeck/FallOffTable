using FallOffTable;
using FallOffTable.Models;
using NUnit.Framework;
using Convert = FallOffTable.Convert;

namespace FallOffTableTests
{
    class ObjectMovementTests
    {
        private ObjectMovement _objectMovement;
        private InputArgumentsModel _arguments;
        private Convert _convert;
        private Table _table;

        [SetUp]
        public void Setup()
        {
            _convert = new Convert();
        }

        [Test]
        [TestCase("4,4,2,2,1,4,1,3,2,3,2,4,1,0", "0,1")]
        [TestCase("4,4,2,2,1,2,0", "2,2")]
        [TestCase("10,15,0,0,3,1,1,1,1,3,1,1,1,1,3,1,1,1,1,3,1,1,1,1,0", "0,0")]
        [TestCase("10,15,0,0,3,1,1,1,1,1,1,1,1,1,0","9,0")]
        [TestCase("10,15,0,0,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0", "0,14")]
        [TestCase("4,4,0,0,3,1,1,4,4,1,1,0", "0,0")]
        public void ObjectMovement_ListOfMovements_CorrectResult(string movements, string result)
        {
            _arguments = _convert.ConvertArgsToInputArguments(new[] { movements });
            _table = new Table(_arguments);
            _objectMovement = new ObjectMovement(_arguments, _table);
            
            var finalPosition = _objectMovement.MovePosition(_arguments.Movements);

            Assert.AreEqual(result, finalPosition);
        }

        [Test]
        [TestCase("4,4,2,2,1,1,1,1,1,0")]
        [TestCase("4,4,2,2,2,2,2,2,2,0")]
        [TestCase("3,3,1,1,1,1,1,1,2,2,2,2,0")]
        [TestCase("10,15,0,0,3,1,1,1,1,1,1,1,1,1,1,0")]
        [TestCase("10,15,0,0,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0")]
        [TestCase("10,15,0,0,3,1,1,1,1,3,1,1,1,1,3,1,1,1,1,3,1,1,1,1,1,0")]
        [TestCase("4,4,0,0,3,1,1,4,4,1,1,1,0")]
        public void ObjectMovement_ListOfMovements_ThrowsExcpetion(string movements)
        {
            _arguments = _convert.ConvertArgsToInputArguments(new[] { movements });
            _table = new Table(_arguments);
            _objectMovement = new ObjectMovement(_arguments, _table);

            Assert.That(() => _objectMovement.MovePosition(_arguments.Movements), Throws.Exception);
        }
    }
}
