using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoBid.Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBid.Calc.Settings;

using NSubstitute;

namespace AutoBid.Calc.Tests
{
    [TestClass()]
    public class BiddingChargerTests
    {
        [TestMethod()]
        public void CalcChargeTestCase1()
        {
            var chargeRulesProvider = MockChargeRulesProvider();
            var calc = new BiddingFeesCalculator(chargeRulesProvider);

            var veh1 = new Vehicle { Price = 398, VehType = VehicleType.Common };
            var fees = calc.CalcBiddingFees(veh1);
            Assert.IsTrue(Math.Abs(550.76 - fees.Total ) < 0.01);
        }

        [TestMethod()]
        public void CalcChargeTestCase2()
        {
            var chargeRulesProvider = MockChargeRulesProvider();
            var calc = new BiddingFeesCalculator(chargeRulesProvider);

            var veh1 = new Vehicle { Price = 1800, VehType = VehicleType.Luxury };
            var fees = calc.CalcBiddingFees(veh1);
            Assert.IsTrue(Math.Abs(2167 - fees.Total) < 0.01);
        }

        private IChargeRulesProvider MockChargeRulesProvider()
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
            rules.AssociationRates.Add((3000, null), 30);
            var reader = Substitute.For<IChargeRulesProvider>();
            reader.GetChargeRules().Returns(rules);

            return reader;
        }

    }
}