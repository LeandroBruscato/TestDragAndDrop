using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TestDragAndDrop.ViewModels
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected List<PropertyInfo> commandTypeProperties;
		List<PropertyInfo> properties;

		public ViewModel()
		{
			properties = this.GetType().GetProperties().ToList();
		}


		protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(field, newValue))
			{
				field = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}
			return false;
		}



		protected void OnPropertyChanged([CallerMemberName] string propertyName = "none passed")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void OnPropertiesChanged()
		{
			if (PropertyChanged == null)
				return;

			foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
				OnPropertyChanged(propertyInfo.Name);

		}
	}
}