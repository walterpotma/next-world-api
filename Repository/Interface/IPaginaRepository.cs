using next_world_api.Model;

namespace next_world_api.Repository.Interface
{
    public interface IPaginaRepository
    {
        Task<List<Paginas>> GetPagesByIdCap(int id);
        public void AddPage (Paginas newPage);
    }
}
