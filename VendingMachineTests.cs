using VendingMachine.Models;
using VendingMachine.Model;

namespace VendingMachine.Tests
{
    public class VendingMachineTests
    {
        private Services.VendingMachine machine;

        [SetUp]
        public void Setup()
        {
            machine = new Services.VendingMachine();
        }

        [Test]
        public void Insert_Valid_Coins_Should_Update_Display()
        {
            machine.InsertCoin(CoinType.Quarter);
            machine.InsertCoin(CoinType.Dime);

            Assert.AreEqual("$0.35", machine.DisplayMessage);
        }

        [Test]
        public void Insert_Invalid_Coin_Should_Go_To_CoinReturn()
        {
            machine.InsertCoin(CoinType.Penny);

            Assert.AreEqual(1, machine.CoinReturn.Count);
            Assert.IsTrue(machine.CoinReturn.Contains(CoinType.Penny));
            Assert.AreEqual("INSERT COIN", machine.DisplayMessage);
        }

        [Test]
        public void Select_Product_Without_Enough_Money_Should_Show_Price()
        {
            machine.InsertCoin(CoinType.Dime);

            var result = machine.SelectProduct(ProductType.Candy);
            Assert.AreEqual("PRICE $0.65", result);
        }

        [Test]
        public void Select_Product_With_Enough_Money_Should_Dispense()
        {
            machine.InsertCoin(CoinType.Quarter);
            machine.InsertCoin(CoinType.Quarter);
            machine.InsertCoin(CoinType.Dime);
            machine.InsertCoin(CoinType.Nickel);

            var result = machine.SelectProduct(ProductType.Candy);

            Assert.AreEqual("THANK YOU", result);
            Assert.AreEqual("INSERT COIN", machine.DisplayMessage);
        }
    }
}
