using Microsoft.AspNetCore.Mvc;
using RecipeBook.Api.Data;
using RecipieBook.Api.Models;

namespace RecipeBook.Api.Controllers
{
  [Route("[controller]")]
    public class RecipieController : Controller
    {
        
       private readonly RecipieDbContext recipieDbContext;

    public RecipieController(RecipieDbContext recipieDbContext)
    {
      this.recipieDbContext = recipieDbContext;
    }

    public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public JsonResult GetRecipies(){

            var result = recipieDbContext.Recipies.ToList();

            return new JsonResult(result);

            
        }

        [HttpPost]

        public JsonResult AddRecipies(AddRecipieModel addRecipieModel){

            var newRecipie = new Recipie()
            {
                
                RecipieId = Guid.NewGuid(),
                RecipieTitle = addRecipieModel.RecipieTitle,
                RecipieDescription = addRecipieModel.RecipieDescription,
                RecipiePhotoName = addRecipieModel.RecipiePhotoName
            };
            recipieDbContext.Recipies.Add(newRecipie);
            recipieDbContext.SaveChanges();

            return new JsonResult("Added Successfully");

        }
    }
}