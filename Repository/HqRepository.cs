using Microsoft.EntityFrameworkCore;
using next_world_api.Data;
using next_world_api.Model;
using next_world_api.Repository.Interface;

namespace next_world_api.Repository
{
    public class HqRepository : IHqRepository
    {
        private readonly ComicsContext _context;

        public HqRepository(ComicsContext context)
        {
            _context = context;
        }

        public async Task<List<Hq>> GetAllHqs()
        {
            return await _context.Hq.ToListAsync();
        }

        public async Task<Hq> GetHqById(int id)
        {
            return await _context.Hq.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Hq> GetHqByNome(string nome)
        {
            return await _context.Hq.FirstOrDefaultAsync(x => x.nome == nome);
        }

        public async Task<List<Hq>> GetHqByStatus(string status)
        {
            return await _context.Hq.Where(x => x.status == status).ToListAsync();
        }

        public async Task<List<Hq>> GetHqByAutor(string autor)
        {
            return await _context.Hq.Where(x => x.autor == autor).ToListAsync();
        }

        public void AddHq(Hq hq)
        {
            _context.Hq.Add(hq);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateHq(int id, Hq updateHq)
        {
            var hqExistente = await GetHqById(id);
            if (hqExistente == null)
                return false;

            hqExistente.resumo = updateHq.resumo;
            hqExistente.generos = updateHq.generos;
            hqExistente.capa = updateHq.capa;
            hqExistente.banner = updateHq.banner;

            _context.Hq.Update(hqExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteHq(int id)
        {
            var hq = await GetHqById(id);
            _context.Hq.Remove(hq);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
