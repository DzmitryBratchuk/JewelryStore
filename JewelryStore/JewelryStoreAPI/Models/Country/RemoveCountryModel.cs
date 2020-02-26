using Microsoft.AspNetCore.Mvc;

namespace JewelryStoreAPI.Models.Country
{
    public class RemoveCountryModel
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
