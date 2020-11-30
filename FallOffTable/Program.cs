using System;
using FallOffTable.Models;

namespace FallOffTable
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Convert convert = new Convert();
                InputArgumentsModel inputArguments = convert.ConvertArgsToInputArguments(args);

                Table table = new Table(inputArguments);
                ObjectMovement objectMovement = new ObjectMovement(inputArguments, table);

                var endPosition = objectMovement.MovePosition(inputArguments.Movements);

                Console.WriteLine(endPosition);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid arguments Error: {ex.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error");
            }
        }

    }

}
