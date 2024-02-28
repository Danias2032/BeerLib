using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLib
{
    public class BeerRepository
    {
        private int _count = 0;
        private List<Beer> _Beers = new();

        public BeerRepository()
        {
            _Beers.Add(new Beer() { Id = _count++, Name = "Ben", Abv = 4 });
            _Beers.Add(new Beer() { Id = _count++, Name = "Jakobsen", Abv = 6 });
            _Beers.Add(new Beer() { Id = _count++, Name = "Tullamore", Abv = 5 });
            _Beers.Add(new Beer() { Id = _count++, Name = "Big", Abv = 7 });
            _Beers.Add(new Beer() { Id = _count++, Name = "Joe's", Abv = 40 });
        }

        public IEnumerable<Beer> GetBeer(double? abv = null, string? sortBy = null)
        {
            IEnumerable<Beer> beers = new List<Beer>(_Beers);
            if (abv < 0 && abv > 67)
            {
                beers = beers.Where(b => b.Abv == abv);
            }
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "id":
                        beers = beers.OrderBy(b => b.Id); 
                        break;
                    case "name":
                        beers = beers.OrderBy(b => b.Name);
                        break;
                    case "abv":
                        beers = beers.OrderBy(b => b.Abv);
                        break;
                }
            }
            return beers;
        }

        public Beer? GetBeerById(int id)
        {
            return _Beers.Find(beer => beer.Id == id);
        }

        public Beer AddABeer(Beer beer)
        {
            beer.Validate();
            beer.Id = _count++;
            _Beers.Add(beer);
            return beer;
        }

        public Beer? DeleteBeer(int id)
        {
            Beer? beer = GetBeerById(id);
            if (beer == null)
            {
                return null;
            }
            _Beers.Remove(beer);
            return beer;
        }

        public Beer? UpdateBeer(int id, Beer beer)
        {
            beer.Validate();
            Beer? beers = GetBeerById(id);
            if (beers == null)
            {
                return null;
            }
            beers.Id = beer.Id;
            beers.Name = beer.Name;
            beers.Abv = beer.Abv;
            return beers;
        }
    }
}
