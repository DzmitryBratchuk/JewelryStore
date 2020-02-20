using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.PreciousItemType
{
    public class RemovePreciousItemTypeModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
