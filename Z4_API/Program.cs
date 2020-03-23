using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;

namespace Z4_API
{
    class Program
    {
        static void Main(string[] args)
        {
            using var baza = new Context();
            baza.Database.EnsureCreated();
            var api = new Website("https://api.collegefootballdata.com/");
            var teamsResponse = api.DownloadAsync("/teams/fbs").Result.Content;
            var teamsList = JsonConvert.DeserializeObject<TeamsCollection>(teamsResponse);          // wystepuje blad
            var coachesResponse = api.DownloadAsync($"/coaches").Result.Content;
            var coachesList = JsonConvert.DeserializeObject<CoachesCollection>(coachesResponse);        // wystepuje blad

            foreach (var item in teamsList.TeamsList)
            {
                Console.WriteLine(item.school);
            }

            foreach (var item in coachesList.CoachesList)
            {
                Console.WriteLine($"{item.first_name},   {item.last_name}");
            }
        }
    }
}
