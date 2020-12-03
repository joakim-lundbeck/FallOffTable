using System;
using System.Collections.Generic;
using FallOffTable.Models;

namespace FallOffTable
{
    public class ObjectMovement
    {
        private Directions _direction = Directions.North;

        private int MovementX
        {
            get
            {
                switch (_direction)
                {
                    case Directions.North:
                    case Directions.South:
                        return 0;
                    case Directions.East:
                        return 1;
                    default:
                        return -1;
                }
            }
        }

        private int MovementY
        {
            get
            {
                switch (_direction)
                {
                    case Directions.East:
                    case Directions.West:
                        return 0;
                    case Directions.South:
                        return 1;
                    default:
                        return -1;
                }
            }
        }

        private int PositionX { get; set; }
        private int PositionY { get; set; }
        private readonly Table _table;
        
        private enum Directions
        { 
            North, East, South, West
        }

        public ObjectMovement(InputArgumentsModel inputArguments, Table table)
        {
            PositionX = inputArguments.StartPositionX;
            PositionY = inputArguments.StartPositionY;
            _table = table;
        }

        public string MovePosition(List<int> movements)
        {
            movements.ForEach(movement =>
            {
                switch (movement)
                {
                    case 1:
                        MoveForwards();
                        break;
                    case 2:
                        MoveBackwards();
                        break;
                    case 3:
                        RotateClockwise();
                        break;
                    case 4:
                        RotateCounterClockwise();
                        break;
                }

                if (_table.ObjectOutsideTable(PositionX, PositionY))
                    throw new ArgumentOutOfRangeException($"-1,-1");
            });

            return $"{PositionX},{PositionY}";
        }

        private void MoveForwards()
        {
            PositionX += MovementX;
            PositionY += MovementY;
        }

        private void MoveBackwards()
        {
            PositionX -= MovementX;
            PositionY -= MovementY;
        }

        private void RotateClockwise()
        {
            _direction = _direction == Directions.West ? Directions.North : _direction += 1;
        }

        private void RotateCounterClockwise()
        {
            _direction = _direction == Directions.North ? Directions.West : _direction -= 1;
        }
    }
}
