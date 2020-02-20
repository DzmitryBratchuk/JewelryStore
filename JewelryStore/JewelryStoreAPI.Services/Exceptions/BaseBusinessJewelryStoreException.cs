using System;

namespace JewelryStoreAPI.Services.Exceptions
{
    public class BaseBusinessJewelryStoreException : Exception
    {
        public BaseBusinessJewelryStoreException(string message) : base(message)
        {
        }
    }
}
