using MarsRover.Services.Abstractions;
using MarsRover.Services.Concrete;
using MarsRover.Services.Enums;
using MarsRover.Services.Models;
using MarsRover.UnitTests.Helpers;
using MarsRover.Web.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.UnitTests.Web.Controllers
{
    public class RoverControllerTest
    {
        private readonly IRoverService _roverService;
        private readonly RoverController _roverController;
        public RoverControllerTest()
        {
            _roverService = new RoverService();
            _roverController = new RoverController(_roverService);
        }

 

        [Fact]
        public void MoveDirectiveForRover_SuccessfullyCalculatedCoordinate_CorrectlyCalculatedResponse()
        {
            List<PositionModel> expectedResult = new List<PositionModel>
            {
                new PositionModel { X = 1, Y = 3, Direction = CompassDirectionEnum.North },
                new PositionModel { X = 5, Y = 1, Direction = CompassDirectionEnum.East }
            }.ToList();

           PlateauModel plateauRequestModel = new PlateauModel { Height = 5, Width = 5 };

           List<PositionModel> positionRequestModel = new List<PositionModel>
            {
                new PositionModel { X = 1, Y = 2, Direction = CompassDirectionEnum.North },
                new PositionModel { X = 3, Y = 3, Direction = CompassDirectionEnum.East }
            };

           string[] directionsRequestModel = { "LMLMLMLMM", "MMRMMRMRRM" };


          // Act
           var result = _roverController.MoveDirectiveForRover(plateauRequestModel, positionRequestModel, directionsRequestModel);


            // Assert
            Assert.True(EqualsHelper.EqualsForList(result,expectedResult));

        }




    }
}
