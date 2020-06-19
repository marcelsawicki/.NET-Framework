using MAPF.Interface;
using MAPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Service
{
	class DFS : ISearch
	{
		public List<Node> Search(int[,] tileMap, Point src, Point dest, int gridCols, int gridRows)
		{
			Node currentNode = null;
			List<Node> path = new List<Node>();
			Stack<Node> stack = new Stack<Node>();
			List<Node> visited = new List<Node>();
			List<Node> neighbours = new List<Node>();
			bool tagetReached = false;

			Node startNode = new Node(null, src);
			startNode.G = 0;
			stack.Push(startNode);

			// find all neighbours
			// get first neighbour and explore - find all neighbours, get one and visit

			while (stack.Count > 0 && tagetReached!=true)
			{
				currentNode = stack.Pop();
				Node parent = currentNode;
				if (currentNode.X == dest.X && currentNode.Y == dest.Y)
				{
					// targed reached
					tagetReached = true;
					break;
				}

				neighbours = FindNeighbours(tileMap, visited, currentNode, stack, gridCols, gridRows, dest);			

				currentNode = neighbours.FirstOrDefault();
				if (currentNode != null)
				{
					var zz = visited.Where(x => x.X == currentNode.X && x.Y == currentNode.Y).FirstOrDefault();
					if (zz == null)
					{

						tagetReached = VisitNode(tileMap, visited, neighbours.FirstOrDefault(), stack, gridCols, gridRows, dest, parent);


					}

					stack.Push(currentNode);
				}

			}
				
			// path
			// order by G

			int cost = currentNode.G;

			while (currentNode.ParentNode != null)
			{
				if (currentNode.G <= cost)
				{
					path.Add(currentNode);
					currentNode = currentNode.ParentNode;
				}
				
			}

			return path;
		}

		private bool VisitNode(int[,] tileMap, List<Node> visited, Node currentNode, Stack<Node> stack, int gridCols, int gridRows, Point dest, Node parent)
		{
			currentNode.ParentNode = parent;
			parent = currentNode;
			List<Node> neighbours = new List<Node>();
			visited.Add(currentNode);
			stack.Push(currentNode);
			neighbours = FindNeighbours(tileMap, visited, currentNode, stack, gridCols, gridRows, dest);
			currentNode = neighbours.FirstOrDefault();
			if (currentNode != null)
			{
				if (currentNode.X == dest.X && currentNode.Y == dest.Y)
				{
					// targed reached
					return true;
				}
				var zz = visited.Where(x => x.X == currentNode.X && x.Y == currentNode.Y).FirstOrDefault();
				if (zz != null)
				{
					VisitNode(tileMap, visited, neighbours.FirstOrDefault(), stack, gridCols, gridRows, dest, parent);
				}
			}
			return false;
			
		}

		private List<Node> FindNeighbours(int[,] tileMap, List<Node> visited, Node currentNode, Stack<Node> stack, int gridCols, int gridRows, Point dest)
		{	
			List<Node> neighbours = new List<Node>();

			// find all neighbours, but get one and visit
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

					var dd = visited.Where(x => x.X == col && x.Y == row).FirstOrDefault();
					if (dd != null)
					{
						continue;
					}

					var n = new Node(null, new Point(col, row));
					n.G = currentNode.G + 1;
					
					neighbours.Add(n);
				}
			}


			return neighbours;

		}


		private void Explore2(int[,] tileMap, List<Node> visited, Point point, Node currentNode, Stack<Node> stack, int gridCols, int gridRows, Point dest)
		{

			while (stack.Count > 0)
			{
				currentNode = stack.Pop();
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

						var dd = visited.Where(x => x.X == col && x.Y == row).FirstOrDefault();
						if (dd != null)
						{
							continue;
						}

						var de = stack.Where(x => x.X == col && x.Y == row).FirstOrDefault();
						if (de != null)
						{
							continue;
						}

						var n = new Node(currentNode, point);
						n.G = currentNode.G + 1;
						stack.Push(n);
					}
				}

			}
		}
	}
}