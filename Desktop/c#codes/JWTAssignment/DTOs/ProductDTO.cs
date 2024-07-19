using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAssignment.DTOs
{
    public class ProductDTO
    {
        public int Id{get; set;}
        public string Name {get; set;}
        public string QuantityAvailable {get; set;}
        public string Description {get; set;}
        public double Price {get; set;}
    }
}