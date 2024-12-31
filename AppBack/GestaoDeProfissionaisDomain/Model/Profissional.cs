using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeProfissionaisDomain.Model;

public class Profissional
{
    public int Id { get; set; }
    public string Nome { get; set; }
    [ForeignKey("EspecialidadeID")]
    public Especialidade Especialidade { get; set; }
    public int NumDocumento { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime DataDeCadastro { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime DataUltimaAlteracao { get; set; }
}