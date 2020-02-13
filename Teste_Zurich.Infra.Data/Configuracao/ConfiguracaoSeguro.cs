using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Zurich.Dominio.Entidades;

namespace Teste_Zurich.Infra.Data.Configuracao
{
    public class ConfiguracaoSeguro : EntityTypeConfiguration<Seguro>
    {
        public ConfiguracaoSeguro()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            HasOptional(c => c.Segurado)
                .WithRequired(c => c.Seguro);
            HasOptional(c => c.Veiculo)
                .WithRequired(c => c.Seguro);

        }
    }
}
