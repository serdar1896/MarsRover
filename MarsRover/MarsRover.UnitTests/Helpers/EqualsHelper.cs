using MarsRover.Services.Models;
using System.Collections.Generic;

namespace MarsRover.UnitTests.Helpers
{
    public static class EqualsHelper
    {

        #region  Equals For List<>
        public static bool EqualsForList(List<PositionModel> actualResult, List<PositionModel> expectedResult)
        {
            return Equals(actualResult, expectedResult);
        }

        public static bool Equals(List<PositionModel> actualResult, List<PositionModel> expectedResult)
        {
            var control = false;
            if (expectedResult.Count == actualResult.Count)
            {
                for (int i = 0; i < expectedResult.Count; i++)
                {
                    if (expectedResult[i].Direction == actualResult[i].Direction && expectedResult[i].X == actualResult[i].X && expectedResult[i].Y == actualResult[i].Y)
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
            return actualResult != null && control;

        }
        #endregion
    }
}
