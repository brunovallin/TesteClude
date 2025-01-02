using System;
using GestaoDeProfissionaisDomain.Model;

namespace GestaoDeProfissionaisCludeAPI.Interfaces;

public interface IEspecialidadeService
{
    public Task<Especialidade> GetEspecialidadeById(int id);

    public Task<List<Especialidade>> GetEspecialidades();
}
