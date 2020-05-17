using MAPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Service
{
	public class AStar
	{
		public List<Node> SearchAstar(int[,] tileMap, int src, int dest)
		{
			List<Node> path = new List<Node>();
			Src src1 = new Src();
			src1.X = 1;
			src1.Y = 1;
			Node node1 = new Node(null,src1);

			Src src2 = new Src();
			src2.X = 2;
			src2.Y = 2;
			Node node2 = new Node(node1, src2);

			path.Add(node1);
			path.Add(node2);

			return path;
		}
	}
}
