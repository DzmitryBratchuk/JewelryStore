using System;

namespace JewelryStoreAPI.Core.Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
