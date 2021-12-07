using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            //all women's leagues
            ViewBag.WomensLeagues = _context.Leagues.Where(l => l.Name.Contains("Women")).ToList();

            //all leagues where sport is hockey
            ViewBag.HockeyLeagues = _context.Leagues.Where(l => l.Name.Contains("Hockey")).ToList();

            //all leagues where sport is something other than football
            ViewBag.Leagues = _context.Leagues.Where(l => !l.Name.Contains("Football")).ToList();

            //all leagues that call themselves conferences
            ViewBag.Conferences = _context.Leagues.Where(l => l.Name.Contains("Conference")).ToList();

            //all leagues in the atlantic region
            ViewBag.AtlanticLeagues = _context.Leagues.Where(l => l.Name.Contains("Atlantic")).ToList();

            //all teams based in dallas
            ViewBag.DallasTeams = _context.Teams.Where(l => l.Location.Contains("Dallas")).ToList();

            //all teams names the raptors
            ViewBag.AllRaptors = _context.Teams.Where(l=> l.TeamName.Contains("Raptors")).ToList();

            //all teams whose location includes "City"
            ViewBag.CityTeams = _context.Teams.Where(l => l.Location.Contains("City")).ToList();

            //all teams whose names begin with a "T"
            ViewBag.TTeams = _context.Teams.Where(l => l.TeamName.Contains("T")).ToList();

            //all teams, ordered alphabetically by location
            ViewBag.AlphaTeams = _context.Teams.OrderBy(l => l.Location).ToList();

            //all teams, ordered by team name in reverse alphabetical order
            ViewBag.BetaTeams = _context.Teams.OrderByDescending(l => l.TeamName).ToList();

            //every player with the last name "Cooper"
            ViewBag.Cooper = _context.Players.Where(l => l.LastName.Contains("Cooper")).ToList();

            //every player with the first name "Joshua"
            ViewBag.Joshua = _context.Players.Where(l => l.FirstName.Contains("Joshua")).ToList();

            //every player with the last name "Cooper" EXCEPT those with "Joshua" as the first name
            ViewBag.NotJoshua = _context.Players.Where(l => l.LastName.Contains("Cooper") && !l.FirstName.Contains("Joshua")).ToList();

            //all players with the first name "Alexander" OR first name "Wyatt"
            ViewBag.Players = _context.Players.Where(l => l.FirstName.Contains("Alex") || l.FirstName.Contains("Wyatt")).ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}