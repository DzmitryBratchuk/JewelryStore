using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.Watch
{
    public class RemoveWatchModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
