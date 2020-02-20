using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.ProductBasket
{
    public class RemoveProductBasketModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
