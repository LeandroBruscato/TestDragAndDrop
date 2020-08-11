using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestDragAndDrop.ViewModels;

namespace TestDragAndDrop.UserControls
{
	/// <summary>
	/// Interaction logic for Form.xaml
	/// </summary>
	public partial class Form : UserControl
	{
		public ViewModels.Page vmForm { get; set; }
		public Form()
		{
			throw new NotImplementedException();
		}
		public Form(ViewModels.Page form)
		{
			vmForm = form;
			DataContext = vmForm;
			InitializeComponent();
		}


		#region drag and Drop
		private void MyForm_Drop(object sender, DragEventArgs e)
		{
			try
			{
				UserControl _target = (sender as UserControl);

				Point currentPosition = e.GetPosition((sender as UserControl));

				ViewModels.Control draggedItems = e.Data.GetData(typeof(ViewModels.Control)) as ViewModels.Control;
				draggedItems.X = currentPosition.X;
				draggedItems.Y = currentPosition.Y;
				if(!vmForm.Controls.Contains(draggedItems))
				{
					IConteiner conteiner = draggedItems.Conteiner;
					if (vmForm.AddControl(draggedItems.CoreControl))
					{
						if (conteiner != null)
							draggedItems.Conteiner.RemoveControl(draggedItems.CoreControl);
					}
				}


				e.Handled = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		#endregion
	}
}
