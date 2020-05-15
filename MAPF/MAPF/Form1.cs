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
		public Form1()
		{
			this.Paint += new PaintEventHandler(f1_paint);
			InitializeComponent();
		}

		private void f1_paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawString("Multi-agent Path Finding", new Font("Verdana", 20), new SolidBrush(Color.DarkGreen), 40, 40);
			g.DrawRectangle(new Pen(Color.Pink, 3), 20, 20, 450, 100);
		}
	}
}
