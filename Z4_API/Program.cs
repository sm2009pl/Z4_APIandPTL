using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Z4_API
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var baza = new Context();
            baza.Database.EnsureCreated();
            var tasks = new List<Task<IRestResponse>>();
            var api = new Website("https://api.collegefootballdata.com/");
            var teamsResponse = api.DownloadAsync("/teams/fbs").Result.Content;
            var teamsList = System.Text.Json.JsonSerializer.Deserialize<Teams[]>(teamsResponse);

            var coachesResponse = api.DownloadAsync($"/coaches").Result.Content;
            var coachesList = JsonConvert.DeserializeObject<Coaches[]>(coachesResponse);

            var addTasks = teamsList.Select(x => baza.AddAsync(x).AsTask());
            await Task.WhenAll(addTasks);

            var addTasksCoach = coachesList.Select(x => baza.AddAsync(x).AsTask());
            await Task.WhenAll(addTasksCoach);
            await baza.SaveChangesAsync();

        }
    }
}
