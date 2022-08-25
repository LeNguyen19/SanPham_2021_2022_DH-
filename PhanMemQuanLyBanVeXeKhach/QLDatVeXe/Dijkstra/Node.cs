using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Node
    {
        public string Name { get; set; }
        public int Distance = -1;
        public string Previous = "";
        public bool Iterated = false;
        public Node(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return "Node{" +
                   "name=" + Name +
                   ", distance=" + Distance +
                   ", previous='" + Previous + '\'' +
                   '}';
        }
    }
}
