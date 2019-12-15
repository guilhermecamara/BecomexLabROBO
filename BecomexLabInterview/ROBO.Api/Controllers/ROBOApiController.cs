using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ROBO.Api.Models;
using ROBO.Core;
using ROBO.Core.Entities;
using ROBO.Core.Interactors;
using ROBO.Infrastructure;

namespace ROBO.Api.Controllers
{
    public class ROBOApiController : Controller
    {
        const string sessionKey = "Robot";

        public IRobot Robot { get; set; } = RobotFabric.GetDefaultRobot();
        
        public IActionResult Index()
        {
            return View(Robot);
        }        

        [HttpPost]
        public JsonResult NextStateOfBodyPart([FromBody] ChangeStateViewModel changeState)
        {
            var robot = Robot;
            var request = new RequestNextStateOfBodyPartInteractor(robot);

            var requestMessage = new NextStateOfBodyPartRequestMessage(changeState.BodyPartCollectionId, changeState.BodyPartId);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();
            Robot = robot;

            return Json(responseTask.Result.Success);
        }

        [HttpPost]
        public JsonResult PreviousStateOfBodyPart([FromBody] ChangeStateViewModel changeState)
        {
            var robot = Robot;
            var request = new RequestPreviousStateOfBodyPartInteractor(robot);

            var requestMessage = new PreviousStateOfBodyPartRequestMessage(changeState.BodyPartCollectionId, changeState.BodyPartId);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();
            Robot = robot;

            return Json(responseTask.Result.Success);
        }
    }
}
