using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TestDragAndDrop.Core;

namespace TestDragAndDrop.ViewModels
{
	public class Control: ViewModel , IConteiner
	{
		private Core.Control control_;
		private IConteiner conteiner_;
		public Control(TestDragAndDrop.Core.Control control, IConteiner conteiner = null)
		{
			control_ = control;
			conteiner_ = conteiner;
		}
		public string Name
		{
			get
			{ return control_.Name; }
		}
		public double X
		{
			get { return control_.X; }
			set {
				control_.X = (int)value;
				OnPropertyChanged();
			}
		}

		public double Y
		{
			get { return control_.Y; }
			set
			{
				control_.Y = (int)value;
				OnPropertyChanged();
			}
		}

		public double Width
		{
			get { return control_.Width; }
			set { control_.Width = (int)value; }
		}

		public double Height
		{
			get { return control_.Height; }
			set { control_.Height = (int)value; }
		}
		public IConteiner Conteiner
		{
			get
			{
				return conteiner_;
			}
		}
		public Core.Control CoreControl
		{
			get
			{
				return control_;
			}
		}

		ObservableCollection<Control> controls = null;
		public ObservableCollection<Control> Controls
		{
			get
			{
				if (controls is null)
				{
					controls = new ObservableCollection<Control>();
					foreach (Core.Control control in control_.Controls)
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
			if (control_.Controls.Contains(control))
			{

				control_.Controls.Remove(control);

				Controls.Remove(Controls.ToList().Find(x => x.CoreControl == control));
				return true;
			}
			return false;
		}
		public bool AddControl(Core.Control control)
		{
			control_.Controls.Add(control);
			controls.Add(new Control(control, this));
			OnPropertyChanged();
			return true;
		}
	}
}