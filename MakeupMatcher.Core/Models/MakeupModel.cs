using System;
using MakeupMatcher.Core.Enum;

namespace MakeupMatcher.Core.Models
{
    public class MakeupModel
    {
        
        public int ColorId { get; set; }
        public Colors ColorName { get; set; }
        public ProductModel[] Products { get; set; }
    }
}