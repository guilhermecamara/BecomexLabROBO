using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ROBOCommandInterface.Models;
using ROBO.Core;

namespace ROBOCommandInterface.Controllers
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
                    robot = RobotFabric.CreateRobot();
                    var serialisedDate = JsonConvert.SerializeObject(robot, RobotFabric.GetRobotType(), new JsonSerializerSettings() {
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
    }
}
