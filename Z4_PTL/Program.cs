﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Z4_PTL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            var google = new Website("http://www.google.pl");
            var ath = new Website("https://ath.bielsko.pl");
            var fb = new Website("https://facebook.com");
            var wiki = new Website("https://en.wikipedia.org/");
            var anyapi = new Website("https://any-api.com");
            var plany = new Website("https://plany.ath.bielsko.pl");

            var tasks = new List<Task<IRestResponse>>();

            stopWatch.Start();
            tasks.Add(google.DownloadAsync("/"));
            Console.WriteLine(stopWatch.Elapsed);

            tasks.Add(ath.DownloadAsync("/"));
            Console.WriteLine(stopWatch.Elapsed);

            tasks.Add(fb.DownloadAsync("/"));
            Console.WriteLine(stopWatch.Elapsed);

            tasks.Add(wiki.DownloadAsync("/wiki/.NET_Core"));
            Console.WriteLine(stopWatch.Elapsed);

            tasks.Add(anyapi.DownloadAsync("/"));
            Console.WriteLine(stopWatch.Elapsed);

            tasks.Add(plany.DownloadAsync("/plan.php?type0&id=12647"));
            Console.WriteLine(stopWatch.Elapsed);

            tasks.Add(ath.DownloadAsync("/graficzne-formy-przekazu-informacji/"));
            Console.WriteLine(stopWatch.Elapsed);

            Console.WriteLine("-------------------");
            Console.WriteLine(Task.WhenAny(tasks).Result.Result.Content);
            Console.WriteLine(stopWatch.Elapsed);

            var htmlCodes = Task.WhenAll(tasks).Result;
            Console.WriteLine(stopWatch.Elapsed);

            foreach(var site in htmlCodes)
            {
                Console.WriteLine(site.Content);
            }
            stopWatch.Stop();
        }
    }
}

/* teamy z 2019 i ich trenerów, informacje o trenerach*/