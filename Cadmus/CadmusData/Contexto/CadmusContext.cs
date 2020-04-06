using CadmusData.EntityConfig;
using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusData.Contexto
{
    public class CadmusContext : DbContext
    {
        public CadmusContext()
           : base("DefaultConnection")
        {
        }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Tirar pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Nao permite o delete em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Nao permite o delete em cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Define o campo como chave primaria
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Evita que o campo seja criado como nvarchar, o mesmo sera criado como varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            //Define o tamanho do campo varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(300));


            modelBuilder.Configurations.Add(new EscolaConfiguration());
            modelBuilder.Configurations.Add(new TurmaConfiguration());
        }

        //Validação de data Cadastro
        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        //Se a data for nullo, atualiza para a data atual
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = Convert.ToString(DateTime.Now).ToString();
        //        }
        //        //Se estiver alterando dados, nao faz nada!
        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }
        //    return base.SaveChanges();
        //}

    }
}
