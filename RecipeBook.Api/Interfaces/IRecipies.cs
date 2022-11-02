using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipieBook.Api.Models;

namespace RecipeBook.Api.Interfaces
{
    public interface IRecipies
    {
        public List<Recipie> GetRecipies();
        public void AddRecipie(Recipie recipie);
        public void UpdateRecipie(Recipie recipie);
        public void DeleteRecipie(int id);  
        
    }
}