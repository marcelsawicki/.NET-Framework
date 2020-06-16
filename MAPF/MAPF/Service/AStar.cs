using MAPF.Interface;
using MAPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Service
{
	public class AStar : ISearch
	{
		public List<Node> Search(int[,] tileMap, Point src, Point dest, int gridCols, int gridRows)
		{
			List<Node> path = new List<Node>();
			List<Node> closeList = new List<Node>();
			List<Node> openList = new List<Node>();

			Node currentNode = null;

			Point srcSrc = new Point(src.X, src.Y);
			
			Node nodeSrc = new Node(null,srcSrc);

			openList.Add(nodeSrc);

			while (openList.Count > 0)
			{
				currentNode = openList.OrderBy(x => x.F).ElementAt(0); //openList.ElementAt(0);
				currentNode.Visited = true;

				if (currentNode.X == dest.X && currentNode.Y == dest.Y)
				{
					// targed reached
					break;
				}

				closeList.Add(currentNode);
				openList.RemoveAt(openList.IndexOf(currentNode));
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
						if (tileMap[col,row] == 1)
						{
							continue;
						}

						var dd = closeList.Where(x => x.X == col && x.Y == row).FirstOrDefault();

						if (dd != null)
						{
							continue;
						}

						var cc = openList.Where(x => x.X == col && x.Y == row).FirstOrDefault();
						if (cc != null)
						{
							continue;
						}


						// Not present in any lists, keep going.

						var n = new Node(currentNode, new Point(col, row));
						n.G = currentNode.G + 1;
						n.H = getDistance(n, dest);
						n.F = n.G + n.H;

						openList.Add(n);
					}

				}
			}

			while (currentNode.ParentNode != null)
			{
				path.Add(currentNode);
				currentNode = currentNode.ParentNode;
			}

			return path;
		}

		private double getDistance(Node n, Point dest)
		{
			double x1 = (double)(dest.X-n.X);
			double y1 = (double)(dest.Y-n.Y);
			return Math.Sqrt(x1*x1 + y1*y1);
		}
	}
}
