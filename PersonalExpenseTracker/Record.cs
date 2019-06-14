using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PersonalExpenseTracker
{
    public class Record : INotifyPropertyChanged
    {
        public Brush Color { set; get; }

        public string Name { set; get; }

        private double _data;
        public double Data
        {
            set
            {
                if (_data != value)
                {
                    _data = value;

                }
            }
            get
            {
                return _data;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Record(double value, Brush color, string name)
        {
            Data = value;
            Color = color;
            Name = name;
        }

        protected void PropertyOnChange(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
    }
}
