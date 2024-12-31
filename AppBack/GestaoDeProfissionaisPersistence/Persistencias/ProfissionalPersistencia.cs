using GestaoDeProfissionaisDomain.Model;
using GestaoDeProfissionaisPersistence.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProfissionaisPersistence.Persistencias
{


    public class ProfissionalPersistencia : IPersistencia, IProfissionalPersistencia
    {
        private readonly DataContext _context;

        public ProfissionalPersistencia(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<List<Profissional>> GetProfissionais()
        {
            IQueryable<Profissional> query = _context.Profissionais
                                                        .Include(p => p.Especialidade)
                                                        .ThenInclude(e => e.TipoDocumento);

            return await query.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<List<Profissional>> GetProfissionaisByEspecialidade(string especialidade)
        {
            IQueryable<Profissional> query = _context.Profissionais
                                                                    .Include(p => p.Especialidade)
                                                                    .ThenInclude(e => e.TipoDocumento);



            return await query.OrderBy(p => p.Id)
                                .Where(p => p.Especialidade.Nome.ToLower().Contains(especialidade.ToLower()))
                                .ToListAsync();
        }

        public async Task<Profissional> GetProfissionalById(int id)
        {
            IQueryable<Profissional> query = _context.Profissionais
                                                                    .Include(p => p.Especialidade)
                                                                    .ThenInclude(e => e.TipoDocumento);



            return await query.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}