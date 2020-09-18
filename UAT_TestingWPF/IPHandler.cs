using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAT_TestingWPF
{
    public interface IPHandler
    {
        string OverrideIP { get; set; }

        string Dns1 { get; }

        string Dns2 { get; }

        string LocalIP { get; set; }

        string LocalSubnet { get; set; }

        string LocalDefaultGateway { get; set; }
    }
}
