using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public class CrossSectionDataTable : BaseDataTable<BaseCrossSection>
    {
        public CrossSectionDataTable(string name):base(name)
        {

        }

        public override void InitTable()
        {
            Table.Columns.Add("E, ev", typeof(double));
            Table.Columns.Add("cs, barns", typeof(double));
        }
        public override void FillTable(List<BaseCrossSection> data)
        {
            Data = data;
            Table.Rows.Clear();
            foreach (var d in data)
            {
                Table.Rows.Add(d.En, d.Cs);
            }
        }
    }
}
