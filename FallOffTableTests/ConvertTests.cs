using System.Collections.Generic;
using FallOffTable;
using FallOffTable.Models;
using NUnit.Framework;

namespace FallOffTableTests
{
    class ConvertTests
    {
        private Convert _convert;

        [SetUp]
        public void Setup()
        {
            _convert = new Convert();
        }

        [Test]
        [TestCase("4,4,2,2,4,3,5,6,2,3,4,1,A")]
        [TestCase("4,4")]
        [TestCase("")]
        [TestCase("4,4,2,2,5,0")]
        [TestCase("4,4,2,2")]
        [TestCase("4,4,2,2,1")]
        public void Convert_ThrowsException(string input)
        {
            Assert.That(() => _convert.ConvertArgsToInputArguments(new[] { input }), Throws.ArgumentException);
        }

        [Test]
        [TestCase("4,4,2,2,1,2,3,4,0")]
        [TestCase("99,99,10,15,1,0")]
        public void Convert_DontThrowsException(string input)
        {
            Assert.That(() => _convert.ConvertArgsToInputArguments(new[] { input }), Throws.Nothing);
        }

        [Test]
        public void Convert_InputsArgs_ReturnCorrectList()
        {
            var result = _convert.ConvertArgsToInputArguments(new[] { "10,15,4,8,1,2,3,4,0" });
            Assert.That(result, Is.TypeOf<InputArgumentsModel>());
            Assert.AreEqual(result.BoardWidht, 10);
            Assert.AreEqual(result.BoardHeight, 15);
            Assert.AreEqual(result.StartPositionX, 4);
            Assert.AreEqual(result.StartPositionY, 8);
            Assert.AreEqual(result.Movements, new List<int> { 1, 2, 3, 4 });
        }
    }
}