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

        private IRobot Robot
        {
            get
            {
                IRobot robot;
                var value = HttpContext.Session.GetString(sessionKey);
                if (string.IsNullOrEmpty(value))
                {
                    robot = RobotFabric.CreateDefaultRobot();
                    var serialisedDate = JsonConvert.SerializeObject(robot, new JsonSerializerSettings() {
                        TypeNameHandling = TypeNameHandling.Auto,

                    });
                    HttpContext.Session.SetString(sessionKey, serialisedDate);
                }
                else
                {
                    robot = JsonConvert.DeserializeObject<Robot>(value, new JsonSerializerSettings() {
                        TypeNameHandling = TypeNameHandling.Auto
                    });
                }

                return robot;
            }
            set 
            {
                var serialisedDate = JsonConvert.SerializeObject(value, new JsonSerializerSettings() {
                    TypeNameHandling = TypeNameHandling.Auto,

                });
                HttpContext.Session.SetString(sessionKey, serialisedDate);
            }
        }

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
