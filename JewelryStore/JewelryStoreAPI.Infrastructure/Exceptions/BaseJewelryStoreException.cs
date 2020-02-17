using System;
using System.Net;

namespace JewelryStoreAPI.Infrastructure.Exceptions
{
    public class BaseJewelryStoreException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public BaseJewelryStoreException(string message) : base(message)
        {
        }
    }
}
