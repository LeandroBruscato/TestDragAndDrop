using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace TestDragAndDrop.Converter
{
	public class vmPageToUserControl : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is null)
				return null;

			//ObservableCollection<ViewModels.Form> vmforms = value as ObservableCollection<ViewModels.Form>;
			//ObservableCollection<UserControls.Form> ucforms = new ObservableCollection<UserControls.Form>();
			//foreach (ViewModels.Form vmform in vmforms)
			//	ucforms.Add(new UserControls.Form(vmform));

			//return ucforms;
			if (value is ViewModels.Page form)
				return new UserControls.Form(form);

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
