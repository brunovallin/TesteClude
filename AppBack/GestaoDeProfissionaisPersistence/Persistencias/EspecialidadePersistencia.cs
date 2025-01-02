using Microsoft.EntityFrameworkCore;
using GestaoDeProfissionaisDomain.Model;
using GestaoDeProfissionaisPersistence.Interface;

namespace GestaoDeProfissionaisPersistence.Persistencias;

public class EspecialidadePersistencia : IEspecialidadePersistencia
{
    private readonly DataContext _context;
    public EspecialidadePersistencia(DataContext context)
    {
        _context = context;

    }

    public async Task<Especialidade> GetEspecialidadeById(int id)
    {
        IQueryable<Especialidade> query = _context.Especialidades.Include(e => e.TipoDocumento);

        return await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public async Task<List<Especialidade>> GetEspecialidades()
    {
        IQueryable<Especialidade> query = _context.Especialidades.Include(e => e.TipoDocumento);

        return await query.OrderBy(e => e.Id).ToListAsync();
    }
}
