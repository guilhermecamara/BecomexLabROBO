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
        }

        public IActionResult Index()
        {
            return View(Robot);
        }

        public JsonResult NextStateOfBodyPart(string bodyPartCollectionId, string bodyPartId)
        {
            var request = new RequestNextStateOfBodyPartInteractor(Robot);

            var requestMessage = new NextStateOfBodyPartRequestMessage(bodyPartCollectionId, bodyPartId);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();

            return Json(responseTask.Result.Success);
        }

        public JsonResult PreviousStateOfBodyPart(string bodyPartCollectionId, string bodyPartId)
        {
            var request = new RequestPreviousStateOfBodyPartInteractor(Robot);

            var requestMessage = new PreviousStateOfBodyPartRequestMessage(bodyPartCollectionId, bodyPartId);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();

            return Json(responseTask.Result.Success);
        }
    }
}
