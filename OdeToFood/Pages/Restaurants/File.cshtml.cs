using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class FileModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly RestaurantData restaurantData;

        public string Message { get; set;}
        [BindProperty(SupportsGet = true)]
        public string SearchTerm {  get; set;}
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public FileModel(IConfiguration config, RestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {

            Message = config["HelloMessage"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
