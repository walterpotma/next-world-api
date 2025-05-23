using next_world_api.Model;

namespace next_world_api.Repository.Interface
{
    public interface IHqRepository
    {
        public Task<List<Hq>> GetAllHqs();
        Task<Hq> GetHqById(int id);
        Task<Hq> GetHqByNome(string nome);
        Task<List<Hq>> GetHqByStatus(string status);
        Task<List<Hq>> GetHqByAutor(string autor);
        void AddHq(Hq newHq);
        Task<bool> UpdateHq(int id, Hq updateHq);
        Task<bool> DeleteHq(int id);
    }
}
