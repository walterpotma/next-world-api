using next_world_api.Model;

namespace next_world_api.Repository.Interface
{
    public interface ICapituloRepository
    {
        public Task<List<Capitulos>> GetAllCaps();
        public Task<List<Capitulos>> GetRecentsCaps();
        Task<Capitulos> GetCapById(int id);
        public Task<List<Capitulos>> GetCapByIdHq(int hq_id);
        void AddCap(Capitulos newCap);
        //Task<bool> UpdateCap(int id, Capitulos updateCap);
        Task<bool> DeleteCap(int id);
    }
}
