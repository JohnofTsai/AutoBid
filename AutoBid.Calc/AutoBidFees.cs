using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Calc
{
    public class AutoBidFees
    {
        public double BasePrice { get; set; }
        public double BasicUserFee { get; set; }
        public double SellerSpecialFee { get; set; }
        public double AssociationFee { get; set; }
        public double StorageFee { get; set; }
        public double Total => BasePrice + BasicUserFee + SellerSpecialFee + AssociationFee + StorageFee;
    }
}
