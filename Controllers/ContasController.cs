using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using next_world_api.Model;
using next_world_api.Repository.Interface;
using next_world_api.Service;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("ListContaById")]
        public async Task<IActionResult> GetById(int id)
        {
            var conta = await _contasRepository.GetContasById(id);
            return Ok(conta);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> login([FromBody] Contas login)
        {
            var conta = await _contasRepository.Login(login.id, login.email, login.senha);
            if (conta != null)
            {

                var token = TokenService.GenerateToken(conta);
                return Ok(new { token, contaId = conta.id });
            }
            return Unauthorized("Email ou senha Incorretos");
        }

        [HttpPost]
        [Route("AddConta")]
        public IActionResult AddConta(Contas newConta)
        {
            _contasRepository.AddConta(newConta);
            return Ok(newConta);
        }

        [HttpPut]
        [Route("UpdateConta")]
        public async Task<IActionResult> UpdateConta(int id, [FromBody] Contas conta)
        {
            bool update = await _contasRepository.UpdateConta(id, conta);
            if(!update) return NotFound(new {mensage = "Conta não encontrada"});
            return Ok(new { message = "Conta atualizada com sucesso"});
        }

        [HttpDelete]
        [Route("DeleteConta")]
        public async Task<IActionResult> DeleteConta(int id)
        {
            bool delete = await _contasRepository.DeleteConta(id);
            if (!delete) return NotFound(new { mensage = "Conta não encontrada" });
            return Ok(new { message = "Conta Deletada com sucesso"});
        }
    }
}
