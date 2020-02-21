using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Services.Exceptions
{
    public class ConflictException : BaseBusinessJewelryStoreException
    {
        public ConflictException(string message) : base(message)
        {
            ErrorCode = ErrorCode.Conflict;
        }
    }
}
