using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PersonalExpenseTracker
{
   public class BrushCollection : ObservableCollection<Brush>
    {
        public BrushCollection()
        {
            Type _brush = typeof(Brushes);
            PropertyInfo[] props = _brush.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Brush _color = (Brush)prop.GetValue(null, null);
                if (_color != Brushes.LightSteelBlue && _color != Brushes.White &&
                     _color != Brushes.WhiteSmoke && _color != Brushes.LightCyan &&
                     _color != Brushes.LightYellow && _color != Brushes.Linen)
                    Add(_color);
            }
        }
    }
}
