using System.Collections.Generic;

namespace TestDragAndDrop.Core
{
	public class Control
	{
		static int IDCount = 0;
		public string Name { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public List<Control> Controls { get; set; } = new List<Control>();
		public Control()
		{
			Name = "Control_" + (IDCount++);
		}
	}
}