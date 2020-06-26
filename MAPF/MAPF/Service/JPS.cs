using MAPF.Grid;
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
			List<Node> successors = new List<Node>();

			Node currentNode = null;

			Node nodeSrc = new Node(null, src);

			openList.Add(nodeSrc);

			while (openList.Count > 0)
			{
				currentNode = openList.OrderBy(x => x.F).ElementAt(0); //openList.ElementAt(0);
				currentNode.Visited = true;



				closeList.Add(currentNode);
				openList.RemoveAt(0);

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

						successors.Add(n);
					}

				}

				for (int s = 0; s < successors.Count; s++)
				{
					// successors, prune
					if (currentNode.ParentNode != null)
					{
						Node successor = successors.OrderBy(i => i.F).FirstOrDefault();

						successors.Remove(successor);

						int dXsuccessor = successor.X - currentNode.X;
						int dYsuccessor = successor.Y - currentNode.Y;

						if (dXsuccessor != 0 && dYsuccessor != 0) // diagonal case
						{

						}
						else // ortogonal case
						{
						}

						var nodeSuccessor = jump(currentNode.X, currentNode.Y, successor.X, successor.Y, src, dest, tileMap);

						if (nodeSuccessor != null)
						{
							var n = new Node(currentNode, nodeSuccessor);
							n.G = currentNode.G + 1;
							n.H = getDistance(n, dest);
							openList.Add(n);
						}
					}
					else
					{
						

							Node successor = successors.OrderBy(i => i.F).FirstOrDefault();
							successors.Remove(successor);
							openList.Add(successor);
					}

				}

			}

			while (currentNode.ParentNode != null)
			{
				path.Add(currentNode);
				currentNode = currentNode.ParentNode;
			}

			path.Add(currentNode);
			path.Add(new Node(currentNode, dest));
			return path;
		}
		private Point jump(int iPx, int iPy, int iX, int iY, Point src, Point dest, int[,] tileMap)
		{

			var tDx = iX - iPx;
			var tDy = iY - iPy;



			//check if not outside the grid
			if (iX <= 0 || iX >= this.gridCols) return null;
			if (iY <= 0 || iY >= this.gridRows) return null;

			// check if walkable
			if (tileMap[iX, iY] == 1)
			{
				return null;
			}

			// if node is the goal return it
			if (iX == dest.X && iY == dest.Y)
			{
				return new Point(iX, iY);
			}


			// check in horizontal and vertical directions for forced neighbors
			// Diagonal Case   
			if (tDx != 0 && tDy != 0)
			{
				//if (/*... Diagonal Forced Neighbor Check ...*/)
				Point point1 = new Point(iX - tDx, iY + tDy);
				Point point2 = new Point(iX - tDx, iY);
				Point point3 = new Point(iX + tDx, iY - tDy);
				Point point4 = new Point(iX, iY - tDy);

				if (point1.IsWalkable(tileMap) && !point2.IsWalkable(tileMap) || point3.IsWalkable(tileMap) && !point4.IsWalkable(tileMap))
				{
					return new Point(iX, iY);	
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
				if (tDx != 0)
				{
					// if (/*... Horizontal Forced Neighbor Check ...*/)
					Point point5 = new Point(iX + tDx, iY + 1);
					Point point6 = new Point(iX, iY + 1);
					Point point7 = new Point(iX + tDx, iY - 1);
					Point point8 = new Point(iX, iY - 1);

					if (point5.IsWalkable(tileMap) && !point6.IsWalkable(tileMap) || point7.IsWalkable(tileMap) && !point8.IsWalkable(tileMap))
					{
						return new Point(iX, iY);
					}
					/// Vertical case
				}
				else
				{
					//if (/*... Vertical Forced Neighbor Check ...*/)

					Point point9 = new Point(iX + 1, iY + tDy);
					Point point10 = new Point(iX + 1, iY);
					Point point11 = new Point(iX - 1, iY + tDy);
					Point point12 = new Point(iX - 1, iY);

					if (point9.IsWalkable(tileMap) && !point10.IsWalkable(tileMap) || point11.IsWalkable(tileMap) && !point12.IsWalkable(tileMap))
					{
						return new Point(iX, iY);
					}
				}
			}

			// when moving diagonally, must check for vertical/horizontal jump points
			if (tDx != 0 && tDy != 0)
			{
				var jx = jump(iX, iY, iX + tDx, iY, src, dest, tileMap);
				var jy = jump(iX, iY, iX, iY + tDy, src, dest, tileMap);
				if (jx != null || jy != null)
				{
					return new Point(iX, iY);
				}
			}

			// If forced neighbor was not found try next jump point
			return jump(iX, iY, iX + tDx, iY + tDy, src, dest, tileMap);

			// moving diagonally, must make sure one of the vertical/horizontal
			// neighbors is open to allow the path
			//Point point13 = new Point(iX + tDx, iY);
			//Point point14 = new Point(iX, iY + tDy);
			//if (point13.IsWalkable(tileMap) && point14.IsWalkable(tileMap))
			//{
			//	return jump(iX, iY, iX + tDx, iY + tDy, src, dest, tileMap);
			//}
			//else
			//{
			//	return null;
			//}
		}

		private double getDistance(Node n, Point dest)
		{
			double x1 = (double)(dest.X - n.X);
			double y1 = (double)(dest.Y - n.Y);
			return Math.Sqrt(x1 * x1 + y1 * y1);
		}
	}
}
