using OdeToFood.Core;

namespace OdeToFood.Data
{
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

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit() 
        { 
            return 0; 
        }
    }

}
