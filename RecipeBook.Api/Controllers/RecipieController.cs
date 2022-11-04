using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Api.Data;
using RecipeBook.Api.Models;
using RecipieBook.Api.Models;
using System.Text.Json;

namespace RecipeBook.Api.Controllers
{
    [ApiController]
  [Route("[controller]")]
    public class RecipieController : Controller
    {
        
       private readonly RecipieDbContext recipieDbContext;

        public RecipieController(RecipieDbContext recipieDbContext)
        {
        this.recipieDbContext = recipieDbContext;
        }

   

        
        

        [HttpGet]
        public ActionResult<Recipie> GetRecipies(){

              return new JsonResult(recipieDbContext.Recipies.ToList());

            }

        [HttpGet("{id}")]
        public ActionResult GetRecipieById(Guid id){

            var result =  recipieDbContext.Recipies.Where(x=>x.RecipieId==id);

            return Ok(result);

            
        }

        [HttpPost]

        public ActionResult<Recipie> AddRecipies(AddRecipieModel addnewRecipie){

            var _addnewRecipie = new Recipie(){
                RecipieId = Guid.NewGuid(),
                RecipieTitle = addnewRecipie.RecipieTitle,
                RecipieDescription = addnewRecipie.RecipieDescription,
                RecipiePhotoName = addnewRecipie.RecipiePhotoName
            };
            recipieDbContext.Recipies.Add(_addnewRecipie);
            recipieDbContext.SaveChanges();

            // return new JsonResult("Added Successfully");
            // return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            return Ok(_addnewRecipie);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(Guid id){
            var _recipie = recipieDbContext.Recipies.Where(x=>x.RecipieId==id).FirstOrDefault();

            recipieDbContext.Recipies.Remove(_recipie);
            recipieDbContext.SaveChanges();

            return new JsonResult("Deleted Successfully");

            
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRecipie(Guid id,UpdateRecipie updateRecipie){
            var _updatedRecipie = recipieDbContext.Recipies.Where(x=>x.RecipieId==id).FirstOrDefault();

            _updatedRecipie.RecipieTitle = updateRecipie.RecipieTitle;
            _updatedRecipie.RecipieDescription = updateRecipie.RecipieDescription;
            _updatedRecipie.RecipiePhotoName = updateRecipie.RecipiePhotoName;

            
            recipieDbContext.SaveChanges();

            return new JsonResult(_updatedRecipie);

            
        }
    }
}