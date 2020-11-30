using System;
using System.Collections.Generic;
using System.Linq;
using FallOffTable.Models;

namespace FallOffTable
{
    public class Convert
    {
        public InputArgumentsModel ConvertArgsToInputArguments(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("Missing arguments");

            List<int> inputs = args[0]
                .Split(',')
                .Select(i => int.TryParse(i, out var output) ? output : -1)
                .ToList();

            if (inputs.Count < 3)
                throw new ArgumentException("Need at least 5 integers in input");

            if (inputs.Contains(-1))
                throw new ArgumentException("One or more inputs was not an integer");

            if (inputs.Last() != 0)
                throw new ArgumentException("Input must end with a 0");

            List<int> movements = inputs.Skip(4).ToList();

            if (movements.Any(i => i > 4))
                throw new ArgumentException("Movements integers must be between 1 to 4");

            InputArgumentsModel inputList = new InputArgumentsModel
            {
                BoardWidht = inputs[0],
                BoardHeight = inputs[1],
                StartPositionX = inputs[2],
                StartPositionY = inputs[3],
                Movements = movements.SkipLast(1).ToList()
            };

            return inputList;
        }
    }
}
