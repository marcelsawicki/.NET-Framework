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
		public int xx1 = 450;
		public int yy2 = 100;
		public Form1()
		{
			this.Paint += new PaintEventHandler(f1_paint);
			InitializeComponent();
		}

		private void f1_paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawString(text1, new Font("Verdana", 20), new SolidBrush(Color.DarkGreen), 40, 40);
			g.DrawRectangle(new Pen(Color.Pink, 3), 20, 20, xx1, yy2);
		}

		private void f2_paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawString("JPS", new Font("Verdana", 20), new SolidBrush(Color.DarkGreen), 40, 40);
			g.DrawRectangle(new Pen(Color.Pink, 3), 20, 20, 450, 100);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			text1 = "ddssdsdsd";
			xx1 = 45;
			yy2 += 10;
			this.Invalidate();
		}
	}
}
