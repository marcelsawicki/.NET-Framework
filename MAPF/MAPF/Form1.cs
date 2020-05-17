﻿using MAPF.Model;
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
		public string text1 = "Multi-agent Path Finding";
		public int xx1 = 100;
		public int yy2 = 100;
		List<Node> NodeList = new List<Node>();
		int[,] tileMap = new int[100, 100];


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
	}
}
