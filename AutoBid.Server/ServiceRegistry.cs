using AutoBid.Calc;
using AutoBid.Calc.Settings;

namespace AutoBid.Server
{
    internal static class ServiceRegistry
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IChargeRulesProvider, ChargeRulesConfig>();
            services.AddSingleton<IBiddingFeesCalculator, BiddingFeesCalculator>();
        }
    }
}
