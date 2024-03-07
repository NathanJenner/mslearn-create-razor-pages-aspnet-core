using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service; //creating an instance of PizzaList called _service
        public IList<Pizza> PizzaList { get; set; } = default!; //a list of Pizza types called PizzaList

        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;
        //The BindProperty attribute is used to bind the NewPizza property to the Razor page.
        //When an HTTP POST request is made, the NewPizza property will be populated with the user's input.




        public PizzaListModel(PizzaService service) //constructor taking a PizzaService argument 
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas(); //PizzaList list calls the PizzaService.cs object _service and runs the GetPizza() method.
        }

        /*
 
 * A private readonly PizzaService named _service is created. This variable will hold a reference to a PizzaService object.
        * The readonly keyword indicates that the value of the _service variable can't be changed after it's set in the constructor.

 * A PizzaList property is defined to hold the list of pizzas.
        * The IList<Pizza> type indicates that the PizzaList property will hold a list of Pizza objects.
        * PizzaList is initialized to default! to indicate to the compiler that it will be initialized later, so null safety checks aren't required.

 * The constructor accepts a PizzaService object.
        * The PizzaService object is provided by dependency injection.

 * An OnGet method is defined to retrieve the list of pizzas from the PizzaService object and store it in the PizzaList property.

 */

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }
            _service.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }

/*The ModelState.IsValid property is used to determine if the user's input is valid.
        The validation rules are inferred from attributes (such as Required and Range) on the Pizza class in Models\Pizza.cs.
        If the user's input is invalid, the Page method is called to re-render the page.

The NewPizza property is used to add a new pizza to the _service object.
The RedirectToAction method is used to redirect the user to the Get page handler, which will re-render the page with the updated list of pizzas.
*/






    }
}


