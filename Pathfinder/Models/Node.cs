using System.Collections.Generic;

namespace Pathfinder.Models
{
    public class Node
    {
        public Node(int id)
        {
            Id = id;
            Adjacent = new List<Node>();
        }

        public int Id { get; set; }
        public List<Node> Adjacent { get; set; }
        public bool IsVisited { get; set; }
    }
}