using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;

namespace JewelryStoreAPI.Core.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(JewelryStoredbContext context) : base(context)
        {
        }
    }
}
