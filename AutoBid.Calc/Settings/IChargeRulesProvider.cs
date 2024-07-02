using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Calc.Settings
{
    public interface IChargeRulesProvider
    {
        ChargingRules GetChargeRules();
    }

}
