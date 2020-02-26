using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.Bijouterie
{
    public class RemoveBijouterieModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
