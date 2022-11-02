using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieBook.Api.Models
{
    public class Recipie
    {
        public int RecipieId {get; set;}
        public string RecipieTitle{get; set;}
        public string RecipieDescription {get; set;}
        public string RecipiePhotoName{get; set;}

    }
}