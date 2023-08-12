namespace Thiesen.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}