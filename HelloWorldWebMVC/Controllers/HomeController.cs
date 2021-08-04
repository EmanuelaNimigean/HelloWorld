// <copyright file="HomeController.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
using HelloWorldWeb.Services;
using HelloWorldWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// using System.Linq;
// using System.Threading.Tasks;
namespace HelloWorldWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        // private readonly TeamInfo teamInfo;
        private readonly ITeamService teamService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            this.logger = logger;
            this.teamService = teamService;
            
        }

        [HttpGet]
        public int GetCount()
        {
            return teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        public void AddTeamMember(string name)
        {
            teamService.AddTeamMember(name);
        }

        public IActionResult Index()
        {
            return this.View(teamService.GetTeamInfo());
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
