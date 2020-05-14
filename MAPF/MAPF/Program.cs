using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAPF
{
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());

			var dictionary = new Dictionary<string, string>();
			


		}
		public bool Test3(IDictionary<string, string> dictionary)
		{
			var z = dictionary.IsReadOnly;
			return true;
		}

	}
}
