namespace Common
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}