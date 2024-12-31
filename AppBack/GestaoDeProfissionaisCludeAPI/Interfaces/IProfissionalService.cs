using System;
using GestaoDeProfissionaisDomain.Model;

namespace GestaoDeProfissionaisCludeAPI.Interfaces;

public interface IProfissionalService
{
    Task<Profissional> AddProfissional(Profissional model);
    Task<Profissional> UpdateProfissional(int profissionalId, Profissional model);
    Task<bool> DeleteProfissional(int profissionalId);

    Task<List<Profissional>> GetProfissionais();
    Task<List<Profissional>> GetProfissionaisByEspecialidade(string especialidade);
    Task<Profissional> GetProfissionalById(int id);
}
