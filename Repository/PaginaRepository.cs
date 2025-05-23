using Microsoft.EntityFrameworkCore;
using next_world_api.Data;
using next_world_api.Model;
using next_world_api.Repository.Interface;

namespace next_world_api.Repository
{
    public class PaginaRepository : IPaginaRepository
    {
        private readonly ComicsContext _context;

        public PaginaRepository(ComicsContext context)
        {
            _context = context;
        }

        public async Task<List<Paginas>> GetPagesByIdCap(int capitulo_id)
        {
            return await _context.Paginas
                .Where(x => x.capitulo_id == capitulo_id )
                .OrderBy(c => c.numero_page)
                .ToListAsync();
        }
        public void AddPage(Paginas newPage)
        {
            _context.Paginas.Add(newPage);
            _context.SaveChanges();
        }
    }
}
