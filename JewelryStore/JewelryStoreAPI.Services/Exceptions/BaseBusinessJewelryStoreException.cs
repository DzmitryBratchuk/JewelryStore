using System;

namespace JewelryStoreAPI.Services.Exceptions
{
    public class BaseBusinessJewelryStoreException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public BaseBusinessJewelryStoreException(string name, int key, ErrorCode errorCode)
            : this($"{name} with key {key} was not found.", errorCode)
        {
        }

        public BaseBusinessJewelryStoreException(string name, string key, ErrorCode errorCode)
            : this($"{name} with key {key} was not found.", errorCode)
        {
        }

        public BaseBusinessJewelryStoreException(string message, ErrorCode errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
