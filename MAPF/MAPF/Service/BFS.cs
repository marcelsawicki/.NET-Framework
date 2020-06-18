using MAPF.Interface;
using MAPF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Service
{
	class BFS : ISearch
	{ 
		public List<Node> Search(int[,] tileMap, Point src, Point dest, int gridCols, int gridRows)
		{

			Node currentNode = null;
			List<Node> path = new List<Node>();
			Queue<Node> Q = new Queue<Node>();
			List<Node> visited = new List<Node>();
			Node startNode = new Node(null, src);
			startNode.G = 0;
			Q.Enqueue(startNode);

			while (Q.Count > 0)
			{
				currentNode = Q.Dequeue();
				currentNode.Visited = true;
				visited.Add(currentNode);

				if (currentNode.X == dest.X && currentNode.Y == dest.Y)
				{
					// targed reached
					break;
				}

				Point nstart = new Point();
				nstart.X = currentNode.X - 1 >= 0 ? currentNode.X - 1 : 0;
				nstart.Y = currentNode.Y - 1 >= 0 ? currentNode.Y - 1 : 0;


				Point nstop = new Point();
				nstop.X = currentNode.X + 1 <= gridCols ? currentNode.X + 1 : gridCols;
				nstop.Y = currentNode.Y + 1 <= gridRows ? currentNode.Y + 1 : gridRows;

				// check eight neighbours

				for (int col = nstart.X; col <= nstop.X; col++)
				{
					for (int row = nstart.Y; row <= nstop.Y; row++)
					{
						if (tileMap[col, row] == 1)
						{
							continue;
						}

						//var dd = closeList.Where(x => x.X == col && x.Y == row).FirstOrDefault();

						//if (dd != null)
						//{
						//	continue;
						//}

						var dd = visited.Where(x => x.X == col && x.Y == row).FirstOrDefault();
						if (dd != null)
						{
							continue;
						}

						//// Not present in any lists, keep going.

						var n = new Node(currentNode, new Point(col, row));
						n.G = currentNode.G + 1;
						////n.H = getDistance(n, dest);
						//n.F = n.G + n.H;

						if (!Q.Any(o => (o.X == col && o.Y == row)))
						{
							Q.Enqueue(n);
						}
						

					}
				}

			}

			// path

			while (currentNode.ParentNode != null)
			{
				path.Add(currentNode);
				currentNode = currentNode.ParentNode;
			}

			return path;
		}

	}
}
