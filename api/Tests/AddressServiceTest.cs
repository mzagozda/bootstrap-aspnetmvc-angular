using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;

namespace Tests
{
    [TestClass]
    public class AddressServiceTest
    {
        private AddressService _addressService;

        [TestInitialize]
        public void Setup()
        {
            _addressService = new AddressService();
        }

        [TestMethod]
        public void GetAddress()
        {
            AccountModel search = new() { FirstName = "Kirk", LastName = "Gibson", Balance = 7100 };
            string result = _addressService.GetAddress(search).Result;

            Assert.AreNotEqual(string.Empty, result);
        }

    }
}
