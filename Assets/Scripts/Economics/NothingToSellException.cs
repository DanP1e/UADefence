using System;

namespace Economics
{
    public class NothingToSellException : Exception
    {
        public NothingToSellException() 
            : base("To sell an item, you must first buy it.")
        {
        }
    }
}
