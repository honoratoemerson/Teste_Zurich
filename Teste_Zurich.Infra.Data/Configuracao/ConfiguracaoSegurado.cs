﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Zurich.Dominio.Entidades;

namespace Teste_Zurich.Infra.Data.Configuracao
{
    public class ConfiguracaoSegurado : EntityTypeConfiguration<Segurado>
    {
        public ConfiguracaoSegurado()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
   

        }
    }
}