using GestaoDeProfissionaisDomain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestaoDeProfissionaisCludeApp.Pages;

public class IndexModel : PageModel
{

    public List<Funcionario> funcionarios; 
    public List<Especialidade> especialidades;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        funcionarios = new List<Funcionario>();
        especialidades = new List<Especialidade>();
        
    }

    public void OnGet()
    {

    }
}
