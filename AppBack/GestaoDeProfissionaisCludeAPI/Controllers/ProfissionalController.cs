using GestaoDeProfissionaisCludeAPI.Interfaces;
using GestaoDeProfissionaisDomain.Model;
using GestaoDeProfissionaisPersistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProfissionaisCludeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private IProfissionalService _profissionalService;
        public ProfissionalController(IProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var profissionais = await _profissionalService.GetProfissionais();
                if (profissionais is null) return NotFound("Nenhum Profissional Encontrado.");

                return Ok(profissionais);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar os profissionais. Erro: 500");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var profissional = await _profissionalService.GetProfissionalById(id);
                if (profissional is null) return NotFound("Nenhum Profissional Encontrado.");

                return Ok(profissional);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar o profissional. Erro: 500");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Profissional novoProfissional)
        {
            try
            {
                var profissional = await _profissionalService.AddProfissional(novoProfissional);
                if (profissional is null) return BadRequest("Não foi possível adicionar um profissional.");

                return Ok(profissional);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Erro ao tentar adicionar o profissional. Erro: {0}", ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Profissional alteracaoProfissional)
        {
            try
            {
                var profissional = await _profissionalService.UpdateProfissional(id,alteracaoProfissional);
                if (profissional is null) return BadRequest("Não foi possível alterar os dados de um profissional.");

                return Ok(profissional);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Erro ao tentar adicionar o profissional. Erro: {0}", ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await _profissionalService.DeleteProfissional(id))
                return Ok("Profissional removido com sucesso.");
                else
                    return BadRequest("Profissional não pode ser removido");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar remover o profissional. Erro: 500");
            }
        }
    }
}
