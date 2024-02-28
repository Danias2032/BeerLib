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
    public class BeerRepositoryTests
    {
        private readonly Beer _badBeer = new() { Id = null, Name = null, Abv = 100.00};
        private BeerRepository _beerRepo = new();

        [TestMethod()]
        public void GetBeerTest()
        {
            IEnumerable<Beer> beers = _beerRepo.GetBeer();
            Assert.AreEqual(5, beers.Count());
            Assert.IsNotNull(beers);

            IEnumerable<Beer> beers1 = _beerRepo.GetBeer(sortBy: "id");
            Assert.AreEqual(0, beers1.First().Id);
            IEnumerable<Beer> beers2 = _beerRepo.GetBeer(sortBy: "name");
            Assert.AreEqual("Ben", beers2.First().Name);
            IEnumerable<Beer> beers3 = _beerRepo.GetBeer(sortBy: "abv");
            Assert.AreEqual(4, beers3.First().Abv);
        }

        [TestMethod()]
        public void GetBeerByIdTest()
        {
            Assert.IsNotNull(_beerRepo.GetBeerById(2));
            Assert.IsNull(_beerRepo.GetBeerById(100));
        }

        [TestMethod()]
        public void AddABeerTest()
        {
            Beer b = new() { Id = 0, Name = "Klaus Beer", Abv = 5.45 };
            Assert.AreEqual(5, _beerRepo.AddABeer(b).Id);
            Assert.AreEqual(6, _beerRepo.GetBeer().Count());
            Assert.ThrowsException<ArgumentNullException>(() => _beerRepo.AddABeer(_badBeer));
        }

        [TestMethod()]
        public void DeleteBeerTest()
        {
            Assert.IsNull(_beerRepo.DeleteBeer(200));
            Assert.AreEqual(1, _beerRepo.DeleteBeer(1)?.Id);
            Assert.AreEqual(4, _beerRepo.GetBeer().Count());
        }

        [TestMethod()]
        public void UpdateBeerTest()
        {
            Assert.AreEqual(5, _beerRepo.GetBeer().Count());
            Beer b = new() { Id = 0, Name = "Klaus Beer", Abv = 5.45 };
            Assert.IsNull(_beerRepo.UpdateBeer(6, b));
            Assert.AreEqual(0, _beerRepo.UpdateBeer(0, b)?.Id);
            Assert.AreEqual(5, _beerRepo.GetBeer().Count());

            Assert.ThrowsException<ArgumentNullException>(() => _beerRepo.UpdateBeer(0, _badBeer));
        }
    }
}