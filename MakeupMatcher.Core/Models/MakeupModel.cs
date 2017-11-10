using System;

namespace MakeupMatcher.Core.Models
{
    public class MakeupModel
    {
        
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public ProductModel[] Products { get; set; }
    }
}