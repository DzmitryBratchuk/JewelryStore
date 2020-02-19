using Castle.DynamicProxy;
using JewelryStoreAPI.Core.Exceptions;
using System;

namespace JewelryStoreAPI.Common
{
    public class PersistenceLayerErrorHandler : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                throw new EntityValidationException("Please check your input data and try again.", ex);
            }
        }
    }
}
