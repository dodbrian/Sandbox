using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTime
{
    internal static class Program
    {
        private const int Attempts = 10000;
        private const int Delay = 2;
        private const string Address = "http://localhost:9000";

        private static void Main(string[] args)
        {
            Task
                .Run(async () =>
                {
                    var results = new List<(string, double)>();

                    using var httpClient = new HttpClient();

                    // issue a first request to warm up
                    WarmUpNetwork(() => GetCurrentTime(httpClient));

                    results.Add((
                        "HttpClient headers only",
                        MeasureRequestDuration(() => GetCurrentTime(httpClient))));

                    results.Add((
                        "HttpClient headers only DateTime local",
                        MeasureRequestDuration(() => GetCurrentLocalTime(httpClient))));

                    results.Add((
                        "HttpClient headers and body",
                        MeasureRequestDuration(() => GetCurrentTimeFull(httpClient))));

                    results.Add((
                        "Per request HttpClient headers and body",
                        MeasureRequestDuration(() =>
                        {
                            using var localClient = new HttpClient();
                            GetCurrentTimeFull(localClient);
                        })));

                    results.Add((
                        "HttpClient headers only async",
                        await MeasureRequestDurationAsync(() => GetCurrentTimeAsync(httpClient))));

                    results.Add((
                        "HttpWebRequest version",
                        MeasureRequestDuration(() => GetNistTime())));

                    results
                        .OrderBy(result => result.Item2)
                        .ToList()
                        .ForEach(result => Console.WriteLine($"{result.Item1}: {result.Item2} ms.")); 
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void WarmUpNetwork(Action getTime)
        {
            for (var i = 0; i < 10; i++)
            {
                getTime?.Invoke();
                Thread.Sleep(Delay);
            }
        }
        
        private static double MeasureRequestDuration(Action getTime)
        {
            var stopwatch = new Stopwatch();
            long totalTicks = 0;

            for (var i = 0; i < Attempts; i++)
            {
                stopwatch.Restart();
                getTime?.Invoke();
                stopwatch.Stop();

                totalTicks += stopwatch.Elapsed.Ticks;
                Thread.Sleep(Delay);
            }

            return TimeSpan.FromTicks(totalTicks / Attempts).TotalMilliseconds;
        }

        private static async Task<double> MeasureRequestDurationAsync(Func<Task> getTime)
        {
            var stopwatch = new Stopwatch();
            long totalTicks = 0;

            for (var i = 0; i < Attempts; i++)
            {
                stopwatch.Restart();
                await getTime?.Invoke();
                stopwatch.Stop();

                totalTicks += stopwatch.Elapsed.Ticks;
                await Task.Delay(Delay);
            }

            return TimeSpan.FromTicks(totalTicks / Attempts).TotalMilliseconds;
        }

        public static DateTimeOffset? GetCurrentTime(HttpClient httpClient)
        {
            try
            {
                var result = httpClient.GetAsync(Address,
                      HttpCompletionOption.ResponseHeadersRead).Result;

                return result.Headers.Date;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? GetCurrentLocalTime(HttpClient httpClient)
        {
            try
            {
                var result = httpClient.GetAsync(Address,
                      HttpCompletionOption.ResponseHeadersRead).Result;

                return result.Headers.Date?.LocalDateTime;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<DateTimeOffset?> GetCurrentTimeAsync(HttpClient httpClient)
        {
            try
            {
                var result = await httpClient.GetAsync(Address,
                      HttpCompletionOption.ResponseHeadersRead);

                return result.Headers.Date;
            }
            catch
            {
                return null;
            }
        }

        public static DateTimeOffset? GetCurrentTimeFull(HttpClient httpClient)
        {
            try
            {
                var result = httpClient.GetAsync(Address).Result;

                return result.Headers.Date;
            }
            catch
            {
                return null;
            }
        }

        public static DateTime GetNistTime()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create(Address);
            var response = myHttpWebRequest.GetResponse();
            var todaysDates = response.Headers["date"];

            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                       CultureInfo.InvariantCulture.DateTimeFormat,
                                       DateTimeStyles.AssumeUniversal);
        }
    }
}
