namespace JewelryStoreAPI.Domain.Entities
{
    public class PreciousItem : Product
    {
        public int PreciousItemTypeId { get; set; }

        public virtual PreciousItemType PreciousItemType { get; set; }
    }
}
