using System;
using GestaoDeProfissionaisDomain.Model;

namespace GestaoDeProfissionaisPersistence.Interface;

public interface IProfissionalPersistencia
{
    Task<List<Profissional>> GetProfissionais();
    Task<List<Profissional>> GetProfissionaisByEspecialidade(string especialidade);
    Task<Profissional> GetProfissionalById(int id);
}
