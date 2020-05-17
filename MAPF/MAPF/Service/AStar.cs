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
		public List<Node> SearchAstar(int[,] tileMap, Point src, Point dest, int gridCols, int gridRows)
		{
			List<Node> path = new List<Node>();
			List<Node> closeList = new List<Node>();
			List<Node> openList = new List<Node>();

			Node currentNode = null;

			Point srcSrc = new Point();
			srcSrc.X = 1;
			srcSrc.Y = 1;
			Node nodeSrc = new Node(null,srcSrc);

			openList.Add(nodeSrc);

			while (openList.Count > 0)
			{
				currentNode = openList.ElementAt(0);
				currentNode.Visited = true;

				if (currentNode.X == dest.X && currentNode.Y == dest.Y)
				{
					// targed reached
					break;
				}

				closeList.Add(currentNode);
				openList.RemoveAt(0);
				Point nstart = new Point();
				nstart.X = currentNode.X - 1 >= 0 ? currentNode.X - 1 : 0;
				nstart.Y = currentNode.Y - 1 >= 0 ? currentNode.Y - 1 : 0;


				Point nstop = new Point();
				nstop.X = currentNode.X + 1 >= 0 ? currentNode.X + 1 : gridCols;
				nstop.Y = currentNode.Y + 1 >= 0 ? currentNode.Y + 1 : gridRows;

				// check eight neighbours

				for (int col = nstart.X; col <= nstop.X; col++)
				{
					for (int row = nstart.Y; row <= nstop.Y; row++)
					{
						if (tileMap[col,row] == 1)
						{
							continue;
						}

						var n = new Node(currentNode, new Point(col, row));
						n.G = currentNode.G + 1;
					}

				}


			}

			
			
			

			return path;
		}
	}
}
