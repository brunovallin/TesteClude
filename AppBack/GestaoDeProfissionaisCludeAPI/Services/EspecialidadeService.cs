using System;
using GestaoDeProfissionaisCludeAPI.Interfaces;
using GestaoDeProfissionaisDomain.Model;
using GestaoDeProfissionaisPersistence.Interface;

namespace GestaoDeProfissionaisCludeAPI.Services;

public class EspecialidadeService : IEspecialidadeService
{
    private IEspecialidadePersistencia _especialidadePersistencia;
    public EspecialidadeService(IEspecialidadePersistencia especialidadePersistencia)
    {
        _especialidadePersistencia = especialidadePersistencia;
    }
    public async Task<Especialidade> GetEspecialidadeById(int id)
    {
        try
        {
            var especialidade = await _especialidadePersistencia.GetEspecialidadeById(id);
            if (especialidade is null) return null;

            return especialidade;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Especialidade>> GetEspecialidades()
    {
        try
        {
            var especialidades = await _especialidadePersistencia.GetEspecialidades();
            if (especialidades is null) return null;

            return especialidades;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
