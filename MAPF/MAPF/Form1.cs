using MAPF.Model;
using MAPF.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAPF
{

	public partial class Form1 : Form
	{
		public string text1 = "Pathfinder";
		public int xx1 = 100;
		public int yy2 = 100;
		List<Node> NodeList = new List<Node>();
		int[,] tileMap = new int[100, 100];

		public Model.Point src = new Model.Point();
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
		}

		private void mPathPoint_Click(object sender, EventArgs e)
		{
			MouseEventArgs e2 = (MouseEventArgs)e;
			int convX = e2.X / 5;
			int convY = e2.Y / 5;
			this.src.X = convX;
			this.src.Y = convY;

			label1.Text = string.Format("X: {0} Y: {1}", convX, convY);
			MessageBox.Show(string.Format("X: {0} Y: {1}", convX, convY));
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
			this.xx1 = 100;
			this.yy2 = 100;
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

			Model.Point dest = new Model.Point(24,62);
			this.tileMap[dest.X, dest.Y] = 0;
			
			List<Node> path = astar.Search(this.tileMap, this.src, dest, 99, 99);

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
			for (int g = 1; g < 99; g++)
			{
				for (int k = 1; k < 99; k++)
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
	}
}
