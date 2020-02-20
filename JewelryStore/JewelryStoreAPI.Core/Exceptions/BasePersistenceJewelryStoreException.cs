using System;

namespace JewelryStoreAPI.Core.Exceptions
{
    public class BasePersistenceJewelryStoreException : Exception
    {
        public BasePersistenceJewelryStoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
