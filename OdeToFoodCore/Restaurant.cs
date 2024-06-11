using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }
}
