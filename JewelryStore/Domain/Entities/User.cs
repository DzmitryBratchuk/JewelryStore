using System.Collections.Generic;

namespace JewelryStoreAPI.Domain.Entities
{
    public class User
    {
        public User()
        {
            Baskets = new HashSet<Basket>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
