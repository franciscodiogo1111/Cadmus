using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusData.EntityConfig
{
    public class TurmaConfiguration : EntityTypeConfiguration<Turma>
    {
        public TurmaConfiguration()
        {
            HasKey(c => c.TurmaId);

            Property(c => c.NomeTurma)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.EscolaId)
            .IsRequired(); 
            HasRequired(p => p.Escola)
                .WithMany()
                .HasForeignKey(p => p.EscolaId);
        }
    }
}
