using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.BijouterieType
{
    public class RemoveBijouterieTypeModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
