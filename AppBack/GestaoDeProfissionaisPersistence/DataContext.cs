using System;
using System.Collections.Generic;
using System.Linq;
using GestaoDeProfissionaisDomain.Model;
using GestaoDeProfissionaisDomain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GestaoDeProfissionaisPersistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<TipoDocumento> tiposDocumentos = new List<TipoDocumento>();
            List<Especialidade> especialidades = new List<Especialidade>();
            foreach (var item in Enum.GetValues(typeof(TipoDocumentoEnum)))
                tiposDocumentos.Add(new TipoDocumento() { Id = (int)item, Nome = ((TipoDocumentoEnum)item).ToString() });

            modelBuilder.Entity<TipoDocumento>().HasKey(d => d.Id);
            modelBuilder.Entity<TipoDocumento>().HasData(tiposDocumentos);

            foreach (var item in Enum.GetValues(typeof(EspecialidadesEnum)))
                especialidades.Add(
                    new Especialidade()
                    {
                        Id = (int)item
                        ,Nome = ((EspecialidadesEnum)item).ToString().Replace("_", " ")
                        ,TipoDocumentoID = GetTipoDocumento((int)item, tiposDocumentos).Id
                    });
            modelBuilder.Entity<Especialidade>().HasData(especialidades);
        }

        private TipoDocumento GetTipoDocumento(int id, List<TipoDocumento> tipoDocumentos)
        {
            switch (id)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 1);
                    break;
                case 11:
                case 12:
                case 13:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 2);
                    break;
                case 14:
                case 15:
                case 16:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 3);
                    break;
                case 17:
                case 18:
                case 19:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 4);
                    break;
                case 20:
                case 21:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 5);
                    break;
                case 22:
                case 23:
                case 24:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 6);
                    break;
                case 25:
                case 26:
                case 27:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 7);
                    break;
                case 28:
                case 29:
                    return tipoDocumentos.FirstOrDefault(td => td.Id == 8);
                    break;
                default:
                    return null;
                    break;
            }

        }
    }
}