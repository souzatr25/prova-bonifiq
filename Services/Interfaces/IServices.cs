namespace ProvaPub.Services.Interfaces
{
    public interface IServices<T> where T : class
    {
        T ListEntity(int page);
    }
}
