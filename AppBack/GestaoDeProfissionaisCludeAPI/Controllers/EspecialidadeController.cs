using GestaoDeProfissionaisCludeAPI.Interfaces;
using GestaoDeProfissionaisDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProfissionaisCludeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeService _especialidadeService;
        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspecialidadeById(int id)
        {
            try
            {
                var especialidade = await _especialidadeService.GetEspecialidadeById(id);
                if (especialidade is null) return NotFound($"Não foi possível encontrar a especialidade: {id}");

                return Ok(especialidade);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao buscar especialidades. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var especialidade = await _especialidadeService.GetEspecialidades();
                if (especialidade is null) return NotFound($"Não há especialidades cadastradas");

                return Ok(especialidade);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao buscar especialidades. Erro: {ex.Message}");
            }
        }
    }
}
