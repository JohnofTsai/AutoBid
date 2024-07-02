using AutoBid.Calc.Settings;

namespace AutoBid.Server
{
    /// <summary>
    /// This should read the settings from configuration in real world. 
    /// Here I would just hard code to make it work.
    /// </summary>
    public class ChargeRulesConfig : IChargeRulesProvider
    {
        private readonly IConfiguration _configuration;
        private ChargingRules? _chargeRules = null;

        public ChargeRulesConfig(IConfiguration config)
        {
            _configuration = config;
        }

        public ChargingRules GetChargeRules()
        {
            var rules = new ChargingRules
            {
                BasicUserRate = 0.1,
                CommonMax = 50,
                CommonMin = 10,
                LuxuryMax = 200,
                LuxuryMin = 35,
                SellerSpecialCommonFee = 0.02,
                SellerSpecialLuxuryFee = 0.04,
                StorageFee = 100,
                AssociationRates = new Dictionary<(double?, double?), double>()
            };

            rules.AssociationRates.Add((1, 500), 5);
            rules.AssociationRates.Add((500, 1000), 10);
            rules.AssociationRates.Add((1000, 3000), 15);
            rules.AssociationRates.Add((3000, null), 20);

            return rules;
        }
    }
}
