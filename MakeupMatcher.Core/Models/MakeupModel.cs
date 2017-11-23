using System;
using MakeupMatcher.Core.Enum;

namespace MakeupMatcher.Core.Models
{
    public class MakeupModel
    {
        
        public int ColorId { get; set; }
        public string User { get; set; }
        public double RedValue { get; set; }
        public double GreenValue { get; set; }
        public double BlueValue { get; set; }
        public Colors ColorName { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}