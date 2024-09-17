namespace Koton.Order.Domain.Entities.Abstract
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
