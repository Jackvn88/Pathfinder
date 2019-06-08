using System;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinder.Models
{
    public class Graph
    {
        private List<Tuple<int, int>> _graph;

        private Dictionary<int, Node> _nodes;


        //I would use the constructor to set _graph and _nodes but in the task it was asked to pass list to a method  

        /*

        private readonly List<Tuple<int, int>> _graph;

        private readonly Dictionary<int, Node> _nodes;

        public Graph(List<Tuple<int, int>> graph)
        {
            _graph = graph;
            _nodes = new Dictionary<int, Node>();
        }

        */

        public List<List<int>> FindAllPaths(int source, int destination, List<Tuple<int, int>> graph)
        {
            try
            {
                _graph = graph;
                _nodes = new Dictionary<int, Node>();

                SetNodes(new Node(source));
                return GetAllPaths(source, destination);
            }
            catch (ArgumentNullException ex)
            {
                //TODO: deal with error 
                Console.WriteLine(ex.Message);
                return new List<List<int>>();
            }
        }

        private void SetNodes(Node currentNode)
        {
            if (!_nodes.ContainsKey(currentNode.Id))
            {
                _nodes.Add(currentNode.Id, currentNode);

                currentNode.Adjacent = GetChildren(currentNode);
                currentNode.Adjacent.ForEach(SetNodes);
            }
        }


        private List<Node> GetChildren(Node node)
        {
            return _graph.Where(x => x.Item1 == node.Id)
                .Select(y => new Node(y.Item2)).ToList();
        }

        private List<List<int>> GetAllPaths(int source, int destination)
        {
            List<List<int>> results = new List<List<int>>();
            List<int> path = new List<int> { source };
            GetAllPathsUtil(source, destination, path, ref results);

            return results;
        }
            
        private void GetAllPathsUtil(int source, int destination, List<int> path, ref List<List<int>> results)
        {
            _nodes[source].IsVisited = true;

            if (source == destination)
            {
                results.Add(new List<int>(path));
                path.ForEach(Console.Write);
                Console.WriteLine();
            }

            foreach (var adjacent in _nodes[source].Adjacent)
            {
                if (!adjacent.IsVisited)
                {
                    path.Add(adjacent.Id);
                    GetAllPathsUtil(adjacent.Id, destination, path, ref results);
                    var index = path.LastIndexOf(adjacent.Id);
                    path.RemoveAt(index);
                }
            }

            _nodes[source].IsVisited = false;
        }
    }
}