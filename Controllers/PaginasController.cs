using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using next_world_api.Model;
using next_world_api.Repository.Interface;

namespace next_world_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginasController : ControllerBase
    {
        private readonly IPaginaRepository _pageRepository;

        public PaginasController(IPaginaRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        [HttpGet]
        [Route("ListPageByCapId")]
        public async Task<IActionResult> GetPages(int id)
        {
            var pages = await _pageRepository.GetPagesByIdCap(id);
            return Ok(pages);
        }

        [HttpPost]
        [Route("AddPage")]
        public IActionResult AddPage(Paginas newPage)
        {
            _pageRepository.AddPage(newPage);
            return Ok(newPage);
        }
    }
}
