using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Model
{
	class NodeDijkstra
	{
		public NodeDijkstra(NodeDijkstra parentNode, Point src, double shortest)
		{
			this.Previous = parentNode;
			this.X = src.X;
			this.Y = src.Y;
			this.Previous = parentNode;
			this.Shortest = shortest;
		}

		public NodeDijkstra Previous { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public double Shortest { get; set; }
	}
}
