using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using next_world_api.Model;
using next_world_api.Repository;
using next_world_api.Repository.Interface;

namespace next_world_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HqController : ControllerBase
    {
        private readonly IHqRepository _hqRepository;

        public HqController(IHqRepository hqRepository)
        {
            _hqRepository = hqRepository;
        }

        [HttpGet]
        [Route("ListAllHqs")]
        public async Task<IActionResult> GetAll()
        {
            var hq = await _hqRepository.GetAllHqs();
            return Ok(hq);
        }

        [HttpGet]
        [Route("ListHqById")]
        public async Task<IActionResult> GetById(int id)
        {
            var hq = await _hqRepository.GetHqById(id);
            return Ok(hq);
        }

        [HttpGet]
        [Route("ListHqByNome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var hq = await _hqRepository.GetHqByNome(nome);
            return Ok(hq);
        }

        [HttpGet]
        [Route("ListHqByStatus")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var hq = await _hqRepository.GetHqByStatus(status);
            return Ok(hq);
        }

        [HttpGet]
        [Route("ListHqByAutor")]
        public async Task<IActionResult> GetByAutor(string autor)
        {
            var hq = await _hqRepository.GetHqByAutor(autor);
            return Ok(hq);
        }

        [HttpPost]
        [Route("AddHq")]
        public IActionResult AddHq(Hq newHq)
        {
            _hqRepository.AddHq(newHq);
            return Ok(newHq);
        }

        [HttpPut]
        [Route("UpdateHq")]
        public async Task<IActionResult> UpdateHq(int id, [FromBody] Hq updateHq)
        {
            bool update = await _hqRepository.UpdateHq(id, updateHq);
            if (!update) return NotFound(new { mensage = "Hq não encontrada" });
            return Ok(new { message = "Hq atualizada com sucesso" });
        }

        [HttpDelete]
        [Route("DeleteHq")]
        public async Task<IActionResult> DeleteHq(int id)
        {
            bool delete = await _hqRepository.DeleteHq(id);
            if (!delete) return NotFound(new { mensage = "Conta não encontrada" });
            return Ok(new { message = "Conta Deletada com sucesso" });
        }
    }
}
