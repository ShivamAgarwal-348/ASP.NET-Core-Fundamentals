using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface RestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetByID(int id);
    }
    public class InMemoryRestaurantData : RestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Cuisine = CuisineType.Indian, Location = "Aa", Name = "Ba"},
                new Restaurant{Id = 2, Cuisine = CuisineType.Mexican, Location = "Ab", Name = "Bb"},
                new Restaurant{Id = 3, Cuisine = CuisineType.Indian, Location = "Ac", Name = "Bc"},
                new Restaurant{Id = 4, Cuisine = CuisineType.Italian, Location = "Ad", Name = "Bd"},
            };

        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public Restaurant GetByID(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
    }

}
