using System;

namespace JewelryStoreAPI.Services.Exceptions
{
    public class BaseBusinessJewelryStoreException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public BaseBusinessJewelryStoreException(string message) : base(message)
        {
        }
    }
}
