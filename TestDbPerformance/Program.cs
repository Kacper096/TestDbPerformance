using System;
using System.IO;
using System.Linq;
using TestDbPerformanceDB;

namespace TestDbPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            new PerformanceService().Test();
            Console.ReadLine();
        }
    }
}
