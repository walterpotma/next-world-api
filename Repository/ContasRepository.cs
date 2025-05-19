using Microsoft.EntityFrameworkCore;
using next_world_api.Data;
using next_world_api.Model;
using next_world_api.Repository.Interface;

namespace next_world_api.Repository
{
    public class ContasRepository : IContasRepository
    {
        private readonly ComicsContext _context;

        public ContasRepository(ComicsContext context)
        {
            _context = context;
        }

        public async Task<List<Contas>> GetAllContas()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Contas> GetContasById(int id)
        {
            return await _context.Contas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Contas> Login(int id, string email, string senha)
        {
            return await _context.Contas.FirstOrDefaultAsync(x => x.email == email && x.senha == senha);
        }

        public void AddConta(Contas conta)
        {
            _context.Contas.Add(conta);
            _context.SaveChanges();
        }
        public async Task<bool> UpdateConta(int id, Contas atualizarConta)
        {
            var contaExistente = await GetContasById(id);
            if (contaExistente == null)
                return false;

            contaExistente.nome = atualizarConta.nome;
            contaExistente.email = atualizarConta.email;
            contaExistente.senha = atualizarConta.senha;
            contaExistente.acesso = atualizarConta.acesso;

            _context.Contas.Update(contaExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteConta(int id)
        {
            var conta = await GetContasById(id);
            _context.Contas.Remove(conta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
