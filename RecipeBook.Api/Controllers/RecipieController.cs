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
        public async Task<IActionResult> GetRecipies(){

              return Ok(recipieDbContext.Recipies.ToListAsync());

            }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipieById(Guid id){

            var result =  recipieDbContext.Recipies.Where(x=>x.RecipieId==id);

            return Ok(result);

            
        }

        [HttpPost]

        public async Task<IActionResult> AddRecipies(AddRecipieModel addnewRecipie){

            var _addnewRecipie = new Recipie(){
                RecipieId = Guid.NewGuid(),
                RecipieTitle = addnewRecipie.RecipieTitle,
                RecipieDescription = addnewRecipie.RecipieDescription,
                RecipiePhotoName = addnewRecipie.RecipiePhotoName
            };
            await recipieDbContext.Recipies.AddAsync(_addnewRecipie);
            await recipieDbContext.SaveChangesAsync();

            // return new JsonResult("Added Successfully");
            // return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            return Ok(_addnewRecipie);

        }

        [HttpDelete("{id}")]
        public JsonResult DeleteById(Guid id){
            var _recipie = recipieDbContext.Recipies.Where(x=>x.RecipieId==id).FirstOrDefault();

            recipieDbContext.Recipies.Remove(_recipie);
            recipieDbContext.SaveChanges();

            return new JsonResult("Deleted Successfully");

            
        }

        [HttpPut("{id}")]
        public JsonResult UpdateRecipie(Guid id,UpdateRecipie updateRecipie){
            var _updatedRecipie = new Recipie(){
                RecipieId = id,
                RecipieTitle = updateRecipie.RecipieTitle,
                RecipieDescription = updateRecipie.RecipieDescription,
                RecipiePhotoName = updateRecipie.RecipiePhotoName
            };

            recipieDbContext.Recipies.Remove(_updatedRecipie);
            recipieDbContext.SaveChanges();

            return new JsonResult(_updatedRecipie);

            
        }
    }
}