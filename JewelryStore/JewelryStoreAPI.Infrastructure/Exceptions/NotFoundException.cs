﻿using System;

namespace JewelryStoreAPI.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity {name} with key {key} was not found.")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
