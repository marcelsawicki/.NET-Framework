using MAPF.Interface;
using MAPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Service
{
	class Dijkstra : ISearch
	{
		public List<Node> Search(int[,] tileMap, Point src, Point dest, int gridCols, int gridRows)
		{
			List<Node> path = new List<Node>();
			List<NodeDijkstra> closeList = new List<NodeDijkstra>();
			List<NodeDijkstra> openList = new List<NodeDijkstra>();


			List<NodeDijkstra> collectionQ = new List<NodeDijkstra>();


			NodeDijkstra currentNode = null;

			Point srcSrc = new Point(src.X, src.Y);

			NodeDijkstra nodeSrc = new NodeDijkstra(null, srcSrc, 0);

			openList.Add(nodeSrc);

			while (openList.Count > 0)
			{
				double value = openList.Min(x => x.Shortest);
				currentNode = openList.Where(i => i.Shortest == value).FirstOrDefault();

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
				// sprawdz wszystkich sasiadow

				for (int col = nstart.X; col <= nstop.X; col++)
				{
					for (int row = nstart.Y; row <= nstop.Y; row++)
					{
						if (tileMap[col, row] == 1)
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

						var n = new NodeDijkstra(currentNode, new Point(col, row), int.MaxValue);
						Relaxation(currentNode, n);

						openList.Add(n); // Q collection
					}

				}
			}

			while (currentNode.Previous != null)
			{
				Node pathNode = new Node(null, new Point(currentNode.X, currentNode.Y));
				path.Add(pathNode);
				currentNode = currentNode.Previous;
			}

			return path;
		}

		private void Relaxation(NodeDijkstra currentNode, NodeDijkstra n)
		{
			if (currentNode.Shortest + 1 < n.Shortest)
			{
				n.Shortest = currentNode.Shortest + 1;
				n.Previous = currentNode;
			}
		}
	}
}
