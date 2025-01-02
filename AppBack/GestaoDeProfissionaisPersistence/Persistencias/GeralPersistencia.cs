using System;
using GestaoDeProfissionaisPersistence.Interface;

namespace GestaoDeProfissionaisPersistence.Persistencias;

public class GeralPersistencia : IPersistenciaGeral
{
    private readonly DataContext _context;

        public GeralPersistencia(DataContext context)
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
}
