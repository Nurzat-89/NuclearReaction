using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazNuclide.Models
{
    public class HeatDensityDataTable : BaseDataTable<BaseHeatDensity>
    {
        public HeatDensityDataTable(string name) :base(name)
        {

        }
        public override void FillTable(List<BaseHeatDensity> data)
        {
            Data = data;
            Table.Rows.Clear();
            foreach (var d in data)
            {
                Table.Rows.Add(d.NeutronFlux, d.HeatDensity);
            }
        }

        public override void InitTable()
        {
            Table.Columns.Add("Flux", typeof(double));
            Table.Columns.Add("Heat deansity, J/cm3*sec", typeof(string));
        }
    }
}
