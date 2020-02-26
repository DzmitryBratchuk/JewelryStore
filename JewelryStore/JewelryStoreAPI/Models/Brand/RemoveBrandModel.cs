using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.Brand
{
    public class RemoveBrandModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
