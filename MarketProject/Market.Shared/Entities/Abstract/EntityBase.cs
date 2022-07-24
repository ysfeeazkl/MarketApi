namespace MarketProject.Shared.Entities.Abstract
{
    public abstract class EntityBase<T> where T : struct
    {
        public virtual T Id { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual T CreatedByCustomerId { get; set; }
        public virtual T ModifiedByCustomerId { get; set; }
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
