using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDragAndDrop.Core
{
	public class Page
	{
		static int IDCount = 0;
		public string Name { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public List<Control> Controls { get; set; } = new List<Control>();
		public Page()
		{
			Name = "Page_" + (IDCount++);
		}
	}
}
