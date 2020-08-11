using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestDragAndDrop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<ViewModels.Page> Pages { get; set; } =
			 new ObservableCollection<ViewModels.Page>
			 {
				 new ViewModels.Page(
				new Core.Page()
				{
					X = 100,
					Y = 100,
					Width = 230,
					Height = 300,
					Controls = new List<Core.Control>
					{
						new Core.Control()
						{
							X = 10,
							Y = 10,
							Width = 40,
							Height = 20,
						},
						new Core.Control()
						{
							X = 70,
							Y = 70,
							Width = 40,
							Height = 20,
						}
					}
				}),
					new ViewModels.Page(
					new Core.Page()
				{
					X = 400,
					Y = 400,
					Width = 230,
					Height = 300,
					Controls = new List<Core.Control>
					{
						new Core.Control()
						{
							X = 50,
							Y = 50,
							Width = 40,
							Height = 20,
						},
						new Core.Control()
						{
							X = 10,
							Y = 10,
							Width = 100,
							Height = 50,
						}
					}
				})
			 };
		public MainWindow()
		{


			InitializeComponent();
			DataContext = this;
		}

		private void ADD_Click(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				ViewModels.Control control = new ViewModels.Control(new Core.Control() { Width = 50, Height = 20 });

				DataObject dataObject = new DataObject(typeof(ViewModels.Control), control);
				DragDrop.DoDragDrop((sender as TextBlock), dataObject, DragDropEffects.Move);
			}
		}
		private void treeView_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.LeftButton == MouseButtonState.Pressed)
				{
					DataObject dataObject = new DataObject(typeof(ViewModels.Control), (sender as TreeView).SelectedItem);
					DragDrop.DoDragDrop((sender as TreeView), dataObject, DragDropEffects.Move);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
