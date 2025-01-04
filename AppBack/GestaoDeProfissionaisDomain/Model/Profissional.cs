using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeProfissionaisDomain.Model;

public class Profissional
{
    [Key]
    [Index(IsUnique = true)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public int EspecialidadeID {get;set;}
    
    public Especialidade? Especialidade { get; set; }
    public string NumDocumento { get; set; }
    [DataType(DataType.DateTime)]
    [NotMapped]
    public DateTime DataDeCadastro { get; set; }
    [DataType(DataType.DateTime)]
    [NotMapped]
    public DateTime DataUltimaAlteracao { get; set; }
}