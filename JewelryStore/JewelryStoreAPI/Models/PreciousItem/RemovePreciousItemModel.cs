using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.PreciousItem
{
    public class RemovePreciousItemModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
