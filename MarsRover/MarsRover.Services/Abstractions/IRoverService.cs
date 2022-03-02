using MarsRover.Services.Models;

namespace MarsRover.Services.Abstractions
{
    public interface IRoverService
    {
        PositionModel ApplyMoveDirectives(PlateauModel plateauModel,  PositionModel startingPosition, string directives);
        bool PlateauCoordControl(PlateauModel plateauInput, PositionModel positionModel);
    }
}
