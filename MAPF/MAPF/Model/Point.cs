using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPF.Model
{
	public class Point
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Point()
		{

		}

		public Point(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}
		public bool IsWalkable(int[,] tileMap)
		{
			if (tileMap[this.X, this.Y] != 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}



	public class ShortPoint
	{
		public short X { get; }
		public short Y { get; }
		public ShortPoint(short x, short y)
		{
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			if (obj is ShortPoint p)
			{
				return this == p;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return X + Y * 30000;
		}

		public Point ToPoint()
		{
			return new Point(X, Y);
		}

		public IEnumerable<ShortPoint> GetNeighbours(int[,] tileMap)
		{
			int gridCols = tileMap.GetLength(0);
			int gridRows = tileMap.GetLength(1);

			for (short dy = -1; dy <= 1; dy++)
			{
				for (short dx = -1; dx <= 1; dx++)
				{
					if (dx != 0 || dy != 0)
					{
						int x = X + dx;
						int y = Y + dy;

						if (x >= 0 && y >= 0 && x < gridCols && y < gridRows)
						{
							if (tileMap[x, y] == 0)
							{
								yield return new Point(x, y);
							}							
						}
					}
				}
			}
		}

		public static implicit operator ShortPoint(Point point) => new ShortPoint((short)point.X, (short)point.Y);

		public static bool operator ==(ShortPoint a, ShortPoint b)
		{
			return a.X == b.X && a.Y == b.Y;
		}
		public static bool operator !=(ShortPoint a, ShortPoint b)
		{
			return a.X != b.X || a.Y != b.Y;
		}

	}
}