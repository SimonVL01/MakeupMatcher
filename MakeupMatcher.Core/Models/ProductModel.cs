using System;
using MakeupMatcher.Core.Enum;

namespace MakeupMatcher.Core.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public Colors ProductColor { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public double ProductPrice { get; set; }
        public bool Favorite { get; set; } = false;
    }
}