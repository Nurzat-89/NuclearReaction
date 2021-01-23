using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearData.Models
{
    public interface IMacsEndfBase
    {
        List<Macs> MacsList { get; set; }
        List<Macs> GetMacsList(Constants.DATALIBS dataLib, double kt);
    }
}
