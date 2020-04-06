using CadmusDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadmusData.EntityConfig
{
    public class EscolaConfiguration : EntityTypeConfiguration<Escola>
    {
        public EscolaConfiguration()
        {
            HasKey(c => c.EscolaId);

            Property(c => c.NomeEscola)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
