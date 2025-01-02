using System;
using GestaoDeProfissionaisDomain.Model;

namespace GestaoDeProfissionaisPersistence.Interface;

public interface IEspecialidadePersistencia
{
    
    Task<List<Especialidade>> GetEspecialidades();
    Task<Especialidade> GetEspecialidadeById(int id);
}
