using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {

        private readonly RestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(RestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetByID(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            if (ModelState.IsValid)
            {
                Restaurant = restaurantData.Update(Restaurant);
                restaurantData.Commit();
                return RedirectToPage("./Detail", new {restaurantId = Restaurant.Id});
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}
