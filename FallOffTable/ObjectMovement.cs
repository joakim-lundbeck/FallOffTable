using System;
using System.Collections.Generic;
using FallOffTable.Models;

namespace FallOffTable
{
    public class ObjectMovement
    {
        private DirectionsModel _direction = DirectionsModel.North;
        private int _movementX;
        private int _movementY = -1;
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
        private enum DirectionsModel
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
            switch (_direction)
            {
                case DirectionsModel.North:
                    SetDirectionEast();
                    break;
                case DirectionsModel.East:
                    SetDirectionSouth();
                    break;
                case DirectionsModel.South:
                    SetDirectionWest();
                    break;
                case DirectionsModel.West:
                    SetDirectionNorth();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Movements integers must be between 1 to 4");
            }
        }

        private void RotateCounterClockwise()
        {
            switch (_direction)
            {
                case DirectionsModel.North:
                    SetDirectionWest();
                    break;
                case DirectionsModel.East:
                    SetDirectionNorth();
                    break;
                case DirectionsModel.South:
                    SetDirectionEast();
                    break;
                case DirectionsModel.West:
                    SetDirectionSouth();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Movements integers must be between 1 to 4");
            }
        }

        private void SetDirectionNorth()
        {
            _direction = DirectionsModel.North;
            _movementX = 0;
            _movementY = -1;
        }

        private void SetDirectionWest()
        {
            _direction = DirectionsModel.West;
            _movementX = -1;
            _movementY = 0;
        }

        private void SetDirectionSouth()
        {
            _direction = DirectionsModel.South;
            _movementX =0;
            _movementY = 1;
        }

        private void SetDirectionEast()
        {
            _direction = DirectionsModel.East;
            _movementX = 1;
            _movementY = 0;
        }
    }
}
