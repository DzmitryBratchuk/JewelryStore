using System;

namespace JewelryStoreAPI.Infrastructure.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
