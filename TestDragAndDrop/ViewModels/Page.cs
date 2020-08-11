using System.Collections.ObjectModel;
using System.Linq;

namespace TestDragAndDrop.ViewModels
{
	public class Page : ViewModel, IConteiner
	{
		private Core.Page form_;
		public Page(TestDragAndDrop.Core.Page form)
		{
			form_ = form;
		}
		public string Name
		{
			get
			{ return form_.Name; }
		}
		public double X
		{
			get
			{ return (double)form_.X; }
			set { form_.X = (int)value; }
		}
		public double Y
		{
			get { return (double)form_.Y; }
			set { form_.Y = (int)value; }
		}
		public double Width
		{
			get { return form_.Width; }
			set { form_.Width = (int)value; }
		}
		public double Height
		{
			get { return form_.Height; }
			set { form_.Height = (int)value; }
		}
		ObservableCollection<Control> controls = null;
		public ObservableCollection<Control> Controls
		{
			get
			{
				if (controls is null)
				{
					controls = new ObservableCollection<Control>();
					foreach (Core.Control control in form_.Controls)
					{
						controls.Add(new Control(control, this));
					}
				}
				return controls;
			}
			set
			{
				controls = value;
			}
		}
		public bool RemoveControl(Core.Control control)
		{
			if (form_.Controls.Contains(control))
			{
				form_.Controls.Remove(control);
				Controls.Remove(Controls.ToList().Find(x => x.CoreControl == control));
				return true;
			}
			return false;
		}
		public bool AddControl(Core.Control control)
		{
			form_.Controls.Add(control);
			controls.Add(new Control(control, this));
			OnPropertyChanged();
			return true;
		}
	}
}
