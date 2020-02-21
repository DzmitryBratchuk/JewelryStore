namespace JewelryStoreAPI.Services.Exceptions
{
    public class NotFoundException : BaseBusinessJewelryStoreException
    {
        public NotFoundException(string name, int key)
            : this($"{name} with key {key} was not found.")
        {
        }

        public NotFoundException(string name, string key)
            : this($"{name} with key {key} was not found.")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
            ErrorCode = ErrorCode.NotFound;
        }
    }
}
