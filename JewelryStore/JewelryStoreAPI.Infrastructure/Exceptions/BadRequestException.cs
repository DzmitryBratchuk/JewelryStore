namespace JewelryStoreAPI.Infrastructure.Exceptions
{
    public class BadRequestException : BaseJewelryStoreException
    {
        public BadRequestException(string message)
            : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
