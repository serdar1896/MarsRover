using MarsRover.Services.Abstractions;
using MarsRover.Services.Concrete;
using MarsRover.Services.Enums;
using MarsRover.Services.Models;
using MarsRover.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        private readonly List<PositionModel> response= new List<PositionModel>
            {
                new PositionModel { X = 1, Y = 3, Direction = CompassDirectionEnum.North },
                new PositionModel { X = 5, Y = 1, Direction = CompassDirectionEnum.East }
            };
        
       
        [TestMethod]
        public void Test()
        {
            IRoverService _roverService = new RoverService();
            RoverController homeController = new RoverController(_roverService);
            var plateauModel = new PlateauModel { Height=5,Width=5};

            var positionModels = new List<PositionModel>
            {
                new PositionModel { X = 1, Y = 2, Direction = CompassDirectionEnum.North },
                new PositionModel { X = 3, Y = 3, Direction = CompassDirectionEnum.East }
            };

            string[] directions = { "LMLMLMLMM", "MMRMMRMRRM" };

            var result = homeController.MoveDirectiveForRover(plateauModel,positionModels,directions) ;

            if (result.Count==0)
                Assert.IsTrue(result.Count>0);
            else
                Assert.IsTrue(Equals(result));

        }
        public override bool Equals(object other)
        {
            return Equals(other as PositionModel);
        }

        public bool Equals(List<PositionModel> other)
        {
            var control = false;
            if (response.Count == other.Count)
            {
                for (int i = 0; i < response.Count; i++)
                {
                    if (response[i].Direction == other[i].Direction && response[i].X == other[i].X && response[i].Y == other[i].Y)
                    {
                        control = true;
                    }
                    else
                    {
                        control = false;
                        break;
                    }
                }
            }
            return other != null && control ;
                   
        }
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + response.Count ==0 ? 0 : response.GetHashCode();
          
            return hash;
        }


    }
}
