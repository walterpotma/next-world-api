using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using next_world_api.Repository.Interface;

namespace next_world_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContasRepository _contasRepository;
        
        public ContasController(IContasRepository contasRepository)
        {
            _contasRepository = contasRepository;
        }

        [HttpGet]
        [Route("ListAllContas")]
        public async Task<IActionResult> GetAll()
        {
            var contas = await _contasRepository.GetAllContas();
            return Ok(contas);
        }
    }
}
