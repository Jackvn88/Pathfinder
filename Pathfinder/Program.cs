using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinder.Models;

namespace Pathfinder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var graphRepresentationList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(4, 6)
            };

            var graph = new Graph();
            var result = graph.FindAllPaths(1, 4, graphRepresentationList);

            if(!result.Any()) Console.WriteLine("No paths was found, please check data");

            Console.ReadKey();
       
        }
    }
}