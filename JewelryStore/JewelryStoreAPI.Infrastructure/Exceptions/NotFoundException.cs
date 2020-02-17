namespace JewelryStoreAPI.Infrastructure.Exceptions
{
    public class NotFoundException : BaseJewelryStoreException
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
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
