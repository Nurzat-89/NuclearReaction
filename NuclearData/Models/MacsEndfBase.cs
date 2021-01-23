using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public abstract class MacsEndfBase:IMacsEndfBase
    {
        protected string fileName;
        public List<Macs> MacsList { get; set; }
        public MacsEndfBase(string fn)
        {
            fileName = fn;
            MacsList = new List<Macs>();
            dataRead();
        }
        public List<Macs> GetMacsList(Constants.DATALIBS dataLib, double kt)
        {
            var lib = Constants.DataCenters[dataLib];
            var list = MacsList.Where(x => x.DataLib == lib && x.kT == kt)?.ToList();
            return list;
        }

        protected abstract void dataRead();
    }
}
