using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RequestCounter.Services
{
    /// <summary>
    /// Use this class to implement IRequestCountStatsService
    /// </summary>
    public class RequestCountStatisticsService : IRequestCountStatsService
    {     
        private readonly Object _objectLock = new Object();
        private Dictionary<string, int> _stats = new Dictionary<string, int>();
        //List of methods which are allowed to be counted by designed service
        private static readonly string[] AllowedMethods = new string[] { "GET", "POST", "DELETE", "PATCH", "PUT" };
        public void IncreaseCounter(string method)
        {
            if (AllowedMethods.Any(x => x.ToLower() == method.ToLower()))
            {
                lock (_objectLock)
                {
                    _stats = DataReader.ReadFromFile();
                    if (_stats.ContainsKey(method))
                    {
                        _stats[method]++;
                    }
                    else
                    {
                        _stats[method] = 1;
                    }
                    DataReader.WriteToFile(_stats);
                }
            }
                
        }

        public Stats GetStatistics()
        {
            lock (_objectLock)
            {
                _stats = DataReader.ReadFromFile();
            }

            return new Stats()
            {
                Counts = _stats
            };
        }
    }
}
