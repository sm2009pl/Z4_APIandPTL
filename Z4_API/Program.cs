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
            using var db = new FootballContext();
            db.Database.EnsureCreated();
            var tasks = new List<Task<IRestResponse>>();
            var api = new Website("https://api.collegefootballdata.com/");

            var teamsRequest = api.DownloadAsync("/teams/fbs").Result.Content;
            var teamsTable = System.Text.Json.JsonSerializer.Deserialize<Teams[]>(teamsRequest, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach (var item in teamsTable)
            {
                var coachRequest = api.DownloadAsync($"/coaches?team={item.School}");
                tasks.Add(coachRequest);
            }
            var responses = await Task.WhenAll(tasks);

            var coaches = responses.SelectMany(x => System.Text.Json.JsonSerializer.Deserialize<Coaches[]>(x.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));
            foreach (var item in coaches)
            {
                teamsTable.Single(x => x.School == item.Seasons.First().School).coaches.Add(item);
            }

            var addTasks = teamsTable.Select(x => db.AddAsync(x).AsTask());
            await Task.WhenAll(addTasks);
            await db.SaveChangesAsync();
        }
    }
}
