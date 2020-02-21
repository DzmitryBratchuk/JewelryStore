using System;

namespace JewelryStoreAPI.Core.Exceptions
{
    public class EntityValidationException : BasePersistenceJewelryStoreException
    {
        public EntityValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
