using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using next_world_api.Model;
using next_world_api.Repository.Interface;

namespace next_world_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitulosController : ControllerBase
    {
        private readonly ICapituloRepository _capRepository;

        public CapitulosController(ICapituloRepository capRepository)
        {
            _capRepository = capRepository;
        }

        [HttpGet]
        [Route("ListAllCaps")]
        public async Task<IActionResult> GetAll()
        {
            var cap = await _capRepository.GetAllCaps();
            return Ok(cap);
        }

        [HttpGet]
        [Route("ListRecentsCaps")]
        public async Task<IActionResult> GetRecents()
        {
            var cap = await _capRepository.GetRecentsCaps();
            return Ok(cap);
        }

        [HttpGet]
        [Route("ListViewCaps")]
        public async Task<IActionResult> GetViewCaps()
        {
            var cap = await _capRepository.GetViewCaps();
            return Ok(cap);
        }

        [HttpGet]
        [Route("ListTopCaps")]
        public async Task<IActionResult> GetTopCaps()
        {
            var cap = await _capRepository.GetTopCaps();
            return Ok(cap);
        }

        [HttpGet]
        [Route("ListCapById")]
        public async Task<IActionResult> GetById(int id)
        {
            var cap = await _capRepository.GetCapById(id);
            return Ok(cap);
        }

        [HttpGet]
        [Route("ListCapByIdHq")]
        public async Task<IActionResult> GetByNome(int hq_id)
        {
            var cap = await _capRepository.GetCapByIdHq(hq_id);
            return Ok(cap);
        }

        [HttpPost]
        [Route("AddCap")]
        public IActionResult AddCap(Capitulos newCap)
        {
            _capRepository.AddCap(newCap);
            return Ok(newCap);
        }

        /*[HttpPut]
        [Route("UpdateHq")]
        public async Task<IActionResult> UpdateHq(int id, [FromBody] Hq updateHq)
        {
            bool update = await _hqRepository.UpdateHq(id, updateHq);
            if (!update) return NotFound(new { mensage = "Hq não encontrada" });
            return Ok(new { message = "Hq atualizada com sucesso" });
        }*/

        [HttpDelete]
        [Route("DeleteCap")]
        public async Task<IActionResult> DeleteCap(int id)
        {
            bool delete = await _capRepository.DeleteCap(id);
            if (!delete) return NotFound(new { mensage = "Cap não encontrada" });
            return Ok(new { message = "Cap Deletada com sucesso" });
        }
    }
}
