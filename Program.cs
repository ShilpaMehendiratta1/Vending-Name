using VendingMachine.Model;
using VendingMachine.Models;

var vendingMachine = new VendingMachine.Services.VendingMachine();

vendingMachine.InsertCoin(CoinType.Quarter);
vendingMachine.InsertCoin(CoinType.Penny); 
vendingMachine.InsertCoin(CoinType.Dime);

Console.WriteLine(vendingMachine.DisplayMessage); 


Console.WriteLine(vendingMachine.SelectProduct(ProductType.Candy)); 

vendingMachine.InsertCoin(CoinType.Quarter);
vendingMachine.InsertCoin(CoinType.Dime);

Console.WriteLine(vendingMachine.SelectProduct(ProductType.Candy)); 
Console.WriteLine(vendingMachine.DisplayMessage);

Console.WriteLine("Coin return: " + string.Join(", ", vendingMachine.CoinReturn)); 
