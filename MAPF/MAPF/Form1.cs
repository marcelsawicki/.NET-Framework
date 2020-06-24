using MAPF.Model;
using MAPF.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = MAPF.Model.Point;

namespace MAPF
{

	public partial class Form1 : Form
	{
		public string text1 = "Pathfinder";
		public static int xx1 = 100;
		public static int yy2 = 100;
		List<Node> NodeList = new List<Node>();
		int[,] tileMap = new int[xx1, yy2];

		public Model.Point src = new Model.Point(1, 1);
		public Model.Point goal = new Model.Point(99,99);
		public string filename;


		private static readonly Random random = new Random();
		private static readonly object syncLock = new object();
		public static int RandomNumber(int min, int max)
		{
			lock (syncLock)
			{ // synchronize
				return random.Next(min, max);
			}
		}


		public Form1()
		{
			//this.Paint += new PaintEventHandler(f1_paint);
			//this.Paint += new PaintEventHandler(f1_paint);
			//this.Paint += this.OnPaint;
			InitializeComponent();
			this.DoubleBuffered = true;
			InitMenus();
			this.Click += new EventHandler(mPathPoint_Click);
			label1.Text = string.Format("X: {0} Y: {1}", this.src.X, this.src.Y);
			label4.Text = string.Format("X: {0} Y: {1}", this.goal.X, this.goal.Y);

		}

		private void mPathPoint_Click(object sender, EventArgs e)
		{
			MouseEventArgs e2 = (MouseEventArgs)e;
			int convX = e2.X / 5;
			int convY = e2.Y / 5;

			if (checkBox1.Checked)
			{
				this.src.X = convX;
				this.src.Y = convY;
				label1.Text = string.Format("X: {0} Y: {1}", convX, convY);
				MessageBox.Show(string.Format("X: {0} Y: {1}", convX, convY));
			}
			else if(checkBox2.Checked)
			{
				this.goal.X = convX;
				this.goal.Y = convY;
				label4.Text = string.Format("X: {0} Y: {1}", convX, convY);
				MessageBox.Show(string.Format("X: {0} Y: {1}", convX, convY));
			}
			

			
		}

		void InitMenus()
		{
			// MainMenu
			MainMenu mainMenu = new MainMenu();
			MenuItem mFile = new MenuItem("File");
			MenuItem mHelp = new MenuItem("Help");

			MenuItem mFileLoad = new MenuItem("Load map");
			MenuItem mFileSave = new MenuItem("Save map");
			MenuItem mFileExit = new MenuItem("Exit");

			mFileLoad.Click += new EventHandler(mPlikLoad_Click);
			mFileSave.Click += new EventHandler(mPlikSave_Click);
			mFileExit.Click += new EventHandler(mPlikExit_Click);


			MenuItem mHelpAbout = new MenuItem("About");
			mHelpAbout.Click += new EventHandler(mPlikAbout_Click);

			mFile.MenuItems.Add(mFileLoad);
			mFile.MenuItems.Add(mFileSave);
			mFile.MenuItems.Add(mFileExit);

			mHelp.MenuItems.Add(mHelpAbout);


			mainMenu.MenuItems.Add(mFile);
			mainMenu.MenuItems.Add(mHelp);
			this.Menu = mainMenu;
		}

		private void mPlikAbout_Click(object sender, EventArgs e)
		{
			AboutBox1 a = new AboutBox1();
			a.ShowDialog();
		}

		void mPlikExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void mPlikLoad_Click(object sender, EventArgs e)
		{

			openFileDialog1.ShowDialog();
			this.filename = openFileDialog1.FileName;
			label6.Text = this.filename;

		}

		void mPlikSave_Click(object sender, EventArgs e)
		{
			CSecondaryForm f = new CSecondaryForm();
			f.ShowDialog();

		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics g = e.Graphics;
			// draw here
			int startCol = xx1;
			int startRow = yy2;

			int countCol = startCol;
			int countRow = startRow;
			//g.DrawString(text1, new Font("Verdana", 20), new SolidBrush(Color.DarkGreen), 40, 40);


			for (int col = 0; col < countCol; col++)
			{
				for (int row = 0; row < countRow; row++)
				{

					int tilePositionX = 5 * col;
					int tilePositionY = 5 * row;
					Pen p = new Pen(Color.Blue, 1);
					Rectangle rect1 = new Rectangle(tilePositionX, tilePositionY, 5, 5);
					g.DrawRectangle(p, rect1);
					if (tileMap[col, row] == 1)
					{
						SolidBrush blueBrush = new SolidBrush(Color.Blue);
						g.FillRectangle(blueBrush, rect1);
					}
					else if (tileMap[col, row] == 2)
					{
						SolidBrush redBrush = new SolidBrush(Color.Red);
						g.FillRectangle(redBrush, rect1);
					}
				}

			}
		}


