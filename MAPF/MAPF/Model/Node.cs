using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Model
{
	public class Node
	{
		public Node(Node parentNode, Point src)
		{
			this.ParentNode = parentNode;
			this.X = src.X;
			this.Y = src.Y;
			this.F = 0;
			this.G = 0;
			this.H = 0;
		}

		public Node ParentNode { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public double F { get; set; }
		public int G { get; set; }
		public double H { get; set; }
		public bool Visited { get; set; }
	}
}
