
namespace VendingMachine.Model
{
    public enum CoinType
    {
        Nickel,   // 0.05
        Dime,     // 0.10
        Quarter,  // 0.25
        Penny     // 0.01 - invalid
    }
    public static class Coin
    {
        public static decimal GetCoinValue(CoinType coinType)
        {
            return coinType switch
            {
                CoinType.Nickel => 0.05m,
                CoinType.Dime => 0.10m,
                CoinType.Quarter => 0.25m,
                _ => 0.00m
            };
        }

        public static bool IsValid(CoinType coinType)
        {
            return coinType == CoinType.Nickel || coinType == CoinType.Dime || coinType == CoinType.Quarter;
        }
    }
}
