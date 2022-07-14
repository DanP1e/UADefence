using System;

namespace Economics
{
    public class DoubleBuyException : Exception
    {
        public DoubleBuyException() 
            : base("Before buying, you need to sell the previous item!")
        {
        }
    }
}
