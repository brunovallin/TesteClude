using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeProfissionaisDomain.Model;

public class Especialidade
{
    [Key]
    [Index(IsUnique = true)]
    public int Id { get; set;}
    public string? Nome { get; set;}
    public int TipoDocumentoID { get; set;}
    public TipoDocumento? TipoDocumento { get; set;}
}