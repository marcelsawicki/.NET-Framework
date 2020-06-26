using MAPF.Model;
using System.Collections.Generic;

namespace MAPF.Interface
{
	public interface ISearch
	{
		//IEnumerable<Point> Search(int[,] tileMap, Point startPosition, Point targetPosition);
		List<Node> Search(int[,] tileMap, Point src, Point dest, int gridCols, int gridRows);
	}
}