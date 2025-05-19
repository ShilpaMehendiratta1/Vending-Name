
namespace VendingMachine.Models
{
    public enum ProductType
    {
        Cola,
        Chips,
        Candy
    }

    public static class Product
    {
        public static decimal GetPrice(ProductType product)
        {
            return product switch
            {
                ProductType.Cola => 1.00m,
                ProductType.Chips => 0.50m,
                ProductType.Candy => 0.65m,
                _ => 0.00m
            };
        }
    }
}
