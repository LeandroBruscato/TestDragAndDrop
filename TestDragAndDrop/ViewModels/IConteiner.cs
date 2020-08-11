using System.Collections.ObjectModel;

namespace TestDragAndDrop.ViewModels
{
	public  interface IConteiner
	{
		ObservableCollection<Control> Controls { get; set; }
		bool RemoveControl(Core.Control control);
		bool AddControl(Core.Control control);
	}
}