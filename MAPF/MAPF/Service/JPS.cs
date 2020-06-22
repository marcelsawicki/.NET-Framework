using MAPF.Interface;
using MAPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Service
{
	class JPS : ISearch
	{
		private int gridCols { get; set; }
		private int gridRows { get; set; }

		public List<Node> Search(int[,] tileMap, Point src, Point dest, int gridCols, int gridRows)
		{
			this.gridCols = gridCols;
			this.gridRows = gridRows;
			List<Node> path = new List<Node>();
			List<Node> closeList = new List<Node>();
			List<Node> openList = new List<Node>();
			Stack<Node> successors = new Stack<Node>();
			Point point;

			Node currentNode = null;

			Point srcSrc = new Point(1, 1);

			Node nodeSrc = new Node(null, srcSrc);

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
				openList.RemoveAt(0);
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

						//// try to jump
						//var dX = currentNode.X - col;
						//var dY = currentNode.Y - row;
						//var m = jump(currentNode.X, currentNode.Y, dX, dY, src, dest, tileMap);

						//if (m != null)
						//{
						//	point = new Point(m.X, m.Y);
						//}
						//else
						//{
						//	point = new Point(col, row);
						//}

						// Not present in any lists, keep going.

						var n = new Node(currentNode, new Point(row, col));
						n.G = currentNode.G + 1;
						n.H = getDistance(n, dest);

						successors.Push(n);
					}

				}

				// successors, prune
				if (currentNode.ParentNode != null)
				{
					Node successor = successors.OrderBy(i => i.F).FirstOrDefault();

					int dXsuccessor = successor.X - currentNode.X;
					int dYsuccessor = successor.Y - currentNode.Y;

					if (dXsuccessor != 0 && dYsuccessor != 0) // diagonal case
					{

					}
					else // ortogonal case
					{ 
					}

					var dX = successor.X - currentNode.X;
					var dY = successor.Y - currentNode.Y;
					var nodeSuccessor = jump(currentNode.X, currentNode.Y, dX, dY, src, dest, tileMap);

					if (nodeSuccessor != null)
					{
						var n = new Node(currentNode, nodeSuccessor);
						n.G = currentNode.G + 1;
						n.H = getDistance(n, dest);
						openList.Add(n);
					}
					else
					{
						for (int k = 0; k < successors.Count; k++)
						{
							openList.Add(successors.Pop());
						}
					}
				}
				else
				{
					for (int k = 0; k < successors.Count; k++)
					{
						openList.Add(successors.Pop());
					}
				}
			}

			while (currentNode.ParentNode != null)
			{
				path.Add(currentNode);
				currentNode = currentNode.ParentNode;
			}

			path.Add(currentNode);
			return path;
		}
		private Point jump(int cX, int cY, int dX, int dY, Point start, Point end, int[,] tileMap)
		{

			var nextX = cX + dX;
			var nextY = cY + dY;



			//check if not outside the grid
			if (nextX <= 0 || nextX > this.gridCols) return null;
			if (nextY <= 0 || nextY > this.gridRows) return null;

			// check if walkable
			if (tileMap[nextX, nextY] == 1)
			{
				return null;
			}

			// if node is the goal return it
			if (nextX == end.X && nextY == end.Y)
			{
				return new Point(nextX, nextY);
			}


			// check in horizontal and vertical directions for forced neighbors
			// Diagonal Case   
			if (dX != 0 && dY != 0)
			{
				//if (/*... Diagonal Forced Neighbor Check ...*/)
				Point point1 = new Point(cX - dX, cY + dY);
				Point point2 = new Point(cX - dX, cY);
				Point point3 = new Point(cX + dX, cY - dY);
				Point point4 = new Point(cX, cY - dY);

				if (point1.IsWalkable(tileMap) && !point2.IsWalkable(tileMap) || point3.IsWalkable(tileMap) && !point4.IsWalkable(tileMap))
				{
					return new Point(cX, cX);	
				}

				//// Check in horizontal and vertical directions for forced neighbors
				//// This is a special case for diagonal direction
				//if (jump(nextX, nextY, dX, 0, start, end, tileMap) != null ||
				//	jump(nextX, nextY, 0, dY, start, end, tileMap) != null)
				//{
				//	return new Point(nextX, nextY);
				//}
			}
			else
			{
				// Horizontal case
				if (dX != 0)
				{
					// if (/*... Horizontal Forced Neighbor Check ...*/)
					Point point5 = new Point(cX, cY + 1);
					Point point6 = new Point(cX - dX, cY + 1);
					Point point7 = new Point(cX, cY - 1);
					Point point8 = new Point(cX - dX, cY - 1);

					if (point5.IsWalkable(tileMap) && !point6.IsWalkable(tileMap) || point7.IsWalkable(tileMap) && !point8.IsWalkable(tileMap))
					{
						return new Point(nextX, nextY);
					}
					/// Vertical case
				}
				else
				{
					//if (/*... Vertical Forced Neighbor Check ...*/)

					Point point9 = new Point(cX+1, cY);
					Point point10 = new Point(cX + 1, cY - dX);
					Point point11 = new Point(cX - 1, cY);
					Point point12 = new Point(cX - 1, cY - dY);

					if (point9.IsWalkable(tileMap) && !point10.IsWalkable(tileMap) || point11.IsWalkable(tileMap) && !point12.IsWalkable(tileMap))
					{
						return new Point(nextX, nextY);
					}
				}
			}

			// If forced neighbor was not found try next jump point

			return jump(nextX, nextY, dX, dY, start, end, tileMap);
		}

		private double getDistance(Node n, Point dest)
		{
			double x1 = (double)(dest.X - n.X);
			double y1 = (double)(dest.Y - n.Y);
			return Math.Sqrt(x1 * x1 + y1 * y1);
		}
	}
}
