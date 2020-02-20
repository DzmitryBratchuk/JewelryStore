using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.Role
{
    public class RemoveRoleModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
