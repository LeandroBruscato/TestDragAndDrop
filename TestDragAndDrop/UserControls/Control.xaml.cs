using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestDragAndDrop.ViewModels;

namespace TestDragAndDrop.UserControls
{
	/// <summary>
	/// Interaction logic for Control.xaml
	/// </summary>
	public partial class Control : UserControl
	{
		public ViewModels.Control vmcontrol { get; set; }
		public Control()
		{
			throw new NotImplementedException();
		}
		public Control(ViewModels.Control control)
		{
			vmcontrol = control;
			InitializeComponent();
			DataContext = vmcontrol;
		}

		#region Drag And Drop
		Point _lastMouseDown;
		private void MyControl_MouseDown(object sender, MouseButtonEventArgs e)
		{
			_lastMouseDown = e.GetPosition((sender as UserControl));
		}
		private void MyControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				Point currentPosition = e.GetPosition((sender as UserControl));
				if (Math.Abs(currentPosition.X - _lastMouseDown.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(currentPosition.Y - _lastMouseDown.Y) > SystemParameters.MinimumVerticalDragDistance)
				{
					DataObject dataObject = new DataObject(typeof(ViewModels.Control), vmcontrol);
					DragDrop.DoDragDrop((sender as UserControl), dataObject, DragDropEffects.Move);
				}
			}
		}

		private void MyControl_Drop(object sender, DragEventArgs e)
		{
			try
			{
				UserControl _target = (sender as UserControl);

				Point currentPosition = e.GetPosition((sender as UserControl));

				ViewModels.Control draggedItems = e.Data.GetData(typeof(ViewModels.Control)) as ViewModels.Control;
				if (draggedItems != vmcontrol)
				{
					draggedItems.X = currentPosition.X;
					draggedItems.Y = currentPosition.Y;
					if (!vmcontrol.Controls.Contains(draggedItems))
					{
						IConteiner conteiner = draggedItems.Conteiner;
						if (vmcontrol.AddControl(draggedItems.CoreControl))
						{
							if (conteiner != null)
							{
								draggedItems.Conteiner.RemoveControl(draggedItems.CoreControl);
							}
						}
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			e.Handled = true;
		}
		#endregion
	}
}
