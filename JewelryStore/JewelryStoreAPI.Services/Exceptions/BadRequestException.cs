namespace JewelryStoreAPI.Services.Exceptions
{
    public class BadRequestException : BaseJewelryStoreException
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
