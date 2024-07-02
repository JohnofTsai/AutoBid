using AutoBid.Calc.Settings;

namespace AutoBid.Calc
{
    public class BiddingFeesCalculator : IBiddingFeesCalculator
    {
        private readonly ChargingRules _chargeRules;
        public BiddingFeesCalculator(IChargeRulesProvider rulesProvider)
        {
            this._chargeRules = rulesProvider.GetChargeRules();
        }

        public AutoBidFees CalcBiddingFees(Vehicle vehicle)
        {
            return new AutoBidFees
            {
                BasePrice = vehicle.Price,
                BasicUserFee = CalcCommonFee(vehicle),
                SellerSpecialFee = CalcSpecialFee(vehicle),
                AssociationFee = CalcAssociaFee(vehicle),
                StorageFee = _chargeRules.StorageFee
            };
        }

        private double CalcCommonFee(Vehicle vehicle)
        {
            var fee = vehicle.Price * _chargeRules.BasicUserRate;

            switch (vehicle.VehType)
            {
                case VehicleType.Luxury:
                    return fee < _chargeRules.LuxuryMin ? _chargeRules.LuxuryMin : fee >= _chargeRules.LuxuryMax ? _chargeRules.LuxuryMax : fee;
                case VehicleType.Common:
                default:
                    return fee < _chargeRules.CommonMin ? _chargeRules.CommonMin : fee >= _chargeRules.CommonMax ? _chargeRules.CommonMax : fee;

            }
        }

        private double CalcSpecialFee(Vehicle vehicle)
        {
            switch (vehicle.VehType)
            {
                case VehicleType.Luxury:
                    return _chargeRules.SellerSpecialLuxuryFee * vehicle.Price;
                case VehicleType.Common:
                default:
                    return _chargeRules.SellerSpecialCommonFee * vehicle.Price;
            }
        }

        private double CalcAssociaFee(Vehicle vehicle)
        {
            var segFee = _chargeRules.AssociationRates?.FirstOrDefault( s => vehicle.Price > (s.Key.Item1 ?? double.MinValue ) && vehicle.Price <= (s.Key.Item2 ?? double.MaxValue) ).Value;
            return segFee ?? 0;
        }
    }
}
