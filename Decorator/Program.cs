using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataService =
                new DataServiceCachingDecorator(new DataServiceLoggingDecorator(new DataService(), new Logger()), new MemoryCache());
            Console.WriteLine(dataService.GetData());
        }
    }

    internal class DataService : IDataService
    {
        public List<int> GetData()
        {
            var data = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                data.Add(i);
                Thread.Sleep(350);
            }

            return data;
        }
    }

    internal class DataServiceLoggingDecorator : IDataService
    {
        private readonly IDataService _dataService;
        private readonly ILogger _logger;


        public DataServiceLoggingDecorator(IDataService dataService, ILogger logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public List<int> GetData()
        {
            _logger.Log("Starting to get data");
            var stopwatch = Stopwatch.StartNew();

            var data = _dataService.GetData();

            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.Log($"Finished getting data in {elapsedTime} milliseconds");

            return data;
        }
    }

    public class DataServiceCachingDecorator : IDataService
    {
        private readonly IDataService _dataService;
        private readonly IMemoryCache _memoryCache;

        public DataServiceCachingDecorator(IDataService dataService, IMemoryCache memoryCache)
        {
            _dataService = dataService;
            _memoryCache = memoryCache;
        }

        public List<int> GetData()
        {
            const string cacheKey = "data-key";

            if (_memoryCache.TryGetValue<List<int>>(cacheKey, out var data))
            {
                return data;
            }

            data = _dataService.GetData();

            _memoryCache.Set(cacheKey, data, TimeSpan.FromMinutes(120));

            return data;
        }
    }

    public interface IMemoryCache
    {
        void Set(string cacheKey, List<int> data, TimeSpan fromMinutes);
        bool TryGetValue<T>(string cacheKey, out List<int> o);
    }

    class MemoryCache : IMemoryCache
    {
        private readonly ConcurrentDictionary<string, List<int>> _cache = new ConcurrentDictionary<string, List<int>>();

        public void Set(string cacheKey, List<int> data, TimeSpan fromMinutes)
        {
            _cache.AddOrUpdate(cacheKey, data, (s, ints) => data);
        }

        public bool TryGetValue<T>(string cacheKey, out List<int> o)
        {
            return _cache.TryGetValue(cacheKey, out o);
        }
    }

    internal interface ILogger
    {
        void Log(string message);
    }

    internal class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IDataService
    {
        List<int> GetData();
    }
}
