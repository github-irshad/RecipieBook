using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBook.Api.Data;
using RecipeBook.Api.Interfaces;
using RecipieBook.Api.Models;

namespace RecipeBook.Api.Repositories
{
  public class RecipiesRepo : IRecipies
  {

    private readonly RecipieDbContext recipieDbContext;

    public RecipiesRepo(RecipieDbContext recipieDbContext)
    {
      this.recipieDbContext = recipieDbContext;
    }

    // public RecipiesRepo(RecipieDbContext recipieDbContext)
    // {
    //   this.recipieDbContext = recipieDbContext;
    // }

    public void AddRecipie(Recipie recipie)
    {
      recipieDbContext.Recipies.Add(recipie);
    }

    public void DeleteRecipie(Recipie recipie)
    {
      throw new NotImplementedException();
    }

    public void DeleteRecipie(int id)
    {
      throw new NotImplementedException();
    }

    public List<Recipie> GetRecipies()
    {
      throw new NotImplementedException();
    }

    public void UpdateRecipie(int id)
    {
      throw new NotImplementedException();
    }

    public void UpdateRecipie(Recipie recipie)
    {
      throw new NotImplementedException();
    }
  }
}