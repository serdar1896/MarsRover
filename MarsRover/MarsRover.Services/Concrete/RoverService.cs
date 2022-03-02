using MarsRover.Services.Abstractions;
using MarsRover.Services.Enums;
using MarsRover.Services.Models;
using System;

namespace MarsRover.Services.Concrete
{
    public class RoverService : IRoverService
    {
        private static PositionModel position = new PositionModel();

        public PositionModel ApplyMoveDirectives(PlateauModel plateauModel, PositionModel startingPosition, string directives)
        {

            position = startingPosition;
            var entries = directives.ToUpper().Trim();
            for (int i = 0; i < entries.Length; i++)
            {
                if (!PlateauCoordControl(plateauModel, position))
                    throw new ArgumentOutOfRangeException("Plataeu Limit Error!");

                switch (entries[i])
                {
                    case 'M':
                        Move();
                        break;
                    case 'L':
                        Left();
                        break;
                    case 'R':
                        Right();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid Directive!");
                }
            }
            return position;
        }

        public bool PlateauCoordControl(PlateauModel plateauInput, PositionModel positionModel)
        {
            if (positionModel.X < 0 || positionModel.X > plateauInput.Width || positionModel.Y < 0 || positionModel.Y > plateauInput.Height)
                return false;
            return true;
        }

        private void Move()
        {
            switch (position.Direction)
            {
                case CompassDirectionEnum.North:
                    position.Y++;
                    break;
                case CompassDirectionEnum.South:
                    position.Y--;
                    break;
                case CompassDirectionEnum.East:
                    position.X++;
                    break;
                case CompassDirectionEnum.West:
                    position.X--;
                    break;
                default:
                    break;
            }
        }

        private void Left()
        {
            switch (position.Direction)
            {
                case CompassDirectionEnum.North:
                    position.Direction = CompassDirectionEnum.West;
                    break;
                case CompassDirectionEnum.South:
                    position.Direction = CompassDirectionEnum.East;
                    break;
                case CompassDirectionEnum.East:
                    position.Direction = CompassDirectionEnum.North;
                    break;
                case CompassDirectionEnum.West:
                    position.Direction = CompassDirectionEnum.South;
                    break;
                default:
                    break;
            }
        }

        private void Right()
        {
            switch (position.Direction)
            {
                case CompassDirectionEnum.North:
                    position.Direction = CompassDirectionEnum.East;
                    break;
                case CompassDirectionEnum.South:
                    position.Direction = CompassDirectionEnum.West;
                    break;
                case CompassDirectionEnum.East:
                    position.Direction = CompassDirectionEnum.South;
                    break;
                case CompassDirectionEnum.West:
                    position.Direction = CompassDirectionEnum.North;
                    break;
                default:
                    break;
            }
        }

    }
}
