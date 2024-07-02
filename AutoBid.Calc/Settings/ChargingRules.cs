namespace AutoBid.Calc.Settings
{
    public class ChargingRules 
    {
        public double BasicUserRate { get; set; } 

        public double CommonMin { get; set; }

        public double CommonMax { get; set; }

        public double LuxuryMin { get; set; }

        public double LuxuryMax { get; set; }

        public double SellerSpecialCommonFee { get; set; }

        public double SellerSpecialLuxuryFee { get; set; }

        public double AdditionalCost { get; set; }

        public double StorageFee { get; set; }

        public Dictionary<(double?, double?), double> AssociationRates { get; set; } = new Dictionary<(double?, double?), double>();
         
    }
}
