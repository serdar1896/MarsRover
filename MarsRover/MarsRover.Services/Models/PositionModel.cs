using MarsRover.Services.Enums;

namespace MarsRover.Services.Models
{
    public class PositionModel
    {
        public PositionModel()
        {
            X = 0;
            Y = 0;
            Direction = CompassDirectionEnum.North;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public CompassDirectionEnum Direction { get; set; }
    }
}
