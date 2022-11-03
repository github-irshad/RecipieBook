using Microsoft.AspNetCore.Mvc;
using RecipeBook.Api.Data;
using RecipieBook.Api.Models;
using System.Text.Json;

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
        [HttpGet("{id}")]
        public JsonResult GetRecipieById(Guid id){

            var result = recipieDbContext.Recipies.Where(x=>x.RecipieId==id);

            return new JsonResult(result);

            
        }

        [HttpPost]

        public ActionResult<Recipie> AddRecipies(Recipie addnewRecipie){

            // var newRecipie = JsonSerializer.Serialize( new Recipie()
            // {
                
                
            //     RecipieTitle = addnewRecipie.RecipieTitle,
            //     RecipieDescription = addnewRecipie.RecipieDescription,
            //     RecipiePhotoName = addnewRecipie.RecipiePhotoName
            // }
            // );
            
            // recipieDbContext.Recipies.Add(JsonSerializer.Deserialize<Recipie>(newRecipie));
            recipieDbContext.Recipies.Add(addnewRecipie);
            recipieDbContext.SaveChanges();

            // return new JsonResult("Added Successfully");
            // return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            return new JsonResult(addnewRecipie);

        }

        [HttpDelete("{id}")]
        public JsonResult DeleteById(Guid id){
            var _recipie = recipieDbContext.Recipies.Where(x=>x.RecipieId==id).FirstOrDefault();

            recipieDbContext.Recipies.Remove(_recipie);
            recipieDbContext.SaveChanges();

            return new JsonResult("Deleted Successfully");

            
        }
    }
}