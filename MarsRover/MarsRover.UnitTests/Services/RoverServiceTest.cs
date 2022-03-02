using MarsRover.Services.Abstractions;
using MarsRover.Services.Concrete;
using MarsRover.Services.Enums;
using MarsRover.Services.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.UnitTests.Services
{
    public class RoverServiceTest
    {
        private readonly IRoverService roverService;
        public RoverServiceTest()
        {
            roverService = new RoverService();
        }

        private readonly PlateauModel plateauRequestModel2 = new PlateauModel { Height = 5, Width = 5 };
        private readonly List<PositionModel> positionRequestModel2 = new List<PositionModel>
            {
                new PositionModel { X = 1, Y = 2, Direction = CompassDirectionEnum.North },
                new PositionModel { X = 3, Y = 3, Direction = CompassDirectionEnum.East }
            };


        [Theory]
        [InlineData("LMLMLMLMM")]
        public void ApplyMoveDirectives__SuccessfullyCalculatedCoordinate_CorrectlyCalculatedResponse(string directive)
        {
            var responseResult = new PositionModel { X = 1, Y = 3, Direction = CompassDirectionEnum.North };

            // Act
            var result = roverService.ApplyMoveDirectives(plateauRequestModel2, positionRequestModel2[0], directive);

            // Assert
            
            Assert.Equal(result.Direction.ToString(), responseResult.Direction.ToString());
            Assert.Equal(result.X, responseResult.X);
            Assert.Equal(result.Y, responseResult.Y);

        }

        [Theory]
        [InlineData("KLLLLO")]
        public void ApplyMoveDirectives__InvalidDirectiveError_ThrowInvalidOperationException(string directive)
        {      
            // Assert
            Assert.Throws<InvalidOperationException>(() => roverService.ApplyMoveDirectives(plateauRequestModel2, positionRequestModel2[0], directive) );
        }


        [Fact]
        public void PlateauCoordControl_SuccessfullyPlateauCoordLimit_ReturnTrue()
        {
            // Act
            var result = roverService.PlateauCoordControl(plateauRequestModel2, positionRequestModel2[0]);

            // Assert            
            Assert.True(result);
        }
           


        [Fact]
        public void PlateauCoordControl_ErrorPlateauCoordLimit_ReturnFalse()
        {
            var errorRequesModel = new PositionModel { X = 7, Y = 8, Direction = CompassDirectionEnum.North };

        // Act
        var result = roverService.PlateauCoordControl(plateauRequestModel2, errorRequesModel);

            // Assert            
            Assert.False(result);
        }
    }
}