		private void button1_Click(object sender, EventArgs e)
		{

			for (int i = 0; i < 1000; i++)
			{
				Random random = new Random();
				int randX = RandomNumber(0, 100);
				int randY = RandomNumber(0, 100);

				this.tileMap[randX, randY] = 1;
			}
			this.tileMap[1, 1] = 2;
			Refresh();

		}

		private void button2_Click(object sender, EventArgs e)
		{

			for (int col = 0; col < 100; col++)
			{
				for (int row = 0; row < 100; row++)
				{

					this.tileMap[col, row] = 0;
				}

			}

			Refresh();
			
		}

		private void button6_Click(object sender, EventArgs e)
		{
			// JPS
			JPS jps = new JPS();
			Model.Point src = new Model.Point(1, 1);

			Model.Point dest = new Model.Point(20, 1);
			this.tileMap[dest.X, dest.Y] = 0;

			List<Node> path = jps.Search(this.tileMap, src, dest, 99, 99);

			foreach (var p in path)
			{
				this.tileMap[p.X, p.Y] = 2;
			}
			Refresh();
		}

		private void button5_Click(object sender, EventArgs e)
		{

		}


		private void button3_Click(object sender, EventArgs e)
		{
			// A Star
			AStar astar = new AStar();
			//Model.Point src = new Model.Point(1,1);

			if (this.src == null)
			{
				//Model.Point src = new Model.Point(1, 1);
			}

			Model.Point dest = this.goal;
			this.tileMap[dest.X, dest.Y] = 0;
			var sw = Stopwatch.StartNew();
			List<Node> path = astar.Search(this.tileMap, this.src, dest, xx1-1, yy2-1);
			sw.Stop();
			label8.Text = $"Time: {sw.Elapsed.TotalMilliseconds}ms";
			foreach (var p in path)
			{
				this.tileMap[p.X, p.Y] = 2;
			}
			Refresh();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Color pixelColor;
			// Create a Bitmap object from an image file.
			Bitmap myBitmap = new Bitmap(this.filename);
			for (int g = 1; g < xx1-1; g++)
			{
				for (int k = 1; k < yy2-1; k++)
				{
					pixelColor = myBitmap.GetPixel(g, k);
					if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0)
					{
						this.tileMap[g, k] = 1;
					}
				}

			}

			Refresh();
		}

		private void button8_Click(object sender, EventArgs e)
		{

		}

		private void button7_Click(object sender, EventArgs e)
		{

		}
		// Dijkstra
		private void button5_Click_1(object sender, EventArgs e)
		{
			// Dijkstra
			Dijkstra dijkstra = new Dijkstra();

			var sw = Stopwatch.StartNew();
			List<Node> path = dijkstra.Search(this.tileMap, this.src, this.goal, xx1, yy2);
			sw.Stop();
			label8.Text = $"Time: {sw.Elapsed.TotalMilliseconds}ms";
			foreach (var p in path)
			{
				this.tileMap[p.X, p.Y] = 2;
			}
			Refresh();
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			// BFS
			BFS bfs = new BFS();

			var sw = Stopwatch.StartNew();
			List<Node> path = bfs.Search(this.tileMap, this.src, this.goal, xx1, yy2);
			sw.Stop();
			label8.Text = $"Time: {sw.Elapsed.TotalMilliseconds}ms";
			foreach (var p in path)
			{
				this.tileMap[p.X, p.Y] = 2;
			}
			Refresh();
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			// DFS
			DFS dfs = new DFS();
			dfs.Form = this;
			var sw = Stopwatch.StartNew();
			int bestLength = int.MaxValue;
			IEnumerable<Point> bestPath = null;
			for (int i = 0; i < 5000; i++)
			{
				var path = dfs.Search(this.tileMap, this.src, this.goal);

				if (path != null && path.Count() < bestLength)
				{
					bestPath = path;
					bestLength = path.Count();
				}
			}
			sw.Stop();
			label8.Text = $"Time: {sw.Elapsed.TotalMilliseconds}ms";

			if (bestPath == null)
			{
				MessageBox.Show("Path does not exist.", "DFS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				foreach (var p in bestPath)
				{
					this.tileMap[p.X, p.Y] = 2;
				}
				Refresh();
			}
		}

		private void button8_Click_1(object sender, EventArgs e)
		{
			// JPS
			JPS jps = new JPS();

			var sw = Stopwatch.StartNew();
			List<Node> path = jps.Search(this.tileMap, this.src, this.goal, xx1, yy2);
			sw.Stop();
			label8.Text = $"Time: {sw.Elapsed.TotalMilliseconds}ms";
			foreach (var p in path)
			{
				this.tileMap[p.X, p.Y] = 2;
			}
			Refresh();
		}
	}
}
