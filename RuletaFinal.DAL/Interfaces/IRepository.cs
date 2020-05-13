namespace RuletaFinal.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void SetObjectAsync(string id, T objectToCache);

        T GetObjectAsync(string id);
    }
}
