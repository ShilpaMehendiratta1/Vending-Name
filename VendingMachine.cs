using VendingMachine.Models;
using VendingMachine.Model;

namespace VendingMachine.Services
{
    public class VendingMachine
    {
        private decimal _currentAmount;
        private readonly List<CoinType> _coinReturn = new();

        public string DisplayMessage => GetDisplay();

        public void InsertCoin(CoinType coin)
        {
            if (Coin.IsValid(coin))
                _currentAmount += Coin.GetCoinValue(coin);
            else
                _coinReturn.Add(coin);
        }

        public string SelectProduct(ProductType product)
        {
            var price = Product.GetPrice(product);

            if (_currentAmount >= price)
            {
                _currentAmount -= price;
                _currentAmount = 0.0m; 
                return "THANK YOU";
            }

            return $"PRICE ${price:0.00}";
        }

        public List<CoinType> CoinReturn => _coinReturn;

        private string GetDisplay()
        {
            return _currentAmount == 0.0m
                ? "INSERT COIN"
                : $"${_currentAmount:0.00}";
        }

        public void Reset()
        {
            _currentAmount = 0.0m;
            _coinReturn.Clear();
        }
    }
}
