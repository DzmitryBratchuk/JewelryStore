namespace JewelryStoreAPI.Services.Exceptions
{
    public class BadRequestException : BaseBusinessJewelryStoreException
    {
        public BadRequestException(string message)
            : base(message)
        {
            ErrorCode = ErrorCode.BadRequest;
        }
    }
}
