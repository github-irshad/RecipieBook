using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Api.Models
{
    public class UpdateRecipie
    {
        public string RecipieTitle{get; set;}
        public string RecipieDescription {get; set;}
        public string RecipiePhotoName{get; set;}
    }
}