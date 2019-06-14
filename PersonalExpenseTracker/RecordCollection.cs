using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker
{
   public class RecordCollection : ObservableCollection<Record>
    {

        public RecordCollection(List<Bar> barvalues)
        {
            Random rand = new Random();
            BrushCollection brushcoll = new BrushCollection();

            foreach (Bar barval in barvalues)
            {
                int num = rand.Next(brushcoll.Count / 3);
                Add(new Record(barval.Value, brushcoll[num], barval.BarName));
            }
        }

    }
}
