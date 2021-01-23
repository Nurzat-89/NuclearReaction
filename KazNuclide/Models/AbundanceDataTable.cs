using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public class AbundanceDataTable : BaseDataTable<BaseAbundance>
    {
        public AbundanceDataTable(string name):base(name)
        {

        }
        public override void InitTable()
        {
            Table.Columns.Add("Name", typeof(string));
            Table.Columns.Add("Atomic weight", typeof(double));
            Table.Columns.Add("Abundance", typeof(double));
            Table.Columns.Add("Avg cs, barn", typeof(double));
            Table.Columns.Add("sig x ab", typeof(double));
            Table.Columns.Add("Halfe life, sec", typeof(double));
        }
        public override void FillTable(List<BaseAbundance> data)
        {
            Data = data;
            Table.Rows.Clear();
            foreach (var d in data)
            {
                Table.Rows.Add(d.IsotopeName, d.AtomicWeight, d.Density, d.AvgCs, d.sig_weight, d.HalfLife);
            }
        }
    }
}
