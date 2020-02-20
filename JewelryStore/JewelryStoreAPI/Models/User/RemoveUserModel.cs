using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.User
{
    public class RemoveUserModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
