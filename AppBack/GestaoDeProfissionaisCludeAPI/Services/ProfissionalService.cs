using System;
using GestaoDeProfissionaisCludeAPI.Interfaces;
using GestaoDeProfissionaisDomain.Model;
using GestaoDeProfissionaisPersistence.Interface;

namespace GestaoDeProfissionaisCludeAPI.Services;

public class ProfissionalService : IProfissionalService
{
    private readonly IPersistencia _geralPersistencia;
    private readonly IProfissionalService _profissionalPersistencia;

    public ProfissionalService(IPersistencia geralPersistencia, IProfissionalService profissionalPersistencia)
    {
        _geralPersistencia = geralPersistencia;
        _profissionalPersistencia = profissionalPersistencia;
    }

    public async Task<Profissional> AddProfissional(Profissional model)
    {
        try
        {
            _geralPersistencia.Add<Profissional>(model);
            if (await _geralPersistencia.SaveChangesAsync())
                return await _profissionalPersistencia.GetProfissionalById(model.Id);
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Profissional> UpdateProfissional(int profissionalId, Profissional model)
    {
        try
        {
            var profissional = await _profissionalPersistencia.GetProfissionalById(profissionalId);
            if (profissional is null) return null;

            model.Id = profissional.Id;

            _geralPersistencia.Update(model);
            if (await _geralPersistencia.SaveChangesAsync())
                return await _profissionalPersistencia.GetProfissionalById(model.Id);
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> DeleteProfissional(int profissionalId)
    {
        try
        {
            var profissional = await _profissionalPersistencia.GetProfissionalById(profissionalId);
            if (profissional is null) throw new Exception("Profissional não encontrado para deletar.");

            _geralPersistencia.Delete(profissional);
            return await _geralPersistencia.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Profissional>> GetProfissionais()
    {
        try
        {
            var profissionais = await _profissionalPersistencia.GetProfissionais();
            if (profissionais is null) return null;

            return profissionais;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Profissional>> GetProfissionaisByEspecialidade(string especialidade)
    {
        try
        {
            var profissionais = await _profissionalPersistencia.GetProfissionaisByEspecialidade(especialidade);
            if (profissionais is null) return null;

            return profissionais;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Profissional> GetProfissionalById(int id)
    {
    try
        {
            var profissional = await _profissionalPersistencia.GetProfissionalById(id);
            if (profissional is null) return null;

            return profissional;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }    }


}
