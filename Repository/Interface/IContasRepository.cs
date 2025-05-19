using next_world_api.Model;

namespace next_world_api.Repository.Interface
{
    public interface IContasRepository
    {
        Task<List<Contas>> GetAllContas();
        Task<Contas> GetContasById(int id);
        Task<Contas> Login(int id, string email, string senha);
        void AddConta(Contas newConta);
        Task<bool> UpdateConta(int id, Contas atualizarConta);
        Task<bool> DeleteConta(int id);
    }
}
