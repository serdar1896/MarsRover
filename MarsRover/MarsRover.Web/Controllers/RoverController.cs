using MarsRover.Services.Abstractions;
using MarsRover.Services.Models;
using MarsRover.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace MarsRover.Web.Controllers
{
    public class RoverController : Controller
    {
        private readonly IRoverService _roverService;
        public RoverController(IRoverService roverService)
        {
            _roverService = roverService;
        }      

        public IActionResult Index()
        {
            return View();

        }

        public List<PositionModel> MoveDirectiveForRover(PlateauModel plateauModel,  List<PositionModel> positionModels, string[] directions)
        {       
            var response = new List<PositionModel>();
            for (int i = 0; i < directions.Length; i++)
            {
                response.Add(_roverService.ApplyMoveDirectives(plateauModel, positionModels[i], directions[i]));                
            }
            return response;
        }

   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
