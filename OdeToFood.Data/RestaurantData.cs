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
        IEnumerable<Restaurant> GetAll();
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

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }

}
