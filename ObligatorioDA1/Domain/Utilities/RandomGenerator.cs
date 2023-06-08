using System;

namespace Domain.Utilities
{
    public class RandomGenerator
    {
        
        public static Random RandomInstance { get; set; } = new Random();
    }
}