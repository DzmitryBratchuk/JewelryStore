using System;
using System.Collections.Generic;
using System.Text;

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
