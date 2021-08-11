// <copyright file="HomeController.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
using HelloWorldWeb.Services;
using HelloWorldWebMVC.Models;
using HelloWorldWebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// using System.Linq;
// using System.Threading.Tasks;
namespace HelloWorldWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;
        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        public int AddTeamMember(string name)
        {
            return this.teamService.AddTeamMember(name, timeService);
        }

        [HttpDelete]
        public void DeleteTeamMember(int id)
        {
            this.teamService.DeleteTeamMember(id);
        }

        [HttpPut]
        public void EditTeamMember(int id, string name)
        {
            this.teamService.EditTeamMember(id, name);
        }

        public IActionResult Index()
        {
            return this.View(this.teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
