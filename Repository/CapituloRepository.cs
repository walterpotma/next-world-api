using Microsoft.EntityFrameworkCore;
using next_world_api.Data;
using next_world_api.Model;
using next_world_api.Repository.Interface;

namespace next_world_api.Repository
{
    public class CapituloRepository : ICapituloRepository
    {
        private readonly ComicsContext _context;

        public CapituloRepository(ComicsContext context)
        {
            _context = context;
        }

        public async Task<List<Capitulos>> GetAllCaps()
        {
            return await _context.Caps.ToListAsync();
        }

        public async Task<List<Capitulos>> GetRecentsCaps()
        {
            return await _context.Caps
                .OrderByDescending(c => c.id)
                .Take(100)
                .ToListAsync();
        }


        public async Task<Capitulos> GetCapById(int id)
        {
            return await _context.Caps.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Capitulos>> GetCapByIdHq(int hq_id)
        {
            return await _context.Caps.Where(x => x.hq_id == hq_id).ToListAsync();
        }

        public void AddCap(Capitulos newCap)
        {
            _context.Caps.Add(newCap);
            _context.SaveChanges();
        }

        /*public async Task<bool> UpdateCap(int id, Capitulos updateCap)
        {
            var capExistente = await GetCapById(id);
            if (capExistente == null)
                return false;

            capExistente.paginas = updateCap.paginas;

            _context.Caps.Update(capExistente);
            await _context.SaveChangesAsync();
            return true;
        }*/

        public async Task<bool> DeleteCap(int id)
        {
            var cap = await GetCapById(id);
            _context.Caps.Remove(cap);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
