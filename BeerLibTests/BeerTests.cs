using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLib.Tests
{
    [TestClass()]
    public class BeerTests
    {
        private Beer _validBeer = new() { Id = 0, Name = "Beer", Abv = 0 };
        private Beer _idBadBeer = new() { Id = -1, Name = "Beer", Abv = 0 };
        private Beer _idNullBeer = new() { Id = null, Name = "Beer", Abv = 67 };
        private Beer _nameBadBeer = new() { Id = 0, Name = "Bo", Abv = 1 };
        private Beer _nameNullBeer = new() { Id = 0, Name = null, Abv = 0 };
        private Beer _abvBadBeerBelow = new() { Id = 0, Name = "Bo", Abv = -1 };
        private Beer _abvBadBeerAbove = new() { Id = 0, Name = "Bo", Abv = 68 };

        [TestMethod()]
        public void ToStringTest()
        {
            string br = _validBeer.ToString();
            Assert.AreEqual("0, Beer, 0", br);
        }
        [TestMethod()]
        public void ValidateIdTest()
        {
            _validBeer.ValidateId();

            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => _idBadBeer.ValidateId());

            Assert.ThrowsException<ArgumentNullException>(()
                => _idNullBeer.ValidateId());
        }
        [TestMethod()]
        public void ValidateNameTest()
        {
            _validBeer.ValidateName();

            Assert.ThrowsException<ArgumentException>(()
                => _nameBadBeer.ValidateName());

            Assert.ThrowsException<ArgumentNullException>(()
                => _nameNullBeer.ValidateName());
        }
        [TestMethod()]
        public void ValidateAlcoholByVolumeTest()
        {
            _validBeer.ValidateAlcoholByVolume();

            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => _abvBadBeerBelow.ValidateAlcoholByVolume());

            Assert.ThrowsException<ArgumentOutOfRangeException>(()
                => _abvBadBeerAbove.ValidateAlcoholByVolume());
        }
        [TestMethod()]
        public void ValidateTest()
        {
            _validBeer.Validate();
        }
    }
}