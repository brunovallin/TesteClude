using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeProfissionaisDomain.Model;

public class TipoDocumento
{
    [Key]
    [Index(IsUnique = true)]
    public int Id { get; set; }
    public string? Nome { get; set;}
}